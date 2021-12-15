using Microsoft.Win32;

namespace WindTrackCreator.Util
{
    class ConfigHelper
    {
        public static void EnableMPCBEChapterMarkers()
        {
            try
            {
                RegistryKey openKey = Registry.CurrentUser.OpenSubKey("Software\\MPC-BE\\Settings", true);

                if (openKey != null)
                {
                    object value = openKey.GetValue("ChapterMarker");
                    openKey.SetValue("ChapterMarker", 1, RegistryValueKind.DWord);
                }
                else
                {
                    RegistryKey createKey = Registry.CurrentUser.CreateSubKey("Software\\MPC-BE\\Settings", true);
                    createKey.SetValue("ChapterMarker", 1, RegistryValueKind.DWord);
                }
            }
            catch { }
        }

        public static void EnableMPCBEWebAPI()
        {
            try
            {
                RegistryKey openKey = Registry.CurrentUser.OpenSubKey("Software\\MPC-BE\\Settings", true);

                if (openKey != null)
                {
                    object value = openKey.GetValue("EnableWebServer");
                    openKey.SetValue("EnableWebServer", 1, RegistryValueKind.DWord);
                }
                else
                {
                    RegistryKey createKey = Registry.CurrentUser.CreateSubKey("Software\\MPC-BE\\Settings", true);
                    createKey.SetValue("EnableWebServer", 1, RegistryValueKind.DWord);
                }
            }
            catch { }
        }
    }
}