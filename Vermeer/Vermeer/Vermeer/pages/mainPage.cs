using IndieGoat.MaterialFramework.Controls;
using MaterialFramework.Controls;
using Moonbyte.Vermeer.bin;
using Moonbyte.Vermeer.browser;
using System.Drawing;
using System.Windows.Forms;
using Vermeer.Vermeer.bin;

namespace Vermeer.Vermeer.pages
{
    public partial class mainPage : MaterialForm
    {

        #region Vars

        MaterialTabControl tabControl;
        TabHeader tabHeader;

        #endregion Vars

        #region Page Initialization

        public mainPage()
        {
            InitializeComponent();

            //Setting form events
            this.FormClosed += (obj, args) =>
            { if (Application.OpenForms.Count == 0) { vermeer.Close(); } };

            //Initialize the UI Object
            vermeer.UIThread = new Control();

            //
            //mainPage
            //
            this.ShowIcon = false;
            this.ShowTitle = false;
            this.HeaderColor = Color.FromArgb(35, 35, 64);
            this.HeaderHeight = 33;

            //
            // TabControl
            //
            tabControl = new MaterialTabControl();
            tabControl.Location = new Point(1, 33);
            tabControl.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            tabControl.Size = new Size(this.Width - 2, this.Height - 33 - 1);
            tabControl.MouseMove += (obj, args) => { if (args.Button == MouseButtons.Left) { this.MouseMoveExternal(true); } else { this.MouseMoveExternal(false); } };
            tabControl.MouseDown += (obj, args) => { if (args.Button == MouseButtons.Left) { this.MouseDownExternal(true); } else { this.MouseDownExternal(false); } };
            tabControl.MouseUp += (obj, args) => { this.MouseUpExternal(); };
            tabControl.ControlRemoved += (obj, args) => { if (tabControl.TabPages.Count == 1) { this.Close(); } };

            this.Controls.Add(tabControl);

            //
            // TabHeader
            //
            tabHeader = new TabHeader();
            tabHeader.EnableAddButton = true;
            tabHeader.ShowCloseButton = true;
            tabHeader.Location = new System.Drawing.Point(33, 1);
            tabHeader.Width = this.Width - 211;
            tabHeader.BackColor = Color.FromArgb(35, 35, 64);
            tabHeader.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            tabHeader.BasedTabControl = tabControl;
            tabHeader.CloseButtonHoverColor = Color.FromArgb(255, 90, 90);
            tabHeader.NewTabButtonClick += (obj, args) =>
            {
                MaterialTabPage page = args.NewTabpage;
                IBrowser.GenerateNewBrowserTab(page);
            };
            tabHeader.MouseMove += (obj, args) => { if (args.Button == MouseButtons.Left && !tabHeader.IsMouseOverRectangle()) { this.MouseMoveExternal(true); } else { this.MouseMoveExternal(false); } };
            
            this.Controls.Add(tabHeader);

            //
            // TabPage
            //
            MaterialTabPage browserPage = IBrowser.GenerateNewBrowserTab();
            tabControl.TabPages.Add(browserPage);

        }

        #endregion Page Initialization

        private void mainPage_Load(object sender, System.EventArgs e)
        {
            
        }
    }
}
