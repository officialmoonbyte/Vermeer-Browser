using IndieGoat.MaterialFramework.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Moonbyte.Vermeer.browser
{
    public interface VermeerBrowserInterface
    {
        /* Default / required browser events */
        event EventHandler<DocumentTitleChange> OnTitleChange;
        event EventHandler<DocumentURLChange> OnDocumentURLChange;
        event EventHandler<DocumentIconChange> OnDocumentIconChange;
        event EventHandler<DocumentLoadingChange> OnDocumentLoadChange;

        /* Default / required Browser Properties */
        Control GetBrowserControl();
        void OnInit(MaterialTabPage page, string StartURL, string ProxyURI);
        bool IsBackEnabled();
        bool IsForwardAvailable();
        MaterialTabPage getTabPage();
        

        /* Initialize */
        void CreateBrowserHandle(string URL, MaterialTabPage tabPage);


        /* Default / required Browser controlls */
        void GoBack();
        void GoForward();
        void Reload();
        void Navigate(string URL);
        void SetProxyConnection(string ProxyURI);
        void DeleteCookies();
    }

    public class DocumentTitleChange : EventArgs
    {
        public string DocumentTitle;
        public DefaultVermeerVars VermeerVars;
    }
    public class DocumentLoadingChange : EventArgs
    {
        public bool Status;
        public DefaultVermeerVars VermeerVars;
    }
    public class DocumentURLChange : EventArgs
    {
        public string DocumentURL;
        public DefaultVermeerVars VermeerVars;
    }
    public class DocumentIconChange : EventArgs
    {
        public Image icon;
        public DefaultVermeerVars VermeerVars;
    }

    public class DefaultVermeerVars
    {
        public DefaultVermeerVars(VermeerBrowserInterface _Interface, VermeerBrowserInstance _Instance)
        {
            this.Interface = _Interface;
            this.Instance = _Instance;
        }

        public VermeerBrowserInterface Interface;
        public VermeerBrowserInstance Instance;
    }

    public class vermeerEngine
    {
        public static VermeerBrowserInstance GetBrowserInstance(VermeerBrowserInterface browserInterface)
        { return (VermeerBrowserInstance)browserInterface.GetBrowserControl().Parent; }
        public static void AddHistoryObject(string WebTitle, string WebURL)
        { }
    }
}
