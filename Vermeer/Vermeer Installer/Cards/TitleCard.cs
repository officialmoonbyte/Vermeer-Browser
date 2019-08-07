using IndieGoat.MaterialFramework.Controls;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace Vermeer_Installer.Cards
{
    public class TitleCard : UserControl
    {

        #region Vars

        Panel copyrightPanel;

        FlatButton continueButton;

        MaterialLabel EULATitle;
        MaterialLabel CopyrightLabel;
        MaterialLabel EULAWARN;
        MaterialLabel copyrightContent;

        #region Fonts

        Font mainFont_Title;
        Font mainFont_LittleTitle;
        Font mainFont;
        Font copyright;

        #endregion Fonts

        #endregion Vars

        #region Initialization

        public TitleCard()
        {
            // Title Card //
            this.Size = new Size(398, 391);
            this.BackColor = Color.White;

            // Fonts //
            mainFont_Title = new Font("Segoe UI", 14f, FontStyle.Regular);
            mainFont_LittleTitle = new Font("Segoe UI", 10f, FontStyle.Regular);
            mainFont = new Font("Segoe UI", 8f, FontStyle.Regular);
            copyright = new Font("Segoe UI", 8f, FontStyle.Italic);

            // Continue Button //
            continueButton = new FlatButton();
            continueButton.Size = new Size(160, 36);
            continueButton.BackColor = Color.White;
            continueButton.BorderColor = Color.FromArgb(245, 245, 245);
            continueButton.Text = "Agree and Continue";
            continueButton.Click += (obj, args) =>
            {
                VermeerInstaller vermeerInstaller = (VermeerInstaller)this.Parent;
                vermeerInstaller.SwapPage1(); 
            };

            this.Controls.Add(continueButton);
            UpdateButtonLocation(continueButton, 340);

            // Copyright Panel //
            copyrightPanel = new Panel();
            copyrightPanel.Location = new Point(0, 0);
            copyrightPanel.Size = new Size(this.Width, this.Height - 64);
            copyrightPanel.AutoScroll = true;

            this.Controls.Add(copyrightPanel);

            // EULA TITLE //
            EULATitle = new MaterialLabel();
            EULATitle.Font = mainFont_Title;
            EULATitle.ForeColor = Color.FromArgb(48, 48, 48);
            EULATitle.TextAlign = ContentAlignment.MiddleCenter;
            EULATitle.Text = "Vermeer Browser";

            copyrightPanel.Controls.Add(EULATitle);
            UpdateLabelLocation(EULATitle, 12);

            // Copyright Label //
            CopyrightLabel = new MaterialLabel();
            CopyrightLabel.Font = mainFont_LittleTitle;
            CopyrightLabel.ForeColor = Color.FromArgb(48, 48, 48);
            CopyrightLabel.TextAlign = ContentAlignment.MiddleCenter;
            CopyrightLabel.Text = "Copyright (c) 2019 Moonbyte Corporation";

            copyrightPanel.Controls.Add(CopyrightLabel);
            UpdateLabelLocation(CopyrightLabel, 36);

            // EULA WARN //
            EULAWARN = new MaterialLabel();
            EULAWARN.Font = mainFont;
            EULAWARN.ForeColor = Color.FromArgb(48, 48, 48);
            EULAWARN.TextAlign = ContentAlignment.MiddleCenter;
            EULAWARN.Text = "*** END USER LICENSE AGREEMENT ***";

            copyrightPanel.Controls.Add(EULAWARN);
            UpdateLabelLocation(EULAWARN, 84);

            // Copyright Content //
            copyrightContent = new MaterialLabel();
            copyrightContent.Font = copyright;
            copyrightContent.ForeColor = Color.FromArgb(48, 48, 48);
            copyrightContent.TextAlign = ContentAlignment.TopLeft;
            copyrightContent.Location = new Point(4, 125);
            try
            {
                using (WebClient client = new WebClient())
                { copyrightContent.Text = client.DownloadString("https://moonbyte.net/vermeer/eula.html"); }
            }
            catch
            {
                MessageBox.Show("You have to be connected to the internet for Vermeer to download!");
                Environment.Exit(0);
            }

            copyrightPanel.Controls.Add(copyrightContent);

        }

        #endregion Initialization

        #region UpdateLabelLocations
        private void UpdateButtonLocation(FlatButton button, int y)
        {
            decimal thisSize = decimal.Divide(this.Width, 2); decimal labelSize = decimal.Divide(button.Width, 2); decimal final = thisSize - labelSize;
            decimal controlPercent = decimal.Divide(final, this.Width);
            decimal controlPosition = decimal.Multiply(controlPercent, this.Width);
            int label_X = decimal.ToInt32(controlPosition);
            button.Location = new Point(label_X, y);
        }
        private void UpdateLabelLocation(MaterialLabel label, int y)
        {
            decimal thisSize = decimal.Divide(this.Width, 2); decimal labelSize = decimal.Divide(label.Width, 2); decimal final = thisSize - labelSize;
            decimal controlPercent = decimal.Divide(final, this.Width);
            decimal controlPosition = decimal.Multiply(controlPercent, this.Width);
            int label_X = decimal.ToInt32(controlPosition);
            int label_Y = y;
            label.Location = new Point(label_X, label_Y);
        }
        private void UpdateLabelLocation(MaterialLabel label)
        {
            decimal thisSize = decimal.Divide(this.Width, 2); decimal labelSize = decimal.Divide(label.Width, 2); decimal final = thisSize - labelSize;
            decimal controlPercent = decimal.Divide(final, this.Width);
            decimal controlPosition = decimal.Multiply(controlPercent, this.Width);
            int label_X = decimal.ToInt32(controlPosition);
            int label_Y = label.Location.Y;
            label.Location = new Point(label_X, label_Y);
        }

        #endregion UpdateLabelLocations

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            //Initialize graphics unit
            Graphics g = e.Graphics;

            //Draws background
            g.Clear(this.BackColor);
            base.OnPaint(e);
        }

        #endregion OnPaint

    }
}
