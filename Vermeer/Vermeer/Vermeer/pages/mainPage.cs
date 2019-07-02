using IndieGoat.MaterialFramework.Controls;
using MaterialFramework.Controls;
using Moonbyte.Vermeer.bin;
using Moonbyte.Vermeer.browser;
using System.Drawing;
using System.IO;
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

            //Only perform layout when control has completly finished resizing
            ResizeBegin += (s, e) => SuspendLayout();
            ResizeEnd += (s, e) => ResumeLayout(true);

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
            this.closebutton.FontColor = Color.White;
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
            tabHeader.EnableNewTabButton = true;
            tabHeader.EnableArrowButton = false;
            tabHeader.EnableCloseButton = true;
            tabHeader.Location = new System.Drawing.Point(33, 1);
            tabHeader.Width = this.Width - 211;
            tabHeader.BackColor = Color.FromArgb(35, 35, 64);
            tabHeader.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            tabHeader.BasedTabControl = tabControl;
            tabHeader.NewTabButtonClick += (obj, args) =>
            {
                MaterialTabPage page = args.NewTabPage;
                IBrowser.GenerateNewBrowserTab(page);
            };
            tabHeader.MouseMove += (obj, args) => {
                if (tabHeader.MouseOverRect() == false && args.Button == MouseButtons.Left)
                { this.MouseMoveExternal(true, true); }
            };
            this.Controls.Add(tabHeader);

            //
            // TabPage
            //
            MaterialTabPage browserPage = IBrowser.GenerateNewBrowserTab();
            tabControl.TabPages.Add(browserPage);

            //
            // Deletes BlobStorage Folder
            //
            if (Directory.Exists(Application.StartupPath + @"\blob_storage")) { Directory.Delete(Application.StartupPath + @"\blob_storage", true); }

        }

        #endregion Page Initialization

        private void mainPage_Load(object sender, System.EventArgs e)
        {
            
        }
    }
}
