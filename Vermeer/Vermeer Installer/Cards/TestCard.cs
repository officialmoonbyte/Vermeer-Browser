using System.Drawing;
using System.Windows.Forms;

namespace Vermeer_Installer.Cards
{
    public class TestCard : UserControl
    {

        #region Vars



        #endregion Vars

        #region Initialization

        public TestCard()
        {
            // Title Card //
            this.Size = new Size(398, 391);
            this.BackColor = Color.Blue;

            //Panel//
            Panel panel = new Panel();
            panel.Size = new Size(80, 80);
            panel.Location = new Point(60, 60);
            panel.BackColor = Color.Red;
            this.Controls.Add(panel);
        }

        #endregion Initialization

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
