using MaterialFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vermeer_Installer
{
    public partial class Vermeer_Installer : MaterialForm
    {

        #region Vars

        Installer installerObject = new Installer();

        #endregion Vars

        public Vermeer_Installer()
        {
            InitializeComponent();

            //
            // Set label status to the initialize state
            //
            lbl_Status.Text = "Vermeer Installer is currently being initialized rignt now...";

            //
            // Center all important objects on the screen
            //
            CenterObject(this.pnl_MoonbyteLogo);
            CenterObject(this.pgb_Progress);
            CenterObject(this.lbl_Status);
            CenterObject(this.pnl_CreateDesktopShortcut);
            CenterObject(this.pnl_CreateStartMenuShortcut);

            //
            // Set progress bar colors
            //
            pgb_Progress.BackColor = Color.FromArgb(255, 255, 255);
            pgb_Progress.BorderColor = Color.FromArgb(245, 245, 245);

            //
            // Marking shortcut checkbox's true
            //
            cek_DesktopShortcut.Checked = true;
            cek_StartMenu.Checked = true;

            //
            // Initialize Installer
            //
            installerObject.DownloadProgressChanged += (obj, args) =>
            {
                lbl_Status.Text = "Vermeer is currently downloading " + Math.Round(ConvertBytesToMegabytes(args.BytesReceived), 2) + "Mb / " + Math.Round(ConvertBytesToMegabytes(args.TotalBytesToReceive)) + "Mb downloaded.";
                CenterObject(this.lbl_Status);

                pgb_Progress.Value = args.ProgressPercentage;
            };
            installerObject.DownloadComplete += (obj, args) =>
            {
                installerObject.StartExtraction();
            };
            installerObject.ExtractComplete += (obj, args) =>
            {
                Done done = new Done(cek_StartMenu.Checked, cek_DesktopShortcut.Checked, installerObject);
                done.Show();
                this.Hide();
            };
            installerObject.StartDownload();
        }

        #region Convert Bytes

        private double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        #endregion Convert Bytes

        #region CenterObject

        private void CenterObject(Control _Object)
        { decimal newLocation = (((decimal.Divide(_Object.Width, this.Width) - 1) / 2) * this.Width) * -1;
            _Object.Location = new Point(decimal.ToInt32(newLocation), _Object.Location.Y); }

        #endregion CenterObject

    }
}
