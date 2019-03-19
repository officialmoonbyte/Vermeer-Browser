using IndieGoat.Net.Tcp;
using IndieGoat.Net.Updater;
using Moonbyte.Vermeer.bin;
using System.Threading;
using System.Windows.Forms;

namespace Vermeer.Vermeer.bin
{
    public class NetworkManager
    {
        #region Vars

        public UniversalClient client = new UniversalClient();
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
                client.ConnectToRemoteServer("moonbyte.us", 4543);
                if (client.Client.Connected) { isConnected = true; }

                if (!isConnected) vermeer.ApplicationLogger.AddToLog("INFO", "Could not connect to moonbyte.us");
                if (isConnected)
                {
                    client.ClientSender.SendCommand("UserDatabase", new string[] { "EditServerValue", "VermeerVersion", "1.0.0.0" });
                // ** Logging in user if username is not null **
                if (vermeer.settings.Username != "null")
                {
                        string userResponse = client.ClientSender.SendCommand("UserDatabase", new string[] { "LOGINUSER", vermeer.settings.Username, vermeer.settings.Password });
                        if (userResponse == "USRLOG_TRUE") { IsLoggedIn = true; }
                        else
                        {
                            vermeer.settings.Username = "null";
                            vermeer.settings.Password = "null";

                            vermeer.ApplicationLogger.AddToLog("INFO", "Username and password is invalid! Deleting saved user information.");
                        }
                    }
                }
                // ** Application Updating **
                UniversalServiceUpdater updater = new UniversalServiceUpdater("https://moonbyte.net/download/vermeer.zip");
                updater.UpdateUrlLocation = "https://moonbyte.net/download/vermeer.zip";
                updater.CheckUpdate("moonbyte.us", 4543);

            })).Start();
        }

        #endregion Connecting to the remote server
    }
}
