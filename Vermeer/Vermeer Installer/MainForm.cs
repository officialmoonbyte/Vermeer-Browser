using Moonbyte.MaterialFramework.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace Vermeer_Installer
{
    public partial class MainForm : MaterialForm
    {

        #region Vars

        public string DefaultInstallDirectory = @"C:\Program Files\Vermeer";

        #endregion Vars

        #region Initialization

        public MainForm()
        {
            // Initialize the form and form controls
            InitializeComponent();

            pbox_logo.UpdateOpacityColor();
            lbl_CompanyName.UpdateOpacityColor();
            lbl_Welcome.UpdateOpacityColor();
            lbl_ProductName.UpdateOpacityColor();
            btn_Continue.UpdateOpacityColor();
            lbl_EULA.UpdateOpacityColor();
            lbl_EULA2.UpdateOpacityColor();
            lbl_Page2_Title.UpdateOpacityColor();
            lbl_Page2_Desc.UpdateOpacityColor();
            lbl_ShortcutTitle.UpdateOpacityColor();
            checkbox_Desktop.UpdateOpacityColor();
            checkbox_StartMenu.UpdateOpacityColor();
            lbl_StartMenuTitle.UpdateOpacityColor();
            lbl_DesktopTitle.UpdateOpacityColor();
            lbl_InstallDirectoryTitle.UpdateOpacityColor();
            btn_SelectInstallDirectory.UpdateOpacityColor();
            btn_ConnectVermeerAccount.UpdateOpacityColor();
            btn_Continue2.UpdateOpacityColor();
            lbl_VermeerAccount.UpdateOpacityColor();
            lbl_DownloadTitle.UpdateOpacityColor();
            lbl_DownloadedStatus.UpdateOpacityColor();
            lbl_TimeLeft.UpdateOpacityColor();
            pbg_DownloadProgressBar.UpdateOpacityColor();

            pbox_logo.Opacity = 255;
            lbl_CompanyName.Opacity = 255;
            lbl_Welcome.Opacity = 255;
            lbl_ProductName.Opacity = 255;
            btn_Continue.Opacity = 255;
            lbl_EULA.Opacity = 255;
            lbl_EULA2.Opacity = 255;
            lbl_Page2_Title.Opacity = 255;
            lbl_Page2_Desc.Opacity = 255;
            lbl_ShortcutTitle.Opacity = 255;
            checkbox_Desktop.Opacity = 255;
            checkbox_StartMenu.Opacity = 255;
            lbl_StartMenuTitle.Opacity = 255;
            lbl_DesktopTitle.Opacity = 255;
            lbl_InstallDirectoryTitle.Opacity = 255;
            btn_SelectInstallDirectory.Opacity = 255;
            btn_ConnectVermeerAccount.Opacity = 255;
            btn_Continue2.Opacity = 255;
            lbl_VermeerAccount.Opacity = 255;
            lbl_DownloadTitle.Opacity = 255;
            lbl_DownloadedStatus.Opacity = 255;
            lbl_TimeLeft.Opacity = 255;
            pbg_DownloadProgressBar.Opacity = 255;

            //Center Objects
            CenterObject(pnl_Title);
            CenterObject(lbl_ProductName);
            CenterObject(lbl_Welcome);
            CenterObject(btn_Continue);
            CenterObject(pnl_EULA);
            CenterObject(lbl_Page2_Desc);
            CenterObject(lbl_Page2_Title);
            CenterObject(pnl_InstallDirectory);
            CenterObject(pnl_Shortcut);
            CenterObject(pnl_VermeerAccount);
            CenterObject(btn_Continue2);
            CenterObject(pnl_DownloadProgress);

            txt_InstallDirectory.Text = DefaultInstallDirectory;
            checkbox_Desktop.Checked = true;
            checkbox_StartMenu.Checked = true;

            btn_Continue.Enabled = false;
            btn_Continue.Click += (obj, args) =>
            {
                SwitchToPage1();
            };

            BringUpPage0();

        }

        #endregion Initialization

        #region SwitchToPage0

        public void SwitchToPage0()
        { BringUpPage0(); }

        private void BringUpPage0()
        {
            pnl_Page0.Location = new Point(1, 32);

            Timer timer = new Timer();
            timer.Interval = 16;
            int tick = 0; timer.Tick += (obj, args) =>
            {
                int op = 255 - (tick * 16);

                if (op < 0) op = 0;

                pbox_logo.Opacity = op;
                lbl_CompanyName.Opacity = op;
                lbl_Welcome.Opacity = op;
                lbl_ProductName.Opacity = op;
                btn_Continue.Opacity = op;
                lbl_EULA.Opacity = op;
                lbl_EULA2.Opacity = op;

                if (op <= 0)
                {
                    timer.Stop();
                    btn_Continue.Enabled = true;
                }

                tick++;
            };

            timer.Start();
        }

        #endregion SwitchToPage0

        #region SwitchToPage1

        public void SwitchToPage1()
        { FadePage0(); }

        private void FadePage0()
        {
            Timer timer = new Timer();
            timer.Interval = 16;
            btn_Continue.Enabled = false;
            int tick = 0; timer.Tick += (obj, args) =>
            {

                int op = tick * 16;

                if (op > 255) op = 255;

                pbox_logo.Opacity = op;
                lbl_CompanyName.Opacity = op;
                lbl_Welcome.Opacity = op;
                lbl_ProductName.Opacity = op;
                btn_Continue.Opacity = op;
                lbl_EULA.Opacity = op;
                lbl_EULA2.Opacity = op;

                if (op >= 255)
                {
                    timer.Stop();
                    BringUpPage1();
                }

                tick++;
            };

            timer.Start();
        }

        private void BringUpPage1()
        {
            pnl_Page1.Location = new Point(1, 32);

            Timer timer = new Timer();
            timer.Interval = 16;
            int tick = 0; timer.Tick += (obj, args) =>
            {
                int op = 255 - (tick * 16);

                if (op < 0) op = 0;

                lbl_Page2_Title.Opacity = op;
                lbl_Page2_Desc.Opacity = op;
                lbl_ShortcutTitle.Opacity = op;
                //checkbox_Desktop.Opacity = op;
                //checkbox_StartMenu.Opacity = op;
                lbl_StartMenuTitle.Opacity = op;
                lbl_DesktopTitle.Opacity = op;
                lbl_InstallDirectoryTitle.Opacity = op;
                //txt_InstallDirectory.Opacity = op;
                btn_SelectInstallDirectory.Opacity = op;
                btn_ConnectVermeerAccount.Opacity = op;
                btn_Continue2.Opacity = op;
                lbl_VermeerAccount.Opacity = op;

                if (op <= 0)
                {
                    timer.Stop();
                    btn_Continue.Enabled = true;
                }

                tick++;
            };

            timer.Start();
        }

        #endregion SwitchToPage1

        #region Center Object
        private void CenterObject(Control _object)
        {
            int formWidth = this.Width;
            int pos = (formWidth - _object.Width) / 2;
            _object.Location = new Point(pos, _object.Location.Y);
        }

        #endregion Center Object

    }
}
