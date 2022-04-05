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
            var canBuild =
                typeof(ProjectFolder).IsAssignableFrom(dataType) ||
                typeof(ProjectFile).IsAssignableFrom(dataType) ||
                dataType.Name == "CSharpProject";
            return canBuild;
        }

        public override void BuildNode(ITreeBuilder treeBuilder, object dataObject, NodeInfo nodeInfo)
        {
            ProjectFile file = (ProjectFile)dataObject;
            var ext = Path.GetExtension(file.FilePath);

            if (Constants.ExcludedExtensionsFromOneClick.FindIndex((s) => s == ext) == -1)
            {
                nodeInfo.Label = $"{nodeInfo.Label} {Constants.OneClickChar}";
            }
        }

        public override Type CommandHandlerType
            => typeof(OneClickNodeCommandHandler);
    }
}
