using System;
namespace VisualStudioMac.OneClickToOpenFile
{
    public static class Constants
    {
        public const string Version = "1.0";
        public const string OneClickChar
#if DEBUG
         = "-->>";
#else
         = "-->";
#endif
        internal static string[] ExcludedExtensionsFromOneClick = { ".storyboard", ".xib", ".png", ".ttf" };
    }
}