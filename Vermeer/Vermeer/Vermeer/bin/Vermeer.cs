using IndieGoat.MaterialFramework.Controls;
using Moonbyte.Vermeer.Tor;
using System;
using System.Threading;
using System.Windows.Forms;
using Vermeer.Vermeer.bin;
using Vermeer.Vermeer.pages;

namespace Moonbyte.Vermeer.bin
{

    public enum VermeerPages { Mainform, AltPage };
    #pragma warning disable IDE1006 // Naming Styles
    public static class vermeer
    {

        #region Vars

        public static SettingsManager settings;
        public static NetworkManager networkManager;
        private static TorClient tor;
        public static Control UIThread;

        public static bool isTorInitialized = false;

        #endregion

        #region Startup

        public static void ExecuteStartupEvents()
        {
            InitializeILogger();
            settings = new SettingsManager(); // Load settings first before networkManager.
            networkManager = new NetworkManager();
        }

        #endregion

        #region ILogger

        public static ILogger ApplicationLogger;
        public static void InitializeILogger() { ApplicationLogger = new ILogger(); }
        public static class Logger
        {
            public static void WriteLog() { ApplicationLogger.WriteLog(); }
            public static void AddWhiteSpace() { ApplicationLogger.AddWhitespace(); }
            public static void AddToLog(string Header, string Value) { ApplicationLogger.AddToLog(Header, Value); }
        }

        #endregion

        #region Open & Close forms

        public static void Open(Form pageForm) { ApplicationLogger.AddToLog("INFO", "Vermeer opening " + pageForm.Name); pageForm.Show(); }

        #endregion

        #region Tor

        /// <summary>
        /// Creates a new Tor object
        /// </summary>
        public static void InitializeTorConnection()
        { tor = new TorClient(); isTorInitialized = true; ApplicationLogger.AddToLog("INFO", "Tor Proxy is currently in use"); }

        #endregion tor

        #region Closing Application

        public static void Close()
        {
            ApplicationLogger.AddToLog("INFO", "Application exiting through vermeer.Close()");
            Dispose();
        }

        public static void Dispose()
        {
            new Thread(new ThreadStart(() =>
            {
                ApplicationLogger.AddToLog("INFO", "Starting Vermeer shutdown timer! After 10 seconds, Vermeer will forcefully close.");
                Thread.Sleep(10000);
                ApplicationLogger.AddToLog("INFO", "10 seconds has passed, closing Vermeer forcefully");
                Environment.Exit(0);
            })).Start();

            if (isTorInitialized) { ApplicationLogger.AddToLog("INFO", "Disposing Tor."); tor.Dispose(); }
            ApplicationLogger.AddToLog("INFO", "Setting application last edit value"); settings.LastEdit = DateTime.Now;
            ApplicationLogger.AddToLog("INFO", "Disposing SettingsManager!"); settings.Dispose();
            ApplicationLogger.AddToLog("INFO", "Shutting down Xpcom"); Gecko.Xpcom.Shutdown();
            ApplicationLogger.AddToLog("INFO", "Shutting down CefSharp");
            ApplicationLogger.AddToLog("INFO", "Disposing Vermeer. Goodbye Human!");
            ApplicationLogger.WriteLog();
            Environment.Exit(0);
        }

        #endregion
    }
}
