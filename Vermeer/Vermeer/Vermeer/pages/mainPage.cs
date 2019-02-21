using IndieGoat.MaterialFramework.Controls;
using Moonbyte.Vermeer.bin;
using System;
using System.Windows.Forms;
using System.Drawing;
using Vermeer.Vermeer.bin;
using IndieGoat.MaterialFramework.Events;

namespace Vermeer.Vermeer.pages
{
    public partial class mainPage : MaterialForm
    {

        #region Vars

        int headerHeight;

        #endregion

        public mainPage()
        {
            InitializeComponent();
        }

        #region Form Methods

        #region Form Closed

        private void mainPage_FormClosed(object sender, FormClosedEventArgs e)
        { if (Application.OpenForms.Count == 0) { vermeer.Close(); } }

        #endregion

        #region Form Load

        private void mainPage_Load(object sender, EventArgs e)
        {
            //Changing the form Properties
            this.HeaderHeight = 33;

            //Renders Form UI
            RenderHeaderUI();
            RenderTabControlUI();

            IBrowser.GenerateNewBrowserTab();
        }

        #endregion

        #endregion

        #region Initializing GUI

        #region Render Header UI

        /// <summary>
        /// Creates a new tab header and adds it to the form
        /// </summary>
        private void RenderHeaderUI()
        {
            //Initializing TabHeader
            TabHeader tabHeader = new TabHeader();

            //Changing TabHeader Properties
            tabHeader.EnableAddButton = true;
            tabHeader.ShowCloseButton = true;
            tabHeader.Location = new Point(33, 1); //33 for perfect 32 square. 1 point for the border
            tabHeader.Width = this.Width - 211; //Random number accounted for the border and the min, max, and close button
            tabHeader.BackColor = Color.FromArgb(35, 35, 64);
            tabHeader.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            tabHeader.BasedTabControl = vermeer.baseTabControl;
            tabHeader.CloseButtonHoverColor = Color.FromArgb(255, 90, 90);
            tabHeader.NewTabButtonClick += (obj, arg) =>
            {
                IBrowser.GenerateNewBrowserTab(arg.NewTabpage);
            };

            headerHeight = tabHeader.Height;

            //Adds the tabHeader to the form
            this.Controls.Add(tabHeader);
        }

        #endregion

        #region Render TabControl UI

        /// <summary>
        /// Gets the main baseTabControl and adds it to the form
        /// </summary>
        private void RenderTabControlUI()
        {
            //Sets yModifier
            int yModifier = headerHeight + 1;

            //Change the properties of the tabControl
            vermeer.baseTabControl.Location = new Point(1, yModifier);
            vermeer.baseTabControl.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            vermeer.baseTabControl.Size = new Size(this.Width - 2, this.Height - yModifier - 1); //Random numbers are indicated border width's
            vermeer.baseTabControl.ControlRemoved += (obj, args) =>
            { if (vermeer.baseTabControl.Controls.Count == 0) this.Close(); };

            //Adds the control
            this.Controls.Add(vermeer.baseTabControl);
        }

        #endregion

        #endregion

    }
}
