using IndieGoat.MaterialFramework.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace Vermeer_Installer.Cards
{
    public class SettingsCard : UserControl
    {

        #region Vars

        #region Fonts

        Font mainFont;

        #endregion Fonts

        public MaterialLabel label_InstallLocation_Title;

        public MaterialTextBox textbox_InstallLocation;

        public FlatButton btn_Install;

        #endregion Vars

        #region Initialization

        public SettingsCard()
        {
            // Title Card //
            this.Size = new Size(398, 391);
            this.BackColor = Color.White;

            // Fonts //
            mainFont = new Font("Segoe UI", 12f, FontStyle.Regular);

            // label_InstallLocation_Label - 26 away//
            label_InstallLocation_Title = new MaterialLabel();
            label_InstallLocation_Title.Text = "Vermeer's install directory";
            label_InstallLocation_Title.Font = mainFont;
            label_InstallLocation_Title.Click += (obj, args) =>
            {
                VermeerInstaller vermeerInstaller = (VermeerInstaller)this.Parent;
            };
            label_InstallLocation_Title.ForeColor = Color.FromArgb(16, 16, 16);

            this.Controls.Add(label_InstallLocation_Title);
            CenterControl(label_InstallLocation_Title, 114);

            // textbox_InstallLocation //
            textbox_InstallLocation = new MaterialTextBox();
            textbox_InstallLocation.Width = 300;
            textbox_InstallLocation.BackColor = Color.White;
            textbox_InstallLocation.BorderColor = Color.FromArgb(235, 235, 235);
            textbox_InstallLocation.BottomBorderColor = Color.FromArgb(235, 235, 235);

            this.Controls.Add(textbox_InstallLocation);
            CenterControl(textbox_InstallLocation, 140);

            // btn_Install //
            btn_Install = new FlatButton();
            btn_Install.Size = new Size(220, 45);
            btn_Install.Text = "Install";

            ChangeButtonColor(false);

            btn_Install.Click += (obj, args) =>
            {
                if (btn_Install.Enabled)
                {
                    VermeerInstaller vermeerInstaller = (VermeerInstaller)this.Parent;
                    vermeerInstaller.SwapPage2();
                }
            };

            this.Controls.Add(btn_Install);
            CenterControl(btn_Install, 340);
        }

        #endregion Initialization

        #region ChangeButtonColor

        public void ChangeButtonColor(bool EnabledStatus = false)
        {
            if (EnabledStatus == true)
            {
                btn_Install.BackColor = Color.White;
                btn_Install.BorderColor = Color.FromArgb(240, 240, 240);
                btn_Install.TextColor = Color.FromArgb(65, 65, 65);
            }
            else
            {
                btn_Install.BackColor = Color.White;
                btn_Install.BorderColor = Color.FromArgb(250, 250, 250);
                btn_Install.TextColor = Color.FromArgb(160, 160, 160);
            }

            btn_Install.Enabled = EnabledStatus;
        }

        #endregion ChangeButtonColor

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

        #region Center Control

        private void CenterControl(UserControl control, int Y)
        {
            decimal thisSize = decimal.Divide(this.Width, 2); decimal controlSize = decimal.Divide(control.Width, 2); decimal final = thisSize - controlSize;
            decimal controlPercent = decimal.Divide(final, this.Width);
            decimal controlPosition = decimal.Multiply(controlPercent, this.Width);
            int X = decimal.ToInt32(controlPosition);
            control.Location = new Point(X, Y);
        }
        private void CenterControl(MaterialLabel control, int y)
        {
            decimal thisSize = decimal.Divide(this.Width, 2); decimal controlSize = decimal.Divide(control.Width, 2); decimal final = thisSize - controlSize;
            decimal controlPercent = decimal.Divide(final, this.Width);
            decimal controlPosition = decimal.Multiply(controlPercent, this.Width);
            int X = decimal.ToInt32(controlPosition);
            control.Location = new Point(X, y);
        }

        #endregion Center Control
    }
}
