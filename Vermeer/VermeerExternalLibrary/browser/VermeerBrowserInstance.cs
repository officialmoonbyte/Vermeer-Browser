using System;
using System.Drawing;
using System.Windows.Forms;

namespace Moonbyte.Vermeer.browser
{
    public class VermeerBrowserInstance : UserControl
    {
        #region Vars

        public VermeerBrowserInterface BrowserInterface = null;

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
            Control control = browserInterface.GetBrowserControl();

            //Setting the BrowserControl Properties
            control.Size = this.Size;
            control.Location = new Point(0, 0);
            control.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);

            //Changing events
            this.Resize += (obj, args) =>
            {
                control.Size = this.Size;
            };

            //Adds the control
            this.Controls.Add(control);

        }

        #endregion

        #region Change Interface

        public void ChangeInterface(VermeerBrowserInterface newInterface)
        {
            if (newInterface == null)
            { return; }

            Control oldBrowserControl = this.Controls[0];
            this.Controls.Remove(oldBrowserControl);
            oldBrowserControl = null;
            BrowserInterface = null;

            BrowserInterface = newInterface;

            Control control = BrowserInterface.GetBrowserControl();

            control.Size = this.Size;
            control.Location = new Point(0, 0);
            control.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);

            //Changing events
            this.Resize += (obj, args) =>
            {
                control.Size = this.Size;
            };

            //Adds the control
            this.Controls.Add(control);
        }

        #endregion ChangeInterface

        #region Methods

        public void ChangeSSLStatus(bool Status)
        {

        }

        #endregion
    }
}
