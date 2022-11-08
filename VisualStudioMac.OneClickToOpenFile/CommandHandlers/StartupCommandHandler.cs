using System.Threading.Tasks;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;

namespace VisualStudioMac.OneClickToOpenFile.CommandHandlers
{
    public class StartupCommandHandler : CommandHandler
    {
        protected override void Run()
        {
            Settings.OneClickToOpenFileEnabled = false;
            IdeApp.Workspace.SolutionLoaded += Workspace_SolutionLoaded;
            IdeApp.Workspace.SolutionUnloaded += (s, e) => Settings.OneClickToOpenFileEnabled = false;
            //IdeApp.Workbench.LayoutChanged += Workbench_LayoutChanged;
            //IdeApp.Exiting += (s,e) => Settings.OneClickToOpenFileEnabled = false;
            //IdeApp.Workbench.GuiLocked += (s, e) => Settings.OneClickToOpenFileEnabled = false;
            //IdeApp.Workbench.GuiUnlocked += (s, e) => Settings.OneClickToOpenFileEnabled = true;
        }

        private void Workspace_SolutionLoaded(object sender, MonoDevelop.Projects.SolutionEventArgs e)
        {
            if (e.Solution != null)
            {
                Task.Delay(10000).ContinueWith(async t =>
                {
                    await t;
                    Settings.OneClickToOpenFileEnabled = true;
                });
            }
        }
    }
}