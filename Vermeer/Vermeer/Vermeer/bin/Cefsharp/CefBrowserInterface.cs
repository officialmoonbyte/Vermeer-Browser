using CefSharp;
using CefSharp.WinForms;
using IndieGoat.MaterialFramework.Controls;
using Moonbyte.Vermeer.bin;
using Moonbyte.Vermeer.browser;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TheDuffman85.Tools;

namespace Vermeer.Vermeer.bin.Cefsharp
{
    public class CefBrowserInterface : VermeerBrowserInterface
    {
        public event EventHandler<DocumentTitleChange> OnTitleChange;
        public event EventHandler<DocumentURLChange> OnDocumentURLChange;
        public event EventHandler<DocumentIconChange> OnDocumentIconChange;
        public event EventHandler<DocumentLoadingChange> OnDocumentLoadChange;

        #region Vars

        MaterialTabPage mainpage;
        ChromiumWebBrowser chromeBrowser;

        #endregion

        #region Init

        public void OnInit(MaterialTabPage page, string StartURL, string ProxyURI)
        {
            mainpage = page;

            if (!Cef.IsInitialized)
            {
                CefSettings settings = new CefSettings();
                Cef.Initialize(settings);
            }

            CreateBrowserHandle(StartURL, page);

            if (ProxyURI != null)
            {
                chromeBrowser.IsBrowserInitializedChanged += (obj, args) =>
                { if (args.IsBrowserInitialized) { this.SetProxyConnection(ProxyURI); } };
            }
        }

        #endregion

        #region CreateBrowserHandle

        public void CreateBrowserHandle(string URL, MaterialTabPage tabPage)
        {
            //Initializing new browser control
            chromeBrowser = new ChromiumWebBrowser(URL);

            //Browser control properties
            chromeBrowser.Dock = DockStyle.Fill;

            //Browser Events
            chromeBrowser.TitleChanged += (obj, args) =>
            {
                TitleChangedEventArgs rArgs = (TitleChangedEventArgs)args;
                OnTitleChange?.Invoke(this, new DocumentTitleChange { DocumentTitle = rArgs.Title, VermeerVars = new DefaultVermeerVars(this, vermeerEngine.GetBrowserInstance(this)) });
            };
            chromeBrowser.AddressChanged += (obj, args) =>
            {
                AddressChangedEventArgs rArgs = (AddressChangedEventArgs)args;
                OnDocumentURLChange?.Invoke(this, new DocumentURLChange { DocumentURL = rArgs.Address, VermeerVars = new DefaultVermeerVars(this, vermeerEngine.GetBrowserInstance(this)) });
                ChangeTabIcon(rArgs.Address);
            };
            chromeBrowser.LoadingStateChanged += (obj, args) =>
            {
                LoadingStateChangedEventArgs rArgs = (LoadingStateChangedEventArgs)args;
                OnDocumentLoadChange?.Invoke(this, new DocumentLoadingChange { Status = rArgs.IsLoading, VermeerVars = new DefaultVermeerVars(this, vermeerEngine.GetBrowserInstance(this)) });
            };
        }

        #endregion

        #region Get Browser Values

        public Control GetBrowserControl()
        { return chromeBrowser; }
        public MaterialTabPage getTabPage()
        { return mainpage; }

        #endregion

        #region BrowserControls

        public void GoForward()
        { chromeBrowser.GetBrowser().GoForward(); vermeer.ApplicationLogger.AddToLog("INFO", "Chrome Browser GoForward"); }
        public void Reload()
        { chromeBrowser.GetBrowser().Reload(); vermeer.ApplicationLogger.AddToLog("INFO", "Chromium Browser Reloaded."); }
        public bool IsBackEnabled()
        { return chromeBrowser.GetBrowser().CanGoBack; }
        public bool IsForwardAvailable()
        { return chromeBrowser.GetBrowser().CanGoForward; }
        public void Navigate(string URL)
        { chromeBrowser.Load(URL); vermeer.ApplicationLogger.AddToLog("INFO", "Chromium Browser Navigated"); }
        public void GoBack()
        { chromeBrowser.GetBrowser().GoBack(); vermeer.ApplicationLogger.AddToLog("INFO", "Chromium Browser GoBack"); }

        #endregion

        #region Proxy

        public void SetProxyConnection(string ProxyURI)
        {
            Cef.UIThreadTaskFactory.StartNew(delegate
            {

                var rc = chromeBrowser.GetBrowser().GetHost().RequestContext;
                var dict = new Dictionary<string, object>();
                dict.Add("mode", "fixed_servers");
                dict.Add("server", ProxyURI);
                string error;
                bool success = rc.SetPreference("proxy", dict, out error);

            }); 
        }

        #endregion

        #region Change Tab Icon

        public void ChangeTabIcon(string URL)
        {
            Favicon favicon = Favicon.GetFromUrl(URL);
            OnDocumentIconChange?.Invoke(this, new DocumentIconChange { icon = favicon.Icon, VermeerVars = new DefaultVermeerVars(this, vermeerEngine.GetBrowserInstance(this)) });
        }

        #endregion

    }
}
