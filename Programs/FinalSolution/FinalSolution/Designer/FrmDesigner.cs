﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Deployment.Internal.CodeSigning;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Microsoft.VisualBasic.Devices;

using Solution.Designer.Blocks;
using Solution.Welcome;

namespace Solution.Designer {

	/// <inheritdoc />
	/// <summary>
	/// The form upon which designmentination occurs 
	/// </summary>
	public partial class FrmDesigner : Form {

		private readonly FrmWelcome _ParentFrmWelcome;
		
		#region Startup
		
		/// <inheritdoc />
		public FrmDesigner(FrmWelcome ParentFrmWelcome = null) {
			InitializeComponent();
			Connections = new Dictionary<BaseBlock, BaseBlock>();
			
			SContainer_Workspace.Panel2.Paint += DrawLinks;
			SContainer_Workspace.Panel2.Refresh();
			
			MovementTicker = new Timer {
				Interval = 10,
				Enabled = false
			};
			MovementTicker.Tick += DoMove;

			_ParentFrmWelcome = ParentFrmWelcome;

			BlockTree.NodeMouseDoubleClick += AddBlock;
			QuitToolStripMenuItem.Click += BtnExit_Click;

			SContainer_Workspace.Panel2.SuspendLayout();
			/*{
				var VarBlock = new DeclareVarBlock {
					Location = new Point(300, 10),
					Id = (int) BasicBlockIds.Starter,
					Size = new Size(200, 100),
					TabIndex = (int) BasicBlockIds.Starter
				};
				
				VarBlock.MouseDown += Block_OnMouseDown;
				VarBlock.MouseUp += Block_OnMouseUp;

				SContainer_Workspace.Panel2.Controls.Add(VarBlock);
			}*/
			
			{
				var StartBlock = new StartBlock {
					Location = new Point(10, 10),
					Id = (int) BasicBlockIds.Starter,
					Size = new Size(200, 100),
					TabIndex = (int) BasicBlockIds.Starter
				};

				StartBlock.MouseDown += Block_OnMouseDown;
				StartBlock.MouseUp += Block_OnMouseUp;

				SContainer_Workspace.Panel2.Controls.Add(StartBlock);
			}

			SContainer_Workspace.Panel2.ResumeLayout(true);

		}

		private void BtnExit_Click(object Sender, EventArgs E) {

			_ParentFrmWelcome?.Show(); // Show parent form
			

			Hide(); // Become invisible
			Dispose(); // Clean up
			
		}

		#endregion
		
		#region Block Tree
		
		private int NextId = (int) BasicBlockIds.Variable;

		private void AddBlock(object S, TreeNodeMouseClickEventArgs E) {

			if (E.Node.Nodes.Count != 0) return;

			BaseBlock NewBlock;

			NewBlock = new EmptyNormalBlock {
				// Add New Block
				Id = NextId,
				Size = new Size(200, 100),
				TabIndex = NextId
			};
			NewBlock.Name = NewBlock.GetType().Name + NextId;

			AddBlock(NewBlock);

		}

		private void AddBlock(BaseBlock ToAdd) {

			
			
			var NewX = SContainer_Workspace.Panel2.Width / 2 - ToAdd.Width / 2;
			var NewY = SContainer_Workspace.Panel2.Height / 2 - ToAdd.Height / 2;

			ToAdd.Location = new Point(NewX, NewY);

			ToAdd.MouseDown += Block_OnMouseDown;
			ToAdd.MouseUp += Block_OnMouseUp;


			SContainer_Workspace.Panel2.SuspendLayout();
			SContainer_Workspace.Panel2.Controls.Add(ToAdd);
			SContainer_Workspace.Panel2.ResumeLayout(true);

			NextId++;
		}

		#endregion
		
		#region Block Movement

		private Timer MovementTicker;
		private Point Offset;
		private BaseBlock ToMove;

		private void Block_OnMouseDown(object S, MouseEventArgs E) {
			if (!(S is BaseBlock Block)) return;
			//Debug.WriteLine("Mouse Down");

			Block.BringToFront();


			if (Block.RectangleToScreen(Block.TopConnectorZone).Contains(MousePosition)) {
				TopConnector_Clicked(Block);
				return;
			}

			if (Block.RectangleToScreen(Block.BottomConnectorZone).Contains(MousePosition)) {
				BottomConnector_Clicked(Block);
				return;
			}

			var RTS = Block.RectangleToScreen(Block.DisplayRectangle);

			Offset = new Point(MousePosition.X - RTS.Left,
			                   MousePosition.Y - RTS.Top);   
			
			ToMove = Block;
			MovementTicker.Start();
			SContainer_Workspace.Panel2.Refresh();
		}

		private void Block_OnMouseUp(object S, MouseEventArgs E) {
			if (!(S is BaseBlock)) return;
			//Debug.WriteLine("Mouse Up");

			MovementTicker.Stop();
			ToMove = null;

			SContainer_Workspace.Panel2.Refresh();
		}

		private void DoMove(object S, EventArgs E) {

			var MousePos = SContainer_Workspace.Panel2.PointToClient(MousePosition);

			ToMove.Left = MousePos.X - Offset.X;
			ToMove.Top = MousePos.Y- Offset.Y;

		}

		#endregion

		#region Connection Management

		private Dictionary<BaseBlock, BaseBlock> Connections;
		
		private BaseBlock First;
		private BaseBlock Second;

		private void TopConnector_Clicked(BaseBlock Block) {

			if (!(Second is null) | Block is StartBlock) {
				
				if (Block == Second) {
					Debug.WriteLine($"Second: {Second.Name}");
					Block.ConnectorSelected = null;
					Block.Refresh();
					Second = null;
				}

				return;
			}

			Block.ConnectorSelected = true;
			Block.Refresh();

			if (First is null) {
				Second = Block;
			} else {
				Second = Block;
				MakeConnection();
			}
		}

		private void BottomConnector_Clicked(BaseBlock Block) {
			
			if (!(First is null)) {
				if (Block == First) {
					Block.ConnectorSelected = null;
					Block.Refresh();
					First = null;
				}
				return;
			}

			Block.ConnectorSelected = false;
			Block.Refresh();
			
			if (Second is null) {
				First = Block;
			} else {
				First = Block;
				MakeConnection();
			}
		}

		[SuppressMessage("ReSharper", "LocalVariableHidesMember")]
		private void MakeConnection() {
			this.First.ConnectorSelected = null;
			this.Second.ConnectorSelected = null;

			var First = this.First;
			var Second = this.Second;
			
			this.First = null;
			this.Second = null;

			if (First == Second) return;
			
			Connections.Add(First, Second);
			First.ConnectNext(Second.Id);

			MessageBox.Show("Connected");

			SContainer_Workspace.Panel2.Refresh();
			
			First.Invalidate();
			Second.Invalidate();

		}

		#endregion
		
		#region Drawing

		private void DrawLinks(object S, PaintEventArgs E) {
			var SCWPnl2GFX = E.Graphics;
			foreach (var Connection in Connections) {

				if (Connection.Key == ToMove || Connection.Value == ToMove) continue;

				var P1 =
					SContainer_Workspace
						.Panel2
						.PointToClient(Connection
						               .Key
						               .PointToScreen(new Point(Connection
						                                        .Key.BottomConnectorZone
						                                        .Location.X, Connection
						                                                     .Key
						                                                     .BottomConnectorZone
						                                                     .Location.Y + Connection
						                                                                   .Key
						                                                                   .BottomConnectorZone
						                                                                   .Height)));
				var P2 = SContainer_Workspace
				         .Panel2
				         .PointToClient(Connection
				                        .Value
				                        .PointToScreen(Connection
				                                       .Value
				                                       .TopConnectorZone
				                                       .Location));
				SCWPnl2GFX.DrawLine(Pens.Black, P1, P2);

				P1.X = P1.X + Connection.Key.BottomConnectorZone.Width;
				P2.X = P2.X + Connection.Value.TopConnectorZone.Width;

				SCWPnl2GFX.DrawLine(Pens.Black, P1, P2);

			}
		}


		#endregion

	}
}
