using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Gecko;
using Moonbyte.MaterialFramework.Controls;
using Moonbyte.Vermeer.bin;
using Moonbyte.Vermeer.browser;

namespace Vermeer.Vermeer.bin.GeckoFX
{
    public class GeckoBrowserInterface : VermeerBrowserInterface
    {
        public event EventHandler<DocumentTitleChange> OnDocumentTitleChange;
        public event EventHandler<DocumentURLChange> OnDocumentURLChange;
        public event EventHandler<DocumentIconChange> OnDocumentIconChange;
        public event EventHandler<DocumentLoadingChange> OnDocumentLoadChange;
        public Image GetBrowserIcon()
        {
            return null;
        }
        string _currentURL;
        public string CurrentURL()
        { return _currentURL; }
        public string BrowserVersion()
        { return "GECKO"; }
        #region Vars

        GeckoWebBrowser webBrowser;
        MaterialTabPage hostTabPage;

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

        #region CreateBrowserHandle

        public void CreateBrowserHandle(string URL, MaterialTabPage tabPage)
        {


            //Initialize firefox Xpcom
            string xpcomDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); Console.WriteLine(Path.Combine(xpcomDirectory, "Firefox64"));
            Xpcom.Initialize(Path.Combine(xpcomDirectory, "Firefox64"));
            vermeer.XpcomInitialized = true;

            //GeckoPreferences

            //Disable history
            GeckoPreferences.User["places.history.enabled"] = false;
            //Browser useragent
            //Gecko.GeckoPreferences.User["general.useragent.override"] = "Mozilla/5.0 (Windows NT 6.2; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0";
            //Browser caching
            GeckoPreferences.User["browser.cache.disk.enable"] = true;
            GeckoPreferences.User["browser.cache.memory.enable"] = true;
            GeckoPreferences.User["browser.cache.disk.capacity"] = 358400;
            GeckoPreferences.User.SetCharPref("browser.cache.disk.parent_directory", Path.Combine(vermeer.SettingsManager.CacheDataDirectory, "GeckoCache"));
            //Flash plugin
            Gecko.GeckoPreferences.User["plugin.state.flash"] = true;

            GeckoPreferences.User["browser.xul.error_pages.enabled"] = true;
            GeckoPreferences.User["javascript.enabled"] = true;
            GeckoPreferences.User["gfx.font_rendering.graphite.enabled"] = true;
            GeckoPreferences.User["full-screen-api.enabled"] = true;

            //Initialize the web browser comp
            webBrowser = new GeckoWebBrowser { Dock = DockStyle.Fill };

            //Browser Events
            webBrowser.DocumentTitleChanged += (obj, args) =>
            {
                DefaultVermeerVars vermeerVars = new DefaultVermeerVars(this, vermeerEngine.GetBrowserInstance(this));
                OnDocumentTitleChange.Invoke(this, new DocumentTitleChange { DocumentTitle = webBrowser.DocumentTitle, VermeerVars = vermeerVars });
                OnDocumentURLChange.Invoke(this, new DocumentURLChange { DocumentURL = webBrowser.Url.ToString(), VermeerVars = vermeerVars });
                OnDocumentLoadChange?.Invoke(this, new DocumentLoadingChange { Status = true, VermeerVars = vermeerVars });
            };
            webBrowser.DocumentCompleted += (obj, args) =>
            {
                _currentURL = args.Uri.OriginalString;
            };

            //Navigate
            webBrowser.Navigate(URL);
        }

        #endregion CreateBrowserHandle

        #region GetBrowserControl

        public Control GetBrowserControl()
        { return webBrowser; }

        #endregion GetBrowserControl

        #region GetTabPage

        public MaterialTabPage getTabPage()
        { return hostTabPage; }

        #endregion GetTabPage

        #region GoBack

        public void GoBack()
        { if (webBrowser.CanGoBack) webBrowser.GoBack(); }

        #endregion GoBack

        #region GoForward

        public void GoForward()
        { if (webBrowser.CanGoForward) webBrowser.GoForward(); }

        #endregion GoForward

        #region IsBackEnabled

        public bool IsBackEnabled()
        { return webBrowser.CanGoBack; }

        #endregion IsBackEnabled

        #region IsForwardEnabled

        public bool IsForwardAvailable()
        { return webBrowser.CanGoForward; }

        #endregion IsForwardEnabled

        #region WebBrowserNavigate

        public void Navigate(string URL)
        { webBrowser.Navigate(URL); }

        #endregion WebBrowserNagivate

        #region On Initialization

        public void OnInit(MaterialTabPage page, string StartURL, string ProxyURI)
        {
            //Sets the host tab page
            hostTabPage = page;

            CreateBrowserHandle(StartURL, page);
            
            if (ProxyURI != null) { vermeer.ApplicationLogger.AddToLog("WARN", "Vermeer currently doesn't support GeckoFX proxy support!"); }
        }

        #endregion On Initialization

        #region Reload

        public void Reload()
        {
            webBrowser.Reload();
        }

        #endregion Reload

        #region SetProxyConnection

        public void SetProxyConnection(string ProxyURI)
        {
            
        }

        #endregion SetProxyConnection

        #region Delete Cookies

        public void DeleteCookies()
        {
            nsICookieManager GeckoCookieManager;
            GeckoCookieManager = Xpcom.GetService<nsICookieManager>("@mozilla.org/cookiemanager;1");
            GeckoCookieManager = Xpcom.QueryInterface<nsICookieManager>(GeckoCookieManager);
            GeckoCookieManager.RemoveAll();

        }

        public void ReloadPage()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
