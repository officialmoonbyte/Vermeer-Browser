using Moonbyte.Networking;
using Moonbyte.UniversalServer.Core.Networking;
using Moonbyte.Vermeer.bin;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using UniversalServer.Core.Networking;

namespace Vermeer.Vermeer.bin
{
    public class NetworkManager
    {
        #region Vars

        public UniversalClient client;
        private bool _isLoggedIn = false;

        #endregion Vars

        #region Properties

        public bool IsLoggedIn 
        { 
            get 
            { 
                if (client.IsConnected)
                { return _isLoggedIn; }
                return false; 
            } 
        }

        #endregion

        #region Initialization

        public NetworkManager()
        {
            initializeNetworkManager();
        }

        private async void initializeNetworkManager()
        {
            Task sendUpdateCheckTask = ConnectToServers();
            await sendUpdateCheckTask;
        }

        #endregion Initialization

        private async Task ConnectToServers()
        {
            await Task.Run(() =>
            {
                try
                {
                    string ServerIP = "moonbyte.ddns.net";

                    string externalip = new WebClient().DownloadString("http://icanhazip.com");
                    if (externalip.Contains(Dns.GetHostAddresses(new Uri("https://moonbyte.ddns.net").Host)[0].ToString())) { ServerIP = vermeer.SettingsManager.LocalNetworkServerIp; }

                    client = new UniversalClient();
                    client.ConnectToRemoteServer(ServerIP, vermeer.SettingsManager.NetworkServerPort);

                    UniversalPacket updateCheck = new UniversalPacket(
                        new Header() { status = UniversalPacket.HTTPSTATUS.GET },
                        new Message() { Data = JsonConvert.SerializeObject(new string[] { "userdatabase", "getvalue", "VermeerCurrentVersion" }), IsEncrypted = false },
                        client.GetSignature);
                    UniversalServerPacket LatestVersion = client.SendMessage(updateCheck);

                    vermeer.ApplicationLogger.AddToLog("INFO", "Latest vermeer version : " + LatestVersion);

                    if (!client.IsConnected)
                    {
                        vermeer.ApplicationLogger.AddToLog("ERROR", "Couldn't connect to Moonbyte servers! Please check your internet connection!");
                        return;
                    }
                }
                catch (Exception e)
                {
                    vermeer.ApplicationLogger.AddToLog("ERROR", "Error while trying to connect to Moonbyte servers! Details are listed below.");
                    vermeer.ApplicationLogger.LogException(e);
                }
            });
        }

        #region Connecting to the remote server

/*        private async void ConnectToRemoteServer()
        {
            await Task.Run(() =>
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
                    UniversalPacket updateCheck = new UniversalPacket(
                        new Header() { status = UniversalPacket.HTTPSTATUS.GET },
                        new Message() { Data = "userdatabase.getvalue VermeerVersion", IsEncrypted = false },
                        //client.GetSignature());
                    UniversalServerPacket LatestVersion = client.SendMessage(updateCheck);
                    vermeer.ApplicationLogger.AddToLog("INFO", "Latest vermeer version : " + LatestVersion);
                }
                catch (Exception e)
                {
                    vermeer.ApplicationLogger.AddToLog("INFO", "Couldn't connect to Moonbyte servers!");
                    vermeer.ApplicationLogger.LogException(e);
                }
            });
        }*/

        #endregion Connecting to the remote server

        #region SendMessage

/*        public async string SendMessage(string data, bool isEncrypted)
        {
            string returnString = null;
            await Task.Run(() =>
            {
                UniversalPacket messageRequest = new UniversalPacket(
                    new Header() { status = UniversalPacket.HTTPSTATUS.POST },
                    new Message() { Data = data, IsEncrypted = isEncrypted },
                    client.GetSignature());
                UniversalServerPacket serverPacket = client.SendMessage(messageRequest);
                returnString = serverPacket.Message;
            });
            return returnString;
        }*/

        #endregion SendMessage
    }
}
