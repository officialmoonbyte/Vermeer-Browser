using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;


#region README

/*
 * TorClient.cs opens up a SOCKS5 proxy server on creation via Public TorClient()
 * 
 * Make sure you DISPOSE of this object before the process closes! If you do not
 * dispose of this object, Tor will continue to run and use up un-needed resources.
 */

#endregion README

#region Copyright

/*
 * Copyright (c) Moonbyte Corporation 2019. All Rights are Reserved.
 * 
 * This class is only permitted to be used in Vermeer Browser or any
 * products relating to Vermeer Browser. 
 */

#endregion Copyright

namespace Moonbyte.Vermeer.Tor
{
    public class TorClient
    {

        #region Vars

        static string authPassword = "44122529889853407860381335";
        static Socket server = null;
        static Process proc;

        #endregion Vars

        #region Initialize

        /// <summary>
        /// A class object used to interact with Tor
        /// </summary>
        public TorClient()
        {
            StartTor();

            //connect to control port and authenticate
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9151);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Connect(endPoint);
            server.Send(Encoding.ASCII.GetBytes("AUTHENTICATE \"" + authPassword + "\"" + Environment.NewLine));
            byte[] data = new byte[1024];
            int receivedDataLength = server.Receive(data);

            //get a new identity
            server.Send(Encoding.ASCII.GetBytes("SIGNAL NEWNYM" + Environment.NewLine));
            data = new byte[1024];
            receivedDataLength = server.Receive(data);
            string stringData = Encoding.ASCII.GetString(data, 0, receivedDataLength);

            //all fine?
            if (!stringData.Contains("250"))
            {
                Console.WriteLine("Unable to signal new user to server.");
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            else { Console.WriteLine("SIGNAL NEWNYM sent successfully"); }
        }

        #endregion Initialize

        #region StartTor 

        /// <summary>
        /// Checks if tor is open
        /// </summary>
        private void CheckIfAlive() { foreach (var process in Process.GetProcessesByName("tor")) process.Kill(); }
        /// <summary>
        /// Starts the Tor process
        /// </summary>
        private void StartTor()
        {
            //Checks if Tor is open, if so closes it
            CheckIfAlive();

            //Start tor with its config file
            proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "Tor\\tor.exe",
                    Arguments = "-f .\\torrc",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WorkingDirectory = "Tor\\"
                }
            };
            proc.Start();
        }

        #endregion StartTor

        #region Dispose

        public void Dispose()
        {
            proc.Kill();
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        #endregion
    }
}
