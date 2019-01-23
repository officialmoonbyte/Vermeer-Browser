using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using IndieGoat.MaterialFramework.Controls;
using Moonbyte.Vermeer.browser;

namespace Vermeer.Vermeer.Engine.DefaultEngine
{
    public class DefaultBrowserEngine : VermeerBrowserInterface
    {

        #region Vars

        ChromiumWebBrowser webBrowser = null;
        MaterialTabPage MainTabPage = null;

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
        public MaterialTabPage getTabPage() { return MainTabPage; }

        #endregion

        #region Initialize

        public void CreateBrowserHandle(string URL, MaterialTabPage tabPage)
        {
            //Sets the default TabPage
            MainTabPage = tabPage;

            //Initialize the new browser
            webBrowser = new ChromiumWebBrowser(URL);

            //Setting all the events of the browser
            webBrowser.TitleChanged += (obj, args) =>
            {
                //Valuating event args
                TitleChangedEventArgs arg = (TitleChangedEventArgs)args;

                //Invoke OnTitleChanged
                OnTitleChange?.Invoke(this, new DocumentTitleChange { DocumentTitle = arg.Title });
            };
            webBrowser.AddressChanged += (obj, args) =>
            {
                //Valuating event args
                AddressChangedEventArgs arg = (AddressChangedEventArgs)args;

                //Invoke OnDocumentURLChange
                OnDocumentURLChange?.Invoke(this, new DocumentURLChange { DocumentURL = arg.Address });
            };
        }

        #endregion

        #region Browser Controls

        public void GoBack() { webBrowser.GetBrowser().GoBack(); }
        public void GoForward() { webBrowser.GetBrowser().GoForward(); }
        public void Navigate(string URL) { webBrowser.Load(URL); }

        #endregion

    }
}
