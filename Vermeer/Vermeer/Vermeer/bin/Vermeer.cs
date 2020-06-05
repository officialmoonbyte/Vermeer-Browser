using CefSharp;
using Moonbyte.Vermeer.API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Vermeer.Vermeer.bin;

namespace Moonbyte.Vermeer.bin
{

    public enum VermeerPages { Mainform, AltPage };
    #pragma warning disable IDE1006 // Naming Styles
    public static class vermeer
    {

        #region Vars

        private static string Seperators = "^%69%^";

        public static NetworkManager networkManager;
        public static ISettingsManager SettingsManager = new ISettingsManager();
        public static Control UIThread;

        public static bool isTorInitialized = false;
        public static bool XpcomInitialized = false;

        public static string HomeWebsite = "https://duckduckgo.com/";
        public static string SearchEngineSite = "https://duckduckgo.com/?q=";

        public static List<string> IgnoredSSLErrorSites = new List<string>();

        #endregion

        #region Startup

        public static void ExecuteStartupEvents()
        {
            InitializeILogger();
            networkManager = new NetworkManager();

            //Setting events
            VermeerAPI.OnLogEvent += (obj, args) =>
            { ApplicationLogger.AddToLog(args.title, args.log); };
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

        #region Closing Application

        public static void Close()
        {
            var stackFrame = new StackFrame(1);
            var callerMethod = stackFrame.GetMethod();
            var callingClass = callerMethod.DeclaringType; // <-- this should be your calling class

            ApplicationLogger.AddToLog("INFO", "Calling Class : " + callingClass);
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

            if (vermeer.XpcomInitialized) { ApplicationLogger.AddToLog("INFO", "Shutting down Xpcom"); Gecko.Xpcom.Shutdown(); }
            else { ApplicationLogger.AddToLog("INFO", "Xpcom was never initialized! Skipping..."); }
            ApplicationLogger.AddToLog("INFO", "Shutting down CefSharp"); Cef.Shutdown();
            ApplicationLogger.AddToLog("INFO", "Disposing Vermeer. Goodbye Human!");
            ApplicationLogger.WriteLog();
            Environment.Exit(0);
        }

        #endregion
    }
}
