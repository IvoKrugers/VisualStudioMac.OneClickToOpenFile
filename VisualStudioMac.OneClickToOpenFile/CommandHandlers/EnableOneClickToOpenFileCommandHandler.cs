using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Ide.Gui.Pads;

namespace VisualStudioMac.OneClickToOpenFile.CommandHandlers
{
    public class EnableOneClickToOpenFileCommandHandler : CommandHandler
    {
        protected override void Update(CommandInfo info)
        {
            info.Enabled = true;
            info.Checked = Settings.OneClickToOpenFileEnabled;
        }

        protected override void Run()
        {
            Settings.OneClickToOpenFileEnabled = !Settings.OneClickToOpenFileEnabled;

            var pad = (SolutionPad)IdeApp.Workbench.Pads.SolutionPad.Content;
            if (pad == null)
                return;

            pad.RefreshTree();
        }
    }

    public static class SolutionPadExtensions
    {
        public static void RefreshTree(this SolutionPad pad)
        {
            if (pad == null)
                return;

            var root = pad.GetRootNode();
            if (root != null)
            {
                root.Expanded = false;
                pad.GetTreeView().RefreshNode(root);
            }
        }

        private static ITreeNavigator GetRootNode(this SolutionPad pad)
            => pad.GetTreeView().GetRootNode();

        private static ITreeNavigator GetRootNode(this ExtensibleTreeViewController treeview)
        {
            var pos = treeview.GetRootPosition();
            return treeview.GetNodeAtPosition(pos);
        }

        private static ExtensibleTreeViewController GetTreeView(this SolutionPad pad)
            => pad.Controller;
    }
}

