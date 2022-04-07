using System;
using System.IO;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Ide.Gui.Pads.ProjectPad;
using MonoDevelop.Projects;

namespace VisualStudioMac.OneClickToOpenFile
{
    public class OneClickFileNodeBuilderExt : NodeBuilderExtension
    {
        public override bool CanBuildNode(Type dataType)
        {
            var canBuild = typeof(ProjectFile).IsAssignableFrom(dataType);

            return canBuild;
        }

        public override void BuildNode(ITreeBuilder treeBuilder, object dataObject, NodeInfo nodeInfo)
        {
            if (dataObject is ProjectFile file)
            {
                var ext = Path.GetExtension(file.FilePath);
                if (Constants.ExcludedExtensionsFromOneClick.FindIndex((s) => s == ext) == -1)
                {
                    nodeInfo.Label = $"{nodeInfo.Label} {Constants.OneClickChar}";
                }
            }
        }

        public override Type CommandHandlerType
            => typeof(OneClickNodeCommandHandler);
    }
}
