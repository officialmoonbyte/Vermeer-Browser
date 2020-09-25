using MoonbyteSettingsManager;
using System;
using System.IO;

namespace Vermeer.Vermeer.bin
{
    public class ISettingsManager
    {
        #region Emus

        public enum browserEngine { Chromium, Firefox }

        #endregion Emus

        #region Vars

        MSMCore vault;
        public browserEngine BrowserEngine = browserEngine.Chromium;

        // Values managed by the settings manager
        public string LocalNetworkServerIp = "192.168.0.16";
        public int NetworkServerPort = 7876;

        #endregion Vars

        #region Properties

        public string ApplicationDataDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Moonbyte", "Vermeer");
        public string ApplicationSettingsDirectory => Path.Combine(ApplicationDataDirectory, "Settings");
        public string CacheDataDirectory => Path.Combine(ApplicationDataDirectory, "Cache");

        #endregion Properties

        #region Setting Titles

        private const string TTL_LocalNetworkServerIp = "LocalNetworkServerIP";
        private const string TTL_NetworkServerPort = "NetworkServerPort";

        #endregion Setting Titles

        #region Startup

        public ISettingsManager()
        {
            vault = new MSMCore()
            {
                SettingsDirectory = ApplicationSettingsDirectory
            };

            LoadValues();
            SaveValues();
        }

        #endregion Startup

        #region SaveValues

        private void SaveValues()
        {
            vault.EditSetting(TTL_LocalNetworkServerIp, LocalNetworkServerIp);
            vault.EditSetting(TTL_NetworkServerPort, NetworkServerPort.ToString());
            vault.SaveSettings();
        }

        #endregion SaveValues

        #region LoadValues

        #region LoadValuesLocal

        private string LoadSettingValue(string settingTitle, string defaultValue)
        {
            if (vault.CheckSetting(settingTitle))
            {
                return vault.ReadSetting(settingTitle);
            }
            else
            {
                vault.EditSetting(settingTitle, defaultValue);
                return defaultValue;
            }
        }

        #endregion LoadValuesLocal

        private void LoadValues()
        {
            LocalNetworkServerIp = LoadSettingValue(TTL_LocalNetworkServerIp, LocalNetworkServerIp);
            NetworkServerPort = int.Parse(LoadSettingValue(TTL_NetworkServerPort, NetworkServerPort.ToString()));
        }

        #endregion LoadValues
    }
}
