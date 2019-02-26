using IndieGoat.MaterialFramework.Controls;
using Moonbyte.Vermeer.Tor;
using System.Windows.Forms;
using Vermeer.Vermeer.bin;
using Vermeer.Vermeer.pages;

namespace Moonbyte.Vermeer.bin
{

    public enum VermeerPages { Mainform };
    #pragma warning disable IDE1006 // Naming Styles
    public static class vermeer
    {

        #region Vars

        public static MaterialTabControl baseTabControl = new MaterialTabControl();
        public static SettingsManager settings = new SettingsManager();
        private static TorClient tor;

        #endregion

        #region Startup

        public static void ExecuteStartupEvents()
        {
            InitializeILogger();
        }

        #endregion

        #region ILogger

        public static ILogger ApplicationLogger;
        public static void InitializeILogger() { ApplicationLogger = new ILogger(); }
        public static class Logger
        {
            public static void WriteLog() { ApplicationLogger.WriteLog(); }
            public static void SetLoggingEvents() { ApplicationLogger.SetLoggingEvents(); }
            public static void AddWhiteSpace() { ApplicationLogger.AddWhitespace(); }
            public static void AddToLog(string Header, string Value) { ApplicationLogger.AddToLog(Header, Value); }
        }

        #endregion

        #region Open & Close forms

        public static void Open(VermeerPages page) { Form pageForm = GetForm(page); ApplicationLogger.AddToLog("INFO", "Vermeer opening " + pageForm.Name); pageForm.Show(); }
        public static void Close(VermeerPages page) { Form pageForm = GetForm(page); ApplicationLogger.AddToLog("INFO", "Vermeer closing " + pageForm.Name); GetForm(page).Close(); GetForm(page).Dispose(); }
        public static Form GetForm(VermeerPages page)
        {
            foreach (Form form in Application.OpenForms) { if (form.Name == GetFormName(page)) { ApplicationLogger.AddToLog("INFO", "Got existing form page : " + form.Name); return form; } }
            if (page == VermeerPages.Mainform) { return new mainPage(); }
            return new mainPage();
        }
        public static string GetFormName(VermeerPages page)
        {
            if (page == VermeerPages.Mainform) { return "mainPage"; }
            return "mainPage";
        }

        #endregion

        #region Tor

        /// <summary>
        /// Creates a new Tor object
        /// </summary>
        public static void InitializeTorConnection()
        { tor = new TorClient(); ApplicationLogger.AddToLog("INFO", "Tor Proxy is currently in use"); }

        #endregion tor

        #region Closing Application

        public static void Close()
        {
            ApplicationLogger.AddToLog("INFO", "Application exiting through vermeer.Close()");
            Application.Exit();
        }

        public static void Dispose()
        {
            tor.Dispose(); ApplicationLogger.AddToLog("INFO", "Disposed Tor.");
            settings.Dispose(); ApplicationLogger.AddToLog("INFO", "Disposed SettingsManager!");
            ApplicationLogger.AddToLog("INFO", "Disposing Vermeer. Goodbye Human!");
        }

        #endregion
    }
}
