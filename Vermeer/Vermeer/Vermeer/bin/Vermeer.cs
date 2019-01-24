using CefSharp;
using CefSharp.WinForms;
using IndieGoat.MaterialFramework.Controls;
using Moonbyte.Vermeer.browser;
using System;
using System.Drawing;
using System.Windows.Forms;
using Vermeer.Vermeer.bin;
using Vermeer.Vermeer.bin.Engine;
using Vermeer.Vermeer.pages;
using static Vermeer.Vermeer.bin.Engine.displayhandler;

namespace Moonbyte.Vermeer.bin
{

    public enum VermeerPages { Mainform };
    #pragma warning disable IDE1006 // Naming Styles
    public static class vermeer
    {

        #region Vars

        public static MaterialTabControl baseTabControl = new MaterialTabControl();

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

        #region Closing Application

        public static void Close()
        {
            ApplicationLogger.AddToLog("INFO", "Application exiting through vermeer.Close()");
            Application.Exit();
        }

        #endregion

        #region Default Browser Engine

        public class DefaultBrowserEngine : VermeerBrowserInterface
        {

            #region Vars

            ChromiumWebBrowser webBrowser = null;
            MaterialTabPage MainTabPage = null;

            string currentTitle = null;
            string currentURL = null;
            Image currentIcon = null;

            #endregion

            #region Events

            public event EventHandler<DocumentTitleChange> OnTitleChange;
            public event EventHandler<DocumentURLChange> OnDocumentURLChange;
            public event EventHandler<DocumentIconChange> OnDocumentIconChange;

            #endregion

            #region Required Browser Properties

            public Control GetBrowserControl() { return webBrowser; }
            public bool IsLoading() { return webBrowser.GetBrowser().IsLoading; }
            public bool IsBackEnabled() { return webBrowser.GetBrowser().CanGoBack; }
            public bool IsForwardAvailable() { return webBrowser.GetBrowser().CanGoForward; }
            public Image GetCurrentIcon() { return currentIcon; }
            public string GetCurrentURL() { return currentURL; }
            public string GetCurrentTitle() { return currentTitle; }
            public MaterialTabPage getTabPage() { return MainTabPage; }

            #endregion

            #region Initialize

            public void CreateBrowserHandle(string URL, MaterialTabPage tabPage)
            {
                //Sets the default TabPage
                MainTabPage = tabPage;

                //Initialize the new browser
                webBrowser = new ChromiumWebBrowser(URL);

                //Initializing Display Handler
                displayhandler displayHandler = new displayhandler(tabPage);
                displayHandler.OnIconChanged += (obj, args) =>
                {
                    IconChangedEventArgs e = args;
                    vermeer.ApplicationLogger.AddToLog("INFO", "Raising Event : OnIconChanged");
                    OnDocumentIconChange?.Invoke(this, new DocumentIconChange { icon = e.icon });
                };

                webBrowser.DisplayHandler = displayHandler;

                //Setting all the events of the browser
                webBrowser.TitleChanged += (obj, args) =>
                {
                    //Valuating event args
                    TitleChangedEventArgs arg = (TitleChangedEventArgs)args;

                    //Invoke OnTitleChanged
                    OnTitleChange?.Invoke(this, new DocumentTitleChange { DocumentTitle = arg.Title }); currentTitle = arg.Title;
                };
                webBrowser.AddressChanged += (obj, args) =>
                {
                    //Valuating event args
                    AddressChangedEventArgs arg = (AddressChangedEventArgs)args;

                    //Invoke OnDocumentURLChange
                    OnDocumentURLChange?.Invoke(this, new DocumentURLChange { DocumentURL = arg.Address }); currentURL = arg.Address;
                };
            }

            #endregion

            #region Browser Controls

            public void GoBack() { webBrowser.GetBrowser().GoBack(); }
            public void GoForward() { webBrowser.GetBrowser().GoForward(); }
            public void Navigate(string URL) { webBrowser.Load(URL); }

            #endregion

        }

        #endregion
    }
}
