using Moonbyte.Networking;
using Moonbyte.UniversalServer.Core.Networking;
using Moonbyte.Vermeer.bin;
using System;
using System.Net;
using System.Threading.Tasks;
using UniversalServer.Core.Networking;

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
            { isLoggedIn = value; if (value == true) {  } } }

        #endregion

        #region Initialization

        public NetworkManager()
        {
            //ConnectToRemoteServer();
        }

        #endregion Initialization

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
