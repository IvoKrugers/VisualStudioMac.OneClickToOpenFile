using Mono.Addins;
using Mono.Addins.Description;
using VisualStudioMac.OneClickToOpenFile;

[assembly: Addin(
    Id = "OneClickToOpenFile",
    Namespace = "VisualStudioMac",
    Version = Constants.Version,
    Category = "IDE extensions"
)]

[assembly: AddinName("One Click To Open File")]
[assembly: AddinDescription("This extension opens a file with only one click on the solutiontree.\n\nby Ivo Krugers")]
[assembly: AddinAuthor("Ivo Krugers")]
[assembly: AddinUrl("https://github.com/IvoKrugers/EssentialsAddin")]

[assembly: AddinDependency("::MonoDevelop.Core", MonoDevelop.BuildInfo.Version)]
[assembly: AddinDependency("::MonoDevelop.Ide", MonoDevelop.BuildInfo.Version)]
