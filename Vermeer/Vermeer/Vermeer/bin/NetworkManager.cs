using Moonbyte.Net.UniversalProjectUpdater;
using Moonbyte.UniversalClient;
using Moonbyte.Vermeer.bin;
using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Vermeer.Vermeer.bin
{
    public class NetworkManager
    {
        #region Vars

        public UniversalClient client = new UniversalClient(true);
        public bool isLoggedIn = false;
        bool isConnected = false;

        #endregion Vars

        #region Properties

        public bool IsLoggedIn { get { return isLoggedIn; } set
            { isLoggedIn = value; if (value == true) { HistoryManager.Sync(); } } }

        #endregion

        #region Initialization

        public NetworkManager()
        {
            ConnectToRemoteServer();
        }

        #endregion Initialization

        #region Connecting to the remote server

        private void ConnectToRemoteServer()
        {
            new Thread(new ThreadStart(() =>
            {
            try
            {
                string ServerIP = "moonbyte.us";

                string externalip = new WebClient().DownloadString("http://icanhazip.com");
                if (externalip.Contains(Dns.GetHostAddresses(new Uri("http://moonbyte.us").Host)[0].ToString())) { ServerIP = "192.168.0.17"; }
                client.ConnectToRemoteServer(ServerIP, 7875);
                if (client.IsConnected) { isConnected = true; }

                if (!isConnected) vermeer.ApplicationLogger.AddToLog("INFO", "Could not connect to moonbyte.us");
                if (isConnected)
                {
                    // ** Logging in user if username is not null **
                    if (vermeer.settings.Username != "null")
                    {
                        string userResponse = client.SendCommand("UserDatabase", new string[] { "LOGINUSER", vermeer.settings.Username, vermeer.settings.Password });
                        if (userResponse == "USRLOG_TRUE") { IsLoggedIn = true; }
                        else
                        {
                            vermeer.settings.Username = "null";
                            vermeer.settings.Password = "null";

                            vermeer.ApplicationLogger.AddToLog("INFO", "Username and password is invalid! Deleting saved user information.");
                        }
                    }
                }

                UniversalProjectUpdater Updater = new UniversalProjectUpdater(Application.ProductName, ServerIP, 7777);
                string version = Updater.GetVersion();

                if (version != Application.ProductVersion)
                {
                    string DownloadURL = Updater.GetDownloadURL();
                    Updater.InitializeIDownloader(DownloadURL);

                    vermeer.ApplicationLogger.AddToLog("INFO", "Initialized IDownloader for a new Vermeer update! Update " + version + " is available at " + DownloadURL);
                    vermeer.ApplicationLogger.AddToLog("INFO", "Current vermeer version : " + Application.ProductVersion);
                }
            }
            catch (Exception e)
            {
                vermeer.ApplicationLogger.AddToLog("INFO", "Couldn't connect to Moonbyte servers!");
                vermeer.ApplicationLogger.LogException(e);
                }
            })).Start();
        }

        #endregion Connecting to the remote server
    }
}
