using IndieGoat.MaterialFramework.Controls;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Vermeer_Installer.Controls
{
    public class DownloadUI : UserControl
    {
        #region Vars - All vars labeled with _ is not supposed to change.

        #region Labels

        MaterialLabel _MainDownloadTitle;
        MaterialLabel _DownloadTitle;
        MaterialLabel _DownloadProgressPercent;

        MaterialProgressBar DownloadProgressBar;

        #endregion Labels

        #region Fonts

        Font MainFont;
        Font MainFont_Bold;
        Font MainFont_Title;

        #endregion

        #region int

        public int CurrentDownloadPercent = 0;

        #endregion Int

        #endregion Vars

        #region Initialization

        public DownloadUI()
        {
            // Download UI //
            this.Size = new Size(398, 75);
            this.BackColor = Color.FromArgb(51, 170, 255);

            // Initialize Fonts //
            MainFont = new Font("Segoe UI", 9f, FontStyle.Regular);
            MainFont_Bold= new Font("Segoe UI", 9f, FontStyle.Bold);
            MainFont_Title = new Font("Segoe UI", 14f, FontStyle.Regular);

            // DownloadProgressBar //
            DownloadProgressBar = new MaterialProgressBar();
            DownloadProgressBar.Size = new Size(398, 3);
            DownloadProgressBar.Location = new Point(0, 72);
            DownloadProgressBar.Value = 0;

            DownloadProgressBar.BackColor = Color.FromArgb(36, 121, 181);
            DownloadProgressBar.BorderColor = Color.Transparent;
            DownloadProgressBar.ProgressBarColor = Color.FromArgb(111, 220, 111);

            this.Controls.Add(DownloadProgressBar);

            // Main Download Title //
            _MainDownloadTitle = new MaterialLabel();
            _MainDownloadTitle.Font = MainFont_Title;
            _MainDownloadTitle.BackColor = Color.Transparent;
            _MainDownloadTitle.ForeColor = Color.FromArgb(48, 48, 48);
            _MainDownloadTitle.TextAlign = ContentAlignment.MiddleCenter;
            _MainDownloadTitle.Text = "Downloading... Please wait.";
            _MainDownloadTitle.Click += (obj, args) =>
            {
                Console.WriteLine(_MainDownloadTitle.Width);
            };

            this.Controls.Add(_MainDownloadTitle);

            //Download Title//
            _DownloadTitle = new MaterialLabel();
            _DownloadTitle.Font = MainFont;
            _DownloadTitle.BackColor = Color.Transparent;
            _DownloadTitle.ForeColor = Color.FromArgb(48, 48, 48);
            _DownloadTitle.TextAlign = ContentAlignment.MiddleCenter;
            _DownloadTitle.Text = "Download percent at : ";
            _DownloadTitle.Click += (obj, args) =>
            {
                Console.WriteLine(_DownloadTitle.Width);
            };

            this.Controls.Add(_DownloadTitle);

            //Download Progress Percent//
            _DownloadProgressPercent = new MaterialLabel();
            _DownloadProgressPercent.Font = MainFont;
            _DownloadProgressPercent.BackColor = Color.Transparent;
            _DownloadProgressPercent.ForeColor = Color.FromArgb(48, 48, 48);
            _DownloadProgressPercent.TextAlign = ContentAlignment.MiddleCenter;
            _DownloadProgressPercent.Text = "0";
            _DownloadProgressPercent.Click += (obj, args) =>
            {
                Console.WriteLine(_DownloadProgressPercent.Width);
            };

            this.Controls.Add(_DownloadProgressPercent);

            UpdateLabelLocations();
        }

        #endregion Initialization

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            //Initialize graphics control
            Graphics g = e.Graphics;

            //Draw the backcolor of the control
            g.Clear(this.BackColor);

            base.OnPaint(e);
        }

        #endregion OnPaint

        #region UpdateLabelLocations

        public void UpdatePercentData(int progress)
        {
            if (progress != CurrentDownloadPercent)
            {
                DownloadProgressBar.Value = progress;
                _DownloadProgressPercent.Text = progress.ToString();
                CurrentDownloadPercent = progress;
            }
        }

        public void UpdateLabelLocations()
        {
            // Updates the MainDownloadTitle
            decimal thisSize = decimal.Divide(this.Width, 2); decimal titleSize = decimal.Divide(_MainDownloadTitle.Width, 2); decimal final = thisSize - titleSize;
            decimal controlPercentage = decimal.Divide(final, this.Width);
            decimal controlPosition = decimal.Multiply(controlPercentage, this.Width);
            int downloadTitle_X = decimal.ToInt32(controlPosition);
            int downloadTitle_Y = 12;
            _MainDownloadTitle.Location = new Point(downloadTitle_X, downloadTitle_Y);

            //Update download status
            decimal _wholeDownloadLabelSize = decimal.Add(_DownloadProgressPercent.Width, _DownloadTitle.Width);
            decimal _downloadLabel_TitleSize = decimal.Divide(_wholeDownloadLabelSize, 2); decimal _downloadLabel_Final = thisSize - _downloadLabel_TitleSize;
            decimal _downloadLabel_ControlPercent = decimal.Divide(_downloadLabel_Final, this.Width);
            decimal _downloadLabel_controlPosition = decimal.Multiply(_downloadLabel_ControlPercent, this.Width);
            int downloadLabel_X = decimal.ToInt32(_downloadLabel_controlPosition); int downloadLabel_Y = 40;
            int ProgressLabel_X = (downloadLabel_X + _DownloadTitle.Width) - 3; int ProgressLabel_Y = downloadLabel_Y;

            _DownloadTitle.Location = new Point(downloadLabel_X, downloadLabel_Y);
            _DownloadProgressPercent.Location = new Point(ProgressLabel_X, ProgressLabel_Y);
        }

        #endregion 
    }
}
