using System;
using System.IO;
using Gtk;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Projects;
using VisualStudioMac.OneClickToOpenFile.CommandHandlers.Node;

namespace VisualStudioMac.OneClickToOpenFile.NodeBuilderExtensions
{
    public class OneClickFileNodeBuilderExt : NodeBuilderExtension
    {
        public override bool CanBuildNode(Type dataType)
            => typeof(ProjectFile).IsAssignableFrom(dataType);

        public override void BuildNode(ITreeBuilder treeBuilder, object dataObject, NodeInfo nodeInfo)
        {
            if (dataObject is ProjectFile file && Settings.OneClickToOpenFileEnabled)
            {
                var ext = Path.GetExtension(file.FilePath);
                if (Constants.ExcludedExtensionsFromOneClick.FindIndex((s) => s == ext) == -1)
                {
                    nodeInfo.SecondaryLabel = $"{Constants.OneClickChar} {nodeInfo.SecondaryLabel}";
                }
            }
        }

        public override Type CommandHandlerType
            => typeof(OneClickNodeCommandHandler);
    }
}