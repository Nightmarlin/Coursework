using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;
// ReSharper disable LocalizableElement

namespace Solution.Build {

	/// <summary>
	/// Provides a method to compile a functioning program.
	/// </summary>
	public class Builder {

		/// <summary>
		/// The name of the project, and therefore the name of the resulting EXE
		/// </summary>
		public readonly string Name;

		/// <summary>
		/// Constructor. 
		/// </summary>
		/// <param name="Name">The name of the project</param>
		public Builder(string Name) {
			if (Name is null) Name = "YourProject";
			this.Name = Name;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Program">The program as text</param>
		/// <param name="Path">The folder path that the EXE will be stored in IE "C:\\Docs\\Projects\\MyProject"</param>
		/// <returns>whether or not the build succeeded</returns>
		public bool Build(string Program, string Path = "") {

			// Check a path has been assigned
			if (Path == "") {
				Path = GetPath();
			}

			// Get the wrapper file
			var Wrapper = Properties.Resources.Wrapper;

			Wrapper = Wrapper.Replace("YourProject", $"{Name}");
			Program = Program.Replace("YourProject", $"{Name}");

			// Build the program
			var Output = CompileFromStrings(Path, Wrapper, Program);

			MessageBox.Show(Output);



			return !Output.StartsWith("!: "); // 
		}

		/// <summary>
        /// Asks the user where they want to save the executable if no path was specified
        /// </summary>
        /// <returns>The fully qualified folder path to the EXE</returns>
        public static string GetPath() {
            string Result;
            using (var FBD = new FolderBrowserDialog {
                ShowNewFolderButton = true,
                Description = @"A folder was not specified. Please select one now"
            }) {
                var DR = FBD.ShowDialog();
                Result = DR == DialogResult.OK ? FBD.SelectedPath : Environment.CurrentDirectory;
            }
            return Result;
        }

	    private string CompileFromStrings(string FilePath, string WrapperTxt, string ProgramTxt) {

		    var CodeProvider = CodeDomProvider.CreateProvider("CSharp");
		    var OutputLocation = $"{FilePath}\\{Name}.exe";

		    var Parameters = new CompilerParameters {
			    GenerateExecutable = true,
			    OutputAssembly = OutputLocation,
			    CompilerOptions = "/main:YourProject.Main_Program" // There is a Main method in both the wrapper
																// and the user program. By adding this switch
																// MSBuild is told to execute the program from
																// the Main method in the Wrapper
		    };
		    Parameters.ReferencedAssemblies.Add("Newtonsoft.Json.dll");
		    Parameters.ReferencedAssemblies.Add("System.Linq.dll");
			
		    //Make sure we generate an EXE, not a DLL
		    var Results = CodeProvider.CompileAssemblyFromSource(Parameters, WrapperTxt, ProgramTxt);

		    var OutputText = new StringBuilder();
		    
		    if (Results.Errors.Count > 0) {
			    // Errors Happened
			    OutputText.Append($@"!: {Results.Errors.Count} error{(Results.Errors.Count == 1 ? "" : "s")} occurred: {Environment.NewLine}");
			    foreach (CompilerError CompErr in Results.Errors) {
				    OutputText.AppendLine("(" + CompErr.Line + ", " + CompErr.Column + ") " +
				                      ", Error Number: " + CompErr.ErrorNumber +
				                      ", '" + CompErr.ErrorText + ";" + 
				                      Environment.NewLine);
			    }
		    } else {
			    //Successful Compile
			    OutputText.Append($"Compilation was successful. EXE path is '{Results.PathToAssembly}'");
		    }

		    return OutputText.ToString();
		    
	    }

		/// <summary>
		/// Saves the user file generated from the user program and the template.
		/// Saved in "FolderPath\ProjectName.cs", or (if the name is unsuitable) "FolderPath\MyProjectSave.cs"
		/// </summary>
		/// <param name="Program">The program text</param>
		/// <param name="FolderPath">The path to the folder where the file will be saved</param>
		/// <returns>Whether the operation was successful or not</returns>
	    public bool SaveUserCSFile(string Program, string FolderPath) {
			try {
				File.WriteAllText(FolderPath + Name, Program);
				return true;

			} catch (Exception) {
				return false;

			}
		}

    }

}