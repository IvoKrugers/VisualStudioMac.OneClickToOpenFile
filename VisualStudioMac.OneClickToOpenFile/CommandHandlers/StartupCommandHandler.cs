using System.Threading.Tasks;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using VisualStudioMac.OneClickToOpenFile.CommandHandlers.Node;

namespace VisualStudioMac.OneClickToOpenFile.CommandHandlers
{
    public class StartupCommandHandler : CommandHandler
    {
        protected override void Run()
        {
            Settings.OneClickToOpenFileEnabled = false;
            Settings.OneClickToOpenFileEnabled = true;
            //IdeApp.Workspace.SolutionLoaded += Workspace_SolutionLoaded;
            //IdeApp.Workspace.SolutionUnloaded += (s, e) => Settings.OneClickToOpenFileEnabled = false;

            //IdeApp.Workspace.FileAddedToProject += (s, e) => OnActivateOneClickAfterDelay();
            //IdeApp.Workspace.FileRemovedFromProject += (s, e) => OnActivateOneClickAfterDelay();
            //IdeApp.Workspace.FileRenamedInProject += (s, e) => OnActivateOneClickAfterDelay();

            //IdeApp.Workbench.LayoutChanged += Workbench_LayoutChanged;
            //IdeApp.Exiting += (s,e) => Settings.OneClickToOpenFileEnabled = false;
            //IdeApp.Workbench.GuiLocked += (s, e) => Settings.OneClickToOpenFileEnabled = false;
            //IdeApp.Workbench.GuiUnlocked += (s, e) => Settings.OneClickToOpenFileEnabled = true;

            IdeApp.Workbench.DocumentClosed += (s, e) => OneClickNodeCommandHandler.LastFileOpened = string.Empty;
        }

        private void Workspace_SolutionLoaded(object sender, MonoDevelop.Projects.SolutionEventArgs e)
        {
            //if (e.Solution != null)
            //{
            //    ActivateOneClickAfterDelay();
            //}
        }

        private void OnActivateOneClickAfterDelay()
        {
            //if (Settings.OneClickToOpenFileEnabled)
            //{
            //    Settings.OneClickToOpenFileEnabled = false;
            //    ActivateOneClickAfterDelay();
            //}
        }

        private void ActivateOneClickAfterDelay()
        {
            Task.Delay(10000).ContinueWith(async t =>
            {
                await t;
                Settings.OneClickToOpenFileEnabled = true;
            });
        }
    }
}