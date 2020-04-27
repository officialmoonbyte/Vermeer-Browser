using Moonbyte.Vermeer.bin;
using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using UniversalClient;

namespace Vermeer.Vermeer.bin
{
    public class NetworkManager
    {
        #region Vars

        public Universalclient client = new Universalclient(true);
        public bool isLoggedIn = false;
        bool isConnected = false;

        #endregion Vars

        #region Properties

        public bool IsLoggedIn { get { return isLoggedIn; } set
            { isLoggedIn = value; if (value == true) {  } } }

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
                    string ServerIP = "moonbyte.ddns.net";

                    string externalip = new WebClient().DownloadString("http://icanhazip.com");
                    if (externalip.Contains(Dns.GetHostAddresses(new Uri("https://moonbyte.ddns.net").Host)[0].ToString())) { ServerIP = "192.168.0.16"; }
                    client.ConnectToRemoteServer(ServerIP, 7876);
                    if (client.IsConnected) { isConnected = true; }
                    vermeer.ApplicationLogger.AddToLog("INFO", "Connected to Universal Server! ServerIP : " + ServerIP);

                    // Checks for update
                    string LatestVersion = client.SendCommand("userdatabase", new string[] { "getvalue", "VermeerVersion" });
                    vermeer.ApplicationLogger.AddToLog("INFO", "Latest vermeer version : " + LatestVersion);
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
