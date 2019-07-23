using IndieGoat.MaterialFramework.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace Vermeer_Installer.Controls
{
    public class DownloadUI : UserControl
    {
        #region Vars - All vars labeled with _ is not supposed to change.

        #region Labels

        MaterialLabel _DownloadTitle;

        MaterialProgressBar DownloadProgressBar;

        #endregion Labels

        #region Fonts

        Font MainFont;
        Font MainFont_Bold;

        #endregion

        #endregion Vars

        #region Initialization

        public DownloadUI()
        {
            // Download UI //
            this.Size = new Size(398, 100);

            // Initialize Fonts //
            MainFont = new Font("Segoe UI", 9f, FontStyle.Regular);
            MainFont_Bold= new Font("Segoe UI", 9f, FontStyle.Bold);

            // DownloadProgressBar //
            DownloadProgressBar = new MaterialProgressBar();
            DownloadProgressBar.Size = new Size(394, 24);
            DownloadProgressBar.Location = new Point(2, 74);

            DownloadProgressBar.BackColor = Color.FromArgb(250, 250, 250);
            DownloadProgressBar.BorderColor = Color.FromArgb(235, 235, 235);

            this.Controls.Add(DownloadProgressBar);

            // Download Title //
            _DownloadTitle = new MaterialLabel();
            _DownloadTitle.Font = MainFont_Bold;
            _DownloadTitle.Text = "Download Progress";

            int downloadTitle_X = 0;
            int downloadTitle_Y = 0;
            _DownloadTitle.Location = new Point(downloadTitle_X, downloadTitle_Y);

            this.Controls.Add(_DownloadTitle);

        }

        #endregion Initialization

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            //Initialize graphics control
            Graphics g = e.Graphics;

            //Draw the backcolor of the control
            g.Clear(Color.FromArgb(250, 250, 250));

            base.OnPaint(e);
        }

        #endregion OnPaint
    }
}
