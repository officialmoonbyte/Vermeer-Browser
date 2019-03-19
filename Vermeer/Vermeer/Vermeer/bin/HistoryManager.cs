using Moonbyte.Vermeer.bin;
using System;
using System.Linq;
using System.Threading;

namespace Vermeer.Vermeer.bin
{
    public class HistoryManager
    {

        #region Vars

        static string _HistoryName = "vermeerHistory";
        static string _HistoryDate = "vermeerHistoryDate";

        #endregion 

        #region SyncLocalNetwork

        public static void Sync()
        {
            new Thread(new ThreadStart(() =>
            {
                string checkHistory = vermeer.networkManager.client.ClientSender.SendCommand("userdatabase", new string[] { "CheckUserSetting", vermeer.settings.Username, vermeer.settings.Password, _HistoryName});
                if (checkHistory == "CETSET_TRUEF")
                {
                    WriteHistoryToNetwork(); vermeer.ApplicationLogger.AddToLog("INFO", "User account history was null!");
                }

                DateTime lastEdit = DateTime.Parse(vermeer.networkManager.client.ClientSender.SendCommand("userdatabase", new string[] { "GetUserSetting", vermeer.settings.Username, vermeer.settings.Password, _HistoryDate }));

                if (lastEdit > vermeer.settings.LastEdit)
                {
                    vermeer.ApplicationLogger.AddToLog("INFO", "History on the server is newer than the one on local disk."); WriteHistoryToFile();
                } else if (lastEdit < vermeer.settings.LastEdit)
                {
                    vermeer.ApplicationLogger.AddToLog("INFO", "History on the server is older than the one on local disk."); WriteHistoryToNetwork();
                } else if (lastEdit == vermeer.settings.LastEdit) { }

            })).Start();
        }

        #endregion


        #region Edit History

        private static void WriteHistoryToNetwork()
        {
            vermeer.settings.LastEdit = DateTime.Now;
            vermeer.networkManager.client.ClientSender.SendCommand("userdatabase", new string[] { "EditUserSetting", vermeer.settings.Username, vermeer.settings.Password, _HistoryName, string.Join(vermeer.settings.seperator, vermeer.settings.History) });
            vermeer.networkManager.client.ClientSender.SendCommand("userdatabase", new string[] { "EditUserSetting", vermeer.settings.Username, vermeer.settings.Password, _HistoryDate, vermeer.settings.LastEdit.ToString()});
        }

        private static void WriteHistoryToFile()
        {
            vermeer.settings.LastEdit = DateTime.Now;
            vermeer.settings.History = vermeer.networkManager.client.ClientSender.SendCommand("userdatabase", new string[] { "GetUserSetting", vermeer.settings.Username, vermeer.settings.Password, _HistoryName }).Split(new string[] { vermeer.settings.seperator }, StringSplitOptions.RemoveEmptyEntries).ToList();
            vermeer.networkManager.client.ClientSender.SendCommand("userdatabase", new string[] { "EditUserSetting", vermeer.settings.Username, vermeer.settings.Password, _HistoryDate, vermeer.settings.LastEdit.ToString() });
        }

        #endregion

        #region Add website

        private static void AddHistoryValue(string WebsiteName, string WebsiteURL)
        {
            string sep = "*&%20%&*";
            DateTime time = DateTime.Now;

            string year = time.Year.ToString();
            string month = time.Month.ToString();
            string day = time.Day.ToString();
            string hour = time.Hour.ToString();
            string minute = time.Minute.ToString();

            string wholeObject = WebsiteName + sep + WebsiteURL + sep + year + sep + month + sep + day + sep + hour + sep + minute;
            vermeer.settings.History.Add(wholeObject);
        }

        #endregion

    }
}
