using System.Collections.Generic;

namespace Launcher.Utils
{
    public class PatchFiles
    {
        public static Dictionary<string, string> Patch_Files = new Dictionary<string, string>();
        public static string patch, url;
    }

    public class UserFilePatch
    {
        public static Dictionary<string, string> UserPatchFile = new Dictionary<string, string>();
        public static string patch, url;
    }
}
