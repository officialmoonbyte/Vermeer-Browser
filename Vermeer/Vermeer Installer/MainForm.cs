using IWshRuntimeLibrary;
using Moonbyte.MaterialFramework.Controls;
using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace Vermeer_Installer
{
    public partial class MainForm : MaterialForm
    {

        #region Vars

        public string DefaultInstallDirectory = @"C:\Program Files\Vermeer";
        public string DesktopDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public string StartMenuDirectory = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
        public string TempDirectory = Path.Combine(Path.GetTempPath(), "Moonbyte", "Vermeer");
        public string TempFile;

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
            pbg_DownloadProgressBar.UpdateOpacityColor();
            pbox_InstallImage.UpdateOpacityColor();

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
            pbg_DownloadProgressBar.Opacity = 255;
            pbox_InstallImage.Opacity = 255;

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
            btn_Continue2.Enabled = false;
            btn_Continue2.Click += (obj, args) =>
            {
                SwitchToPage2();
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
                    btn_Continue2.Enabled = true;
                }

                tick++;
            };

            timer.Start();
        }

        #endregion SwitchToPage1

        #region SwitchToPage2

        public void SwitchToPage2()
        { FadePage1(); }

        private void FadePage1()
        {
            Timer timer = new Timer();
            timer.Interval = 16;
            btn_Continue.Enabled = false;

            txt_InstallDirectory.Visible = false;

            int tick = 0; timer.Tick += (obj, args) =>
            {

                int op = tick * 16;

                if (op > 255) op = 255;

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

                if (op >= 255)
                {
                    timer.Stop();
                    BringUpPage2();
                }

                tick++;
            };

            timer.Start();
        }

        private void BringUpPage2()
        {
            pnl_Page2.Location = new Point(1, 32);

            Timer timer = new Timer();
            timer.Interval = 16;
            int tick = 0; timer.Tick += (obj, args) =>
            {
                int op = 255 - (tick * 16);

                if (op < 0) op = 0;

                lbl_DownloadTitle.Opacity = op;
                lbl_DownloadedStatus.Opacity = op;
                pbg_DownloadProgressBar.Opacity = op;
                pbox_InstallImage.Opacity = op;

                if (op <= 0)
                {
                    InitializeDownload();
                    timer.Stop();
                }

                tick++;
            };

            timer.Start();
        }

        #endregion SwitchToPage2

        #region Center Object
        private void CenterObject(Control _object)
        {
            int formWidth = this.Width;
            int pos = (formWidth - _object.Width) / 2;
            _object.Location = new Point(pos, _object.Location.Y);
        }

        #endregion Center Object

        #region Download

        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }

        private void InitializeDownload()
        {
            if (!Directory.Exists(TempDirectory)) Directory.CreateDirectory(TempDirectory);
            if (!Directory.Exists(txt_InstallDirectory.Text)) Directory.CreateDirectory(txt_InstallDirectory.Text);
            TempFile = Path.Combine(TempDirectory, "Vermeer.zip");
            if (System.IO.File.Exists(TempFile)) System.IO.File.Delete(TempFile);

            WebClient client = new WebClient();
            client.DownloadProgressChanged += (obj, args) =>
            {
                pbg_DownloadProgressBar.Value = args.ProgressPercentage;
                lbl_DownloadedStatus.Text = "Downloading " + FormatBytes(args.BytesReceived) + " of " + FormatBytes(args.TotalBytesToReceive);
            };

            client.DownloadFileCompleted += (obj, args) =>
            {
                lbl_DownloadedStatus.Text = "Extracting Vermeer! Please wait...";
                ZipFile.ExtractToDirectory(TempFile, Path.Combine(txt_InstallDirectory.Text, "Vermeer"));
                lbl_DownloadedStatus.Text = "Creating Shortcuts...";
                CreateShortcut(Path.Combine(txt_InstallDirectory.Text, "Vermeer"), DesktopDirectory);
                CreateShortcut(Path.Combine(txt_InstallDirectory.Text, "Vermeer"), StartMenuDirectory);
            };

            client.DownloadFileAsync(new Uri("https://moonbyte.net/download/vermeer/vermeer.zip"), TempFile);

        }

        #endregion Download

        #region CreateShortcut

        private void CreateShortcut(string ExeDirectory, string ShortcutDirectory)
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = Path.Combine(ShortcutDirectory, "Vermeer.lnk");
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "Vermeer Browser made by Moonbyte Corporation";
            shortcut.IconLocation = Path.Combine(ExeDirectory, "icon.ico");
            shortcut.TargetPath =  Path.Combine(ExeDirectory, "vermeer.exe");
            shortcut.Save();
        }

        #endregion CreateShortcut

    }
}
