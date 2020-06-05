using Moonbyte.MaterialFramework.Controls;
using Moonbyte.Vermeer.API;
using Moonbyte.Vermeer.browser;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Moonbyte.Vermeer.BrowserEngine
{
    public class DefaultBrowserInterface : VermeerBrowserInterface
    {

        #region Vars

        MaterialTabPage hostedTabPage;
        WebBrowser webBrowser;

        public string BrowserVersion()
        { return "DEFAULT"; }

        string _currentURL; public string CurrentURL()
        { return _currentURL; }

        bool _firstNavigateCheck = false; public bool FirstNavigateCheck()
        { return _firstNavigateCheck; }
        public void SetFirstNavigateCheck(bool value)
        { _firstNavigateCheck = value; }

        #endregion Vars

        #region Events

        public event EventHandler<DocumentTitleChange> OnDocumentTitleChange;
        public event EventHandler<DocumentURLChange> OnDocumentURLChange;
        public event EventHandler<DocumentIconChange> OnDocumentIconChange;
        public event EventHandler<DocumentLoadingChange> OnDocumentLoadChange;

        #endregion Events

        #region CreateBrowserHandle

        public void CreateBrowserHandle(string URL, MaterialTabPage tabPage)
        {
            webBrowser = new WebBrowser();

            webBrowser.DocumentTitleChanged += (obj, args) =>
            {
                DefaultVermeerVars vermeerVars = new DefaultVermeerVars(this, vermeerEngine.GetBrowserInstance(this));
                OnDocumentTitleChange?.Invoke(this, new DocumentTitleChange { DocumentTitle = webBrowser.DocumentTitle, VermeerVars = vermeerVars });
                OnDocumentLoadChange?.Invoke(this, new DocumentLoadingChange { Status = true, VermeerVars = vermeerVars });
            };
            webBrowser.DocumentCompleted += (obj, args) =>
            {
                _currentURL = args.Url.OriginalString;
                DefaultVermeerVars vermeerVars = new DefaultVermeerVars(this, vermeerEngine.GetBrowserInstance(this));
                OnDocumentURLChange?.Invoke(this, new DocumentURLChange { DocumentURL = webBrowser.Url.OriginalString, VermeerVars = vermeerVars });
            };

            webBrowser.Navigate(URL);
        }

        #endregion CreateBrowserHandle

        #region GetBrowserControl

        public Control GetBrowserControl()
        { return webBrowser; }

        #endregion GetBrowserControl

        #region GetTabPage

        public MaterialTabPage getTabPage()
        { return hostedTabPage; }

        #endregion GetTabPage

        #region GoBack

        public void GoBack()
        { if (webBrowser.CanGoBack) webBrowser.GoBack(); }
        public bool IsBackEnabled()
        { return webBrowser.CanGoBack; }

        #endregion GoBack

        #region GoForward

        public void GoForward()
        { if (webBrowser.CanGoForward) webBrowser.GoForward(); }
        public bool IsForwardAvailable()
        { return webBrowser.CanGoForward; }

        #endregion GoForward

        #region WebBrowserNavigate

        public void Navigate(string URL)
        { webBrowser.Navigate(URL); }

        #endregion WebBrowserNavigate

        #region OnInitialization

        public void OnInit(MaterialTabPage page, string StartURL, string ProxyURI)
        {
            hostedTabPage = page;

            CreateBrowserHandle(StartURL, page);
            if (ProxyURI != null) { VermeerAPI.LogEvent(this, "WARNING", "Internet Explorer Interface does not support TorProxy!"); }
        }

        #endregion OnInitialization

        #region Reload

        public void Reload()
        { webBrowser.Refresh(); }

        public void ReloadPage()
        { webBrowser.Refresh(); }

        #endregion Reload

        #region SetProxyConnection

        public void SetProxyConnection(string ProxyURI)
        {

        }

        #endregion SetProxyConnection

        #region GetBrowserIcon

        public Image GetBrowserIcon()
        {
            var WorkingDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return Image.FromFile(Path.Combine(WorkingDirectory, "resources", "internetexplorer_icon.png"));
        }

        #endregion GetBrowserIcon

        #region Delete Cookies

        public void DeleteCookies()
        { }

        #endregion Delete Cookies

    }
}
