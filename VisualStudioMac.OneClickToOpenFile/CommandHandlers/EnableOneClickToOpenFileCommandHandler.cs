using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui.Pads;
using VisualStudioMac.OneClickToOpenFile.Extensions;

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
}