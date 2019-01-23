using System;
using System.Drawing;
using System.Windows.Forms;

namespace Moonbyte.Vermeer.browser
{
    public class VermeerBrowserInstance : UserControl
    {
        #region Vars

        VermeerBrowserInterface BrowserInterface = null;

        #endregion

        #region Startup

        /// <summary>
        /// Initialize the VermeerBrowserInstance
        /// </summary>
        public VermeerBrowserInstance(VermeerBrowserInterface browserInterface)
        {
            //Error logging for null
            if (browserInterface == null)
            { Console.WriteLine("VermeerBrowserInstance started with a null interface."); }

            //Sets the browser interface
            BrowserInterface = browserInterface;

            //Gets the Browser Control
            Control control = BrowserInterface.GetBrowserControl();

            //Setting the BrowserControl Properties
            control.Size = this.Size;
            control.Location = new Point(0, 0);
            control.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);

            //Adds the control
            this.Controls.Add(control);
        }

        #endregion
    }
}
