using System;
using System.IO;
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

            if (CurrentNode.DataItem is ProjectFile f)
            {
                string ext = Path.GetExtension(f.FilePath);
                if (Constants.ExcludedExtensionsFromOneClick.FindIndex((s) => s == ext) == -1)
                {
                    if (IdeApp.Workbench.ActiveDocument == null || IdeApp.Workbench.ActiveDocument.Name != f.FilePath.FileName)
                        IdeApp.Workbench.OpenDocument(f.FilePath, project: null);
                }
            }
        }

        public override void OnRenameStarting(ref string startingText, ref int selectionStart, ref int selectionLength)
        {
            base.OnRenameStarting(ref startingText, ref selectionStart, ref selectionLength);
        }

        public override void OnRenameStarting(ref int selectionStart, ref int selectionLength)
        {
            base.OnRenameStarting(ref selectionStart, ref selectionLength);
        }
    }
}