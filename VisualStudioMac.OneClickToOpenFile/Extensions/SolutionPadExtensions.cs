using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Ide.Gui.Pads;

namespace VisualStudioMac.OneClickToOpenFile.Extensions
{
    public static class SolutionPadExtensions
    {
        public static void RefreshTree(this SolutionPad pad)
        {
            if (pad == null)
                return;

            var root = pad.GetRootNode();
            if (root != null)
            {
                pad.GetTreeView().RefreshNode(root);
                root.Expanded = true;
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