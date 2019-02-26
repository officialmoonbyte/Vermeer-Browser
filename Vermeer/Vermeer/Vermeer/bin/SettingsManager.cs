using GlobalSettingsFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Vermeer.Vermeer.bin
{
    public class SettingsManager
    {

        #region Vars

        GFS SF = new GFS();
        string seperator = "%^20^%";
        string SettingsDirectory = Application.StartupPath + "\\vermeerSettings.set";

        #endregion

        #region Initialization

        public SettingsManager()
        {
            SF.SettingsDirectory = SettingsDirectory;
            InitializeSettingValues();
        }

        #endregion Initialization

        #region Settings Names

        private string _Username = "%USERNAME%";
        private string _Password = "%PASSWORD%";
        private string _History = "%HISTORY%";
        private string _DownloadHistory = "%DOWNLOADHISTORY%";

        #endregion

        #region Setting Values

        public string Username;
        public string Password;
        public List<string> History;
        public List<string> DownloadHistory;

        #endregion

        #region Loading

        private void InitializeSettingValues()
        {
            // USERNAME
            if (SF.CheckSetting(_Username)) { Username = SF.ReadSetting(_Username); }
            else { SF.EditSetting(_Username, "null"); Username = SF.ReadSetting(_Username); }
            // PASSWORD
            if (SF.CheckSetting(_Password)) { Password = SF.ReadSetting(_Password); }
            else { SF.EditSetting(_Password, "null"); Password = SF.ReadSetting(_Password); }
            //History
            if (SF.CheckSetting(_History)) { History = SF.ReadSetting(_History).Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries).ToList(); }
            else { SF.EditSetting(_History, ""); History = SF.ReadSetting(_History).Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries).ToList(); }
            //DownloadHistory
            if (SF.CheckSetting(_DownloadHistory)) { DownloadHistory = SF.ReadSetting(_DownloadHistory).Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries).ToList(); }
            else { SF.EditSetting(_DownloadHistory, ""); DownloadHistory = SF.ReadSetting(_DownloadHistory).Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries).ToList(); }
        }

        #endregion Loading

        #region Saving

        private void SaveSettingValues()
        {
            SF.EditSetting(_Username, Username);
            SF.EditSetting(_Password, Password);
            SF.EditSetting(_History, string.Join(seperator, History));
            SF.EditSetting(_DownloadHistory, string.Join(seperator, DownloadHistory));
        }

        #endregion

        #region Dispose

        public void Dispose() { SaveSettingValues(); }

        #endregion

    }
}
