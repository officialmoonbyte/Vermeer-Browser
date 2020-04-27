using Moonbyte.Vermeer.bin;
using System;
using System.Windows.Forms;
using Vermeer.Vermeer.bin;
using Vermeer.Vermeer.bin.Cefsharp;

namespace Vermeer.Vermeer.pages
{
    public partial class CertError : Form
    {

        #region Vars

        CefBrowserInterface BrowserInterface;
        string SiteURL;

        #endregion Vars
        public CertError(CefBrowserInterface browserInterface, string siteURL)
        {
            BrowserInterface = browserInterface;
            SiteURL = siteURL;

            InitializeComponent();
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            IBrowser.RemoveDisplayedForm(BrowserInterface.getTabPage());

            vermeer.IgnoredSSLErrorSites.Add(SiteURL.ToLower());
            BrowserInterface.Navigate(SiteURL);

            this.Close();
            this.Dispose();
        }

        private void CertError_Load(object sender, EventArgs e)
        {

        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            IBrowser.RemoveDisplayedForm(BrowserInterface.getTabPage());
            BrowserInterface.ReloadPage();
            this.Close();
            this.Dispose();
        }
    }
}
