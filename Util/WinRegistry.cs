using Microsoft.Win32;
using System;
using System.Linq;

namespace WindTrackCreator.Util
{
    public static class WinRegistry
    {
        public static string GetRegKey(string path, string key)
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(path, true);
                return regKey.GetValue(key).ToString();
            }
            catch
            {
                return "";
            }
        }

        public static bool CheckRegKey(string path, string key)
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(path, true);
                return (regKey.GetValueNames().Contains(key));
            }
            catch
            {
                return false;
            }
        }
    }
}