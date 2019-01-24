using IndieGoat.MaterialFramework.Controls;
using Moonbyte.Vermeer.bin;
using Moonbyte.Vermeer.browser;
using System.Drawing;
using System.Windows.Forms;
using Vermeer.Vermeer.Controls;

namespace Vermeer.Vermeer.bin
{ 
    public static class IBrowser
    {

        #region MaterialTabPage

        public static void GenerateNewBrowserTab()
        {
            MaterialTabPage browserPage = new MaterialTabPage();

            browserPage.BackColor = Color.White;

            RenderBrowserUI(browserPage);
            RenderHeaderUI(browserPage);

            vermeer.baseTabControl.TabPages.Add(browserPage);
        }

        #endregion

        #region Header

        private static void RenderHeaderUI(MaterialTabPage mainPage)
        {
            // ** Back Button ** //
            BackButton backButton = new BackButton();
            backButton.Location = new Point(0, 0);
            backButton.Click += (obj, args) =>
            {

            };
            mainPage.Controls.Add(backButton);

            // ** Forward Button ** //
            ForwardButton forwardButton = new ForwardButton();
            forwardButton.Location = new Point(32, 0);
            forwardButton.Click += (obj, args) =>
            {

            };
            mainPage.Controls.Add(forwardButton);

            // ** Reload Button ** //
            ReloadButton reloadButton = new ReloadButton();
            reloadButton.Location = new Point(64, 0);
            reloadButton.Click += (obj, args) =>
            {

            };
            mainPage.Controls.Add(reloadButton);

            // ** SearchBar ** //

            MaterialTextBox searchBar = new MaterialTextBox();
            searchBar.Location = new Point(86 + 12, 6);
            searchBar.Font = new Font("Segoe UI", 12f);
            searchBar.Text = "";
            searchBar.Width = mainPage.Width - 86 - 64;

            searchBar.BackColor = Color.White;
            searchBar.BorderColor = Color.FromArgb(236, 236, 236);
            searchBar.BottomBorderColor = Color.FromArgb(236, 236, 236);

            searchBar.baseControl.KeyDown += (obj, args) =>
            {

            };
            mainPage.Controls.Add(searchBar);

            // ** Design Timer ** //
            DesignTimer designTimer = new DesignTimer(mainPage, ReturnBrowserInstance(mainPage));
            VermeerBrowserInstance instance = ReturnBrowserInstance(mainPage);
            instance.BrowserInterface.OnDocumentIconChange += (obj, args) =>
            {
                DocumentIconChange e = args;
                instance.BrowserInterface.getTabPage().ChangeTabIcon(e.icon); vermeer.ApplicationLogger.AddToLog("INFO", "Changed Tab Icon");
            };



        }

        #endregion

        #region Browser Comp

        private static void RenderBrowserUI(MaterialTabPage mainPage)
        {
            vermeer.DefaultBrowserEngine browserEngine = new vermeer.DefaultBrowserEngine();
            browserEngine.CreateBrowserHandle("https://google.com", mainPage);

            VermeerBrowserInstance browserInstance = new VermeerBrowserInstance(browserEngine);

            browserInstance.Location = new Point(0, 32);
            browserInstance.Size = new Size(mainPage.Width, mainPage.Height - 32);

            mainPage.Controls.Add(browserInstance);
        }

        #endregion

        #region Getting Usercontrols

        /// <summary>
        /// Gets the Panel of a MaterialTabPage
        /// </summary>
        public static VermeerBrowserInstance ReturnBrowserInstance(MaterialTabPage mainPage)
        {
            //Initialize the return panel
            VermeerBrowserInstance returnPanel = null;

            //Gets Panel control on the TabPage
            foreach(Control userControl in mainPage.Controls)
            { if (userControl is VermeerBrowserInstance) { returnPanel = (VermeerBrowserInstance)userControl; } }

            //Returns the panel
            if (returnPanel == null) { vermeer.ApplicationLogger.AddToLog("WARN", "TabPanel was not found!"); return null; } else { return returnPanel; }
        }


        #endregion

    }
}
