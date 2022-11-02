using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;

namespace VisualStudioMac.OneClickToOpenFile.CommandHandlers
{
    public class StartupCommandHandler : CommandHandler
    {
        protected override void Run()
        {
            Settings.OneClickToOpenFileEnabled = false;
            //IdeApp.Workspace.SolutionLoaded += (s, e) => Settings.OneClickToOpenFileEnabled = true;
            //IdeApp.Workspace.SolutionUnloaded += (s, e) => Settings.OneClickToOpenFileEnabled = false;
            //IdeApp.Workbench.LayoutChanged += Workbench_LayoutChanged;
            //IdeApp.Exiting += (s,e) => Settings.OneClickToOpenFileEnabled = false;
            //IdeApp.Workbench.GuiLocked += (s, e) => Settings.OneClickToOpenFileEnabled = false;
            //IdeApp.Workbench.GuiUnlocked += (s, e) => Settings.OneClickToOpenFileEnabled = true;
        }

        //private void Workbench_LayoutChanged(object sender, System.EventArgs e)
        //{
        //    Settings.OneClickToOpenFileEnabled = IdeApp.Workbench.CurrentLayout != null;
        //}

        //private void Workspace_SolutionLoaded(object sender, MonoDevelop.Projects.SolutionEventArgs e)
        //{
        //    IdeApp.Workspace.SolutionLoaded -= Workspace_SolutionLoaded;
        //    if (e.Solution != null)
        //    {
        //        //Settings.OneClickToOpenFileEnabled = true;
        //    }
        //}
    }
}