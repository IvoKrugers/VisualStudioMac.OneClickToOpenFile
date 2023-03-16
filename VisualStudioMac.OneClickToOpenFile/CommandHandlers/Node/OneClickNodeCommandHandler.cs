using System;
using System.Diagnostics;
using System.IO;
using EnvDTE;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Projects;

namespace VisualStudioMac.OneClickToOpenFile.CommandHandlers.Node
{
    public class OneClickNodeCommandHandler : NodeCommandHandler
    {
        public static string LastFileOpened = "";

        private static DateTime _lastOnItemSelected = DateTime.Now.AddMinutes(-5);

        public override void OnItemSelected()
        {
            base.OnItemSelected();

            LogInfo("OnItemSelected");

            if (CurrentNode.DataItem is ProjectFile f && Settings.OneClickToOpenFileEnabled)
            {
                try
                {
                    if ((DateTime.Now - _lastOnItemSelected).TotalMilliseconds <= 200.0)
                    {
                        return;
                    }

                    string ext = Path.GetExtension(f.FilePath);
                    if (Constants.ExcludedExtensionsFromOneClick.FindIndex((s) => s == ext) == -1)
                    {
                        var selectedItem = IdeApp.ProjectOperations.CurrentSelectedItem as ProjectFile;
                        var selectedNode = Controller.GetSelectedNode();
                        var control = Controller.Control;

                        var fullFilename = GetFullFilename(f.FilePath);

                        if (IdeApp.IsRunning
                            && IdeApp.IsInitialized
                            && IdeApp.Workspace.CurrentSelectedSolution != null
                            //&& IdeApp.Workbench.CurrentLayout != null
                            //&& (IdeApp.Workbench.ActiveDocument == null || IdeApp.Workbench.ActiveDocument.FilePath.FullPath != f.FilePath.FullPath)
                            && string.Compare(LastFileOpened, fullFilename, StringComparison.Ordinal) != 0
                            )
                        {
                            IdeApp.Workbench.OpenDocument(f.FilePath, f.Project);
                            //IdeApp.Workbench.OpenDocument(f.FilePath, f.Project, MonoDevelop.Ide.Gui.OpenDocumentOptions.OpenIfMissing | MonoDevelop.Ide.Gui.OpenDocumentOptions.BringToFront);
                            //IdeApp.Workbench.OpenDocument(f.FilePath, f.Project, MonoDevelop.Ide.Gui.OpenDocumentOptions.TryToReuseViewer | MonoDevelop.Ide.Gui.OpenDocumentOptions.OpenIfMissing);
                        }

                        LastFileOpened = fullFilename;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                finally
                {
                    _lastOnItemSelected = DateTime.Now;
                }
            }
        }

        private string GetFullFilename(FilePath fp)
        {
            if (fp == null)
                return "";

            return GetFullFilename(fp.ParentDirectory) + "/" + fp.FileName;
        }

        //public override void RefreshItem()
        //{
        //    base.RefreshItem();
        //    LogInfo("RefreshItem");
        //}

        //public override void ActivateItem()
        //{
        //    base.ActivateItem();
        //    LogInfo("ActivateItem");
        //}

        private void LogInfo(string methodname)
        {
            var selectedNode = Controller.GetSelectedNode();
            var control = Controller.Control;
            var f = CurrentNode.DataItem as ProjectFile;
            var selectedItem = IdeApp.ProjectOperations.CurrentSelectedItem as ProjectFile;

            var sb = new System.Text.StringBuilder();
            sb.Append($"[{methodname}]:");
            sb.Append($" CurrentNode.Filled: {CurrentNode.Filled.ToString().PadLeft(6)},");
            sb.Append($" CurrentNode.DataItem.Filename: {f.FilePath.FileName.PadLeft(25)},");
            sb.Append($" Selected: {CurrentNode.Selected.ToString().PadLeft(5)},");
            sb.Append($" CurrentSelectedItem: {(selectedItem?.FilePath.FileName ?? "").PadLeft(25)},");
            sb.Append($" ActiveDocument: {(IdeApp.Workbench.ActiveDocument?.Name ?? "").PadLeft(25)},");
            sb.Append($" Workbench.HasToplevelFocus: {IdeApp.Workbench.HasToplevelFocus.ToString().PadLeft(5)},");
            sb.Append($" Controller.Control.HasFocus: {control.HasFocus.ToString().PadLeft(5)}");

            Debug.WriteLine(sb.ToString());
        }
    }
}