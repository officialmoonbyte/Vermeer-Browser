using IndieGoat.MaterialFramework.Controls;
using Moonbyte.Vermeer.bin;
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

    }
}
