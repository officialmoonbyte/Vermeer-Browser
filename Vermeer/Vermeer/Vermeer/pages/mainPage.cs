using Moonbyte.MaterialFramework.Controls;
using Moonbyte.Vermeer.bin;
using System;
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

        public mainPage(MaterialTabPage DraggedPage = null)
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
            Timer tabControlTimer = new Timer();
            tabControlTimer.Interval = 20; int trackTabTimerTick = 0;
            tabControlTimer.Tick += (obj, args) => { if (tabControl.TabPages.Count == 0) { this.Close(); }
            if (trackTabTimerTick >= 20) { trackTabTimerTick = 0; tabControlTimer.Stop(); } else { trackTabTimerTick++; } };
            tabControl.ControlRemoved += (obj, args) => { tabControlTimer.Start(); };

            this.Controls.Add(tabControl);

            //
            // TabHeader
            //
            tabHeader = new TabHeader();
            tabHeader.EnableNewTabButton = true;
            tabHeader.EnableArrowButton = true;
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
            tabHeader.TabDragOut += (obj, args) =>
            {
                TabDragOutEventArgs realArgs = (TabDragOutEventArgs)args;

                mainPage page = new mainPage(realArgs.DraggedTab);
                page.Show();
                page.Location = MousePosition;
            };
            this.Controls.Add(tabHeader);

            //
            // TabPage
            //
            MaterialTabPage browserPage;
            if (DraggedPage != null) { browserPage = DraggedPage; }
            else { browserPage = IBrowser.GenerateNewBrowserTab(); }
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
