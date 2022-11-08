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
        public override void OnItemSelected()
        {
            base.OnItemSelected();

            var selectedNode = Controller.GetSelectedNode();
            var control = Controller.Control;

            if (CurrentNode.DataItem is ProjectFile f && Settings.OneClickToOpenFileEnabled)
            {
                string ext = Path.GetExtension(f.FilePath);
                if (Constants.ExcludedExtensionsFromOneClick.FindIndex((s) => s == ext) == -1)
                {
                    var selectedItem = IdeApp.ProjectOperations.CurrentSelectedItem as ProjectFile;

                    if (IdeApp.IsRunning
                        && IdeApp.IsInitialized
                        && IdeApp.Workspace.CurrentSelectedSolution != null
                        && IdeApp.Workbench.CurrentLayout != null
                        && (IdeApp.Workbench.ActiveDocument == null || IdeApp.Workbench.ActiveDocument.FilePath.FullPath != f.FilePath.FullPath))
                    {
                        Debug.WriteLine($"[OnItemSelected]: CurrentNode: {f.FilePath.FileName} - Selected: {CurrentNode.Selected}, CurrentSelectedItem: {selectedItem?.FilePath.FileName ?? ""}, ActiveDocument: {IdeApp.Workbench.ActiveDocument?.Name ?? ""}");


                        //if (Controller.Control.HasFocus)
                        //{
                        IdeApp.Workbench.OpenDocument(f.FilePath, f.Project);
                        //IdeApp.Workbench.OpenDocument(f.FilePath, f.Project, MonoDevelop.Ide.Gui.OpenDocumentOptions.OpenIfMissing | MonoDevelop.Ide.Gui.OpenDocumentOptions.BringToFront);
                        //IdeApp.Workbench.OpenDocument(f.FilePath, f.Project, MonoDevelop.Ide.Gui.OpenDocumentOptions.TryToReuseViewer | MonoDevelop.Ide.Gui.OpenDocumentOptions.OpenIfMissing);
                        //}
                        return;
                    }
                }
            }
        }

        //public override void RefreshItem()
        //{
        //    base.RefreshItem();
        //    var selectedNode = Controller.GetSelectedNode();
        //    var control = Controller.Control;
        //    var f = CurrentNode.DataItem as ProjectFile;
        //    var selectedItem = IdeApp.ProjectOperations.CurrentSelectedItem as ProjectFile;

        //    Debug.WriteLine($"[RefreshItem]: CurrentNode: {f.FilePath.FileName} - Selected: {CurrentNode.Selected}, CurrentSelectedItem: {selectedItem?.FilePath.FileName ?? ""}, ActiveDocument: {IdeApp.Workbench.ActiveDocument?.Name ?? ""}");
        //}

        //public override void ActivateItem()
        //{
        //    base.ActivateItem();
        //}


    }
}