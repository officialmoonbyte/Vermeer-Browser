using IndieGoat.MaterialFramework.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace Vermeer_Installer.Cards
{
    public class InstallingCard : UserControl
    {

        #region Vars

        MaterialLabel title_Label;

        #endregion Vars

        #region Initialization

        public InstallingCard()
        {
            // Title Card //
            this.Size = new Size(398, 391);
            this.BackColor = Color.White;


            // title_Label //
            title_Label = new MaterialLabel();
            title_Label.Text = "Installing...";
            title_Label.Font = new Font("Segoe UI", 14f, FontStyle.Bold);

            this.Controls.Add(title_Label);
            CenterControl(title_Label, (this.Height / 2));
        }

        #endregion Initialization

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
