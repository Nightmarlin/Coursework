﻿namespace Solution.Welcome {
	partial class FrmWelcome {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Yes",
            "Yes",
            "Yes",
            "Yes"}, -1);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWelcome));
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ClearRecentItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.List_RecentItems = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Lbl_RecentItems_Header = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.BtnShowDesigner = new System.Windows.Forms.Button();
			this.BtnOpenFile = new System.Windows.Forms.Button();
			this.TT = new System.Windows.Forms.ToolTip(this.components);
			this.MainMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.MainMenu.Size = new System.Drawing.Size(804, 24);
			this.MainMenu.TabIndex = 0;
			this.MainMenu.Text = "Main Menu";
			// 
			// FileToolStripMenuItem
			// 
			this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QuitToolStripMenuItem,
            this.ClearRecentItemsToolStripMenuItem});
			this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
			this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.FileToolStripMenuItem.Text = "File";
			// 
			// QuitToolStripMenuItem
			// 
			this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
			this.QuitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.QuitToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.QuitToolStripMenuItem.Text = "Quit";
			this.QuitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
			// 
			// ClearRecentItemsToolStripMenuItem
			// 
			this.ClearRecentItemsToolStripMenuItem.Name = "ClearRecentItemsToolStripMenuItem";
			this.ClearRecentItemsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
			this.ClearRecentItemsToolStripMenuItem.Text = "Clear Recent Items";
			this.ClearRecentItemsToolStripMenuItem.Click += new System.EventHandler(this.ClearRecentItemsToolStripMenuItem_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
			this.splitContainer1.Size = new System.Drawing.Size(804, 287);
			this.splitContainer1.SplitterDistance = 285;
			this.splitContainer1.TabIndex = 1;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.List_RecentItems, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.Lbl_RecentItems_Header, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(285, 287);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// List_RecentItems
			// 
			this.List_RecentItems.BackColor = System.Drawing.SystemColors.ControlDark;
			this.List_RecentItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.List_RecentItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.List_RecentItems.Dock = System.Windows.Forms.DockStyle.Fill;
			this.List_RecentItems.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
			this.List_RecentItems.Location = new System.Drawing.Point(3, 31);
			this.List_RecentItems.Name = "List_RecentItems";
			this.List_RecentItems.Size = new System.Drawing.Size(279, 253);
			this.List_RecentItems.TabIndex = 1;
			this.List_RecentItems.UseCompatibleStateImageBehavior = false;
			this.List_RecentItems.View = System.Windows.Forms.View.Details;
			this.List_RecentItems.VirtualListSize = 1;
			// 
			// Lbl_RecentItems_Header
			// 
			this.Lbl_RecentItems_Header.BackColor = System.Drawing.SystemColors.ControlDark;
			this.Lbl_RecentItems_Header.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Lbl_RecentItems_Header.Location = new System.Drawing.Point(3, 0);
			this.Lbl_RecentItems_Header.Name = "Lbl_RecentItems_Header";
			this.Lbl_RecentItems_Header.Size = new System.Drawing.Size(279, 28);
			this.Lbl_RecentItems_Header.TabIndex = 2;
			this.Lbl_RecentItems_Header.Text = "Recent Projects";
			this.Lbl_RecentItems_Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.BtnShowDesigner, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.BtnOpenFile, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(515, 287);
			this.tableLayoutPanel2.TabIndex = 11;
			// 
			// BtnShowDesigner
			// 
			this.BtnShowDesigner.AutoSize = true;
			this.BtnShowDesigner.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnShowDesigner.Location = new System.Drawing.Point(3, 3);
			this.BtnShowDesigner.Name = "BtnShowDesigner";
			this.BtnShowDesigner.Size = new System.Drawing.Size(251, 281);
			this.BtnShowDesigner.TabIndex = 10;
			this.BtnShowDesigner.Text = "Create A Program";
			this.TT.SetToolTip(this.BtnShowDesigner, "Open an empty designer");
			this.BtnShowDesigner.UseVisualStyleBackColor = true;
			this.BtnShowDesigner.Click += new System.EventHandler(this.BtnShowDesigner_Click);
			// 
			// BtnOpenFile
			// 
			this.BtnOpenFile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnOpenFile.Location = new System.Drawing.Point(260, 3);
			this.BtnOpenFile.Name = "BtnOpenFile";
			this.BtnOpenFile.Size = new System.Drawing.Size(252, 281);
			this.BtnOpenFile.TabIndex = 11;
			this.BtnOpenFile.Text = "Open A Previously Saved Program";
			this.BtnOpenFile.UseVisualStyleBackColor = true;
			this.BtnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
			// 
			// FrmWelcome
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(804, 311);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.MainMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FrmWelcome";
			this.Text = "Welcome";
			this.Load += new System.EventHandler(this.FrmWelcome_Load);
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button BtnShowDesigner;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ListView List_RecentItems;
		private System.Windows.Forms.Label Lbl_RecentItems_Header;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button BtnOpenFile;
		private System.Windows.Forms.ToolStripMenuItem ClearRecentItemsToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ToolTip TT;
	}
}

