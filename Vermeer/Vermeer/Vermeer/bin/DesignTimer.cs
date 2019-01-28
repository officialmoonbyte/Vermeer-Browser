using IndieGoat.MaterialFramework.Controls;
using Moonbyte.Vermeer.browser;
using System.Drawing;
using System.Windows.Forms;

namespace Vermeer.Vermeer.bin
{

    /// <summary>
    /// Used to keep all GUI elemets smooth
    /// </summary>
    public class DesignTimer
    {
        public DesignTimer(MaterialTabPage mainPage, VermeerBrowserInstance instance)
        {
            Timer designTimer = new Timer();
            designTimer.Tick += (obj, args) =>
            {
                mainPage.Text = instance.BrowserInterface.GetCurrentTitle();
                instance.Size = new Size(mainPage.Width, mainPage.Height - 32);

                foreach (Control c in mainPage.Controls)
                {
                    if (c is MaterialTextBox)
                    {
                        MaterialTextBox searchBar = (MaterialTextBox)c;

                        searchBar.Text = instance.BrowserInterface.GetCurrentURL();
                        searchBar.Width = (mainPage.Width - (32 * 4) - 64);
                    }
                }
            };
            designTimer.Start();
        }
    }
}
