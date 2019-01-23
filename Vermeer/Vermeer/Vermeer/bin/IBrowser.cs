using IndieGoat.MaterialFramework.Controls;
using Moonbyte.Vermeer.bin;
using Moonbyte.Vermeer.browser;
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

            RenderBrowserUI(browserPage);
            RenderHeaderUI(browserPage);

            vermeer.baseTabControl.TabPages.Add(browserPage);
        }

        #endregion

        #region Header

        private static void RenderHeaderUI(MaterialTabPage mainPage)
        {

        }

        #endregion

        #region Browser Comp

        private static void RenderBrowserUI(MaterialTabPage mainPage)
        {

        }

        #endregion

        #region Getting Usercontrols

        /// <summary>
        /// Gets the Panel of a MaterialTabPage
        /// </summary>
        public static VermeerBrowserInstance ReturnTabPanel(MaterialTabPage mainPage)
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
