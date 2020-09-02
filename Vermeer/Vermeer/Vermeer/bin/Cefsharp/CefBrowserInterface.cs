using CefSharp;
using CefSharp.WinForms;
using Moonbyte.MaterialFramework.Controls;
using Moonbyte.Vermeer.bin;
using Moonbyte.Vermeer.browser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Vermeer.Vermeer.bin.Cefsharp
{
    public class CefBrowserInterface : VermeerBrowserInterface
    {
        public event EventHandler<DocumentTitleChange> OnDocumentTitleChange;
        public event EventHandler<DocumentURLChange> OnDocumentURLChange;
        public event EventHandler<DocumentIconChange> OnDocumentIconChange;
        public event EventHandler<DocumentLoadingChange> OnDocumentLoadChange;

        string _currentURL;
        public string CurrentURL()
        { return _currentURL; }
        public string BrowserVersion()
        { return "CEF"; }

        #region Vars

        MaterialTabPage mainpage;
        ChromiumWebBrowser chromeBrowser;

        string UserAgent = "Mozilla/5.0 (Windows NT 6.2; Win64; x64; rv:60.0) Gecko/20100101 Firefox/74.0";

        bool _firstNavigateCheck = false;
        public void SetFirstNavigateCheck(bool value)
        {
            _firstNavigateCheck = value;
        }
        public bool FirstNavigateCheck()
        {
            return _firstNavigateCheck;
        }

        #endregion

        #region Init

        public void OnInit(MaterialTabPage page, string StartURL, string ProxyURI)
        {
            mainpage = page;

            if (!Cef.IsInitialized)
            {
                try
                {
                    CefSettings settings = new CefSettings(); vermeer.ApplicationLogger.AddToLog("INFO", "Started initializing CefSharp");

                    settings.UserAgent = UserAgent;
                    settings.CachePath = Path.Combine(vermeer.SettingsManager.CacheDataDirectory, "CefCache"); vermeer.ApplicationLogger.AddToLog("CEFSHARP", "Set cache directory to " + settings.CachePath);
                    settings.CefCommandLineArgs.Add("disable-gpu-vsync"); vermeer.ApplicationLogger.AddToLog("CEFSHARP", "Disabled GPU Vsync.");

                    if (!Directory.Exists(settings.CachePath)) Directory.CreateDirectory(settings.CachePath);

                    Cef.Initialize(settings); vermeer.ApplicationLogger.AddToLog("CEFSHARP", "Initialized");
                }
                catch (Exception e)
                {
                    vermeer.ApplicationLogger.AddToLog("error", "Failed to initialize CefSharp! " + e.Message);
                    vermeer.ApplicationLogger.AddToLog("error", e.StackTrace);
                }
            }

            CreateBrowserHandle(StartURL, page);

            //if (ProxyURI != null)
            //{ this.SetProxyConnection(ProxyURI); }
        }

        #endregion

        #region CreateBrowserHandle
        public void CreateBrowserHandle(string URL, MaterialTabPage tabPage)
        {
            //Initializing new browser control
            chromeBrowser = new ChromiumWebBrowser(URL);

            //Browser control properties
            chromeBrowser.Dock = DockStyle.Fill;

            //Browser classes
            chromeBrowser.RenderProcessMessageHandler = new RenderProcessMessageHandler();
            chromeBrowser.RequestHandler = new RequestHandler(this);
            chromeBrowser.DisplayHandler = new DisplayHandler(this);

            //Browser Events
            chromeBrowser.TitleChanged += (obj, args) =>
            {
                TitleChangedEventArgs rArgs = (TitleChangedEventArgs)args;
                OnDocumentTitleChange?.Invoke(this, new DocumentTitleChange { DocumentTitle = rArgs.Title, VermeerVars = new DefaultVermeerVars(this, vermeerEngine.GetBrowserInstance(this)) });
            };
            chromeBrowser.AddressChanged += (obj, args) =>
            {
                AddressChangedEventArgs rArgs = (AddressChangedEventArgs)args;
                _currentURL = rArgs.Address;
                OnDocumentURLChange?.Invoke(this, new DocumentURLChange { DocumentURL = rArgs.Address, VermeerVars = new DefaultVermeerVars(this, vermeerEngine.GetBrowserInstance(this)) });
            };
            chromeBrowser.LoadingStateChanged += (obj, args) =>
            {
                LoadingStateChangedEventArgs rArgs = (LoadingStateChangedEventArgs)args;
                OnDocumentLoadChange?.Invoke(this, new DocumentLoadingChange { Status = rArgs.IsLoading, VermeerVars = new DefaultVermeerVars(this, vermeerEngine.GetBrowserInstance(this)) });
            };
            chromeBrowser.IsBrowserInitializedChanged += (obj, args) =>
            {
                if (chromeBrowser.IsBrowserInitialized)
                {
                    
                }
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
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (obj, args) => { chromeBrowser.Load(URL); };
            worker.RunWorkerAsync();

            vermeer.ApplicationLogger.AddToLog("INFO", "Chromium Browser Navigated");
        }

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
            Image favicon = DownloadImage(URL);
            OnDocumentIconChange?.Invoke(this, new DocumentIconChange { icon = favicon, VermeerVars = new DefaultVermeerVars(this, vermeerEngine.GetBrowserInstance(this)) });
        }

        public void DeleteCookies()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Download Image

        Image DownloadImage(string fromUrl)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            try
            {
                using (System.Net.WebClient webClient = new System.Net.WebClient())
                {
                    using (Stream stream = webClient.OpenRead(fromUrl))
                    { return Image.FromStream(stream); }
                } 
            } catch (Exception e)
                { return Image.FromFile(Environment.CurrentDirectory + @"\icon.ico"); }
        }

        #endregion Download Image

        #region Reload Page

        public void ReloadPage()
        { chromeBrowser.Reload(); }

        public Image GetBrowserIcon()
        {
            return null;
        }

        #endregion Reload Page

    }
}
