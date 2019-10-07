using IndieGoat.MaterialFramework.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace VermeerInstaller.Controls
{
    public class LogoHeader : UserControl
    {

        #region Vars

        Font normalFont = new Font("Segoe UI", 8f);
        Font TitleFont = new Font("Segoe UI", 14f);
        Font LargeTitleFont = new Font("Segoe UI", 16f);

        MaterialLabel ApplicationTitle;
        MaterialLabel CompanyName;
        PictureBox ApplicationIcon;

        #endregion Vars

        #region Initialization

        public LogoHeader()
        {
            //Logo Header
            this.Size = new Size(508, 160);

            //CompanyName
            CompanyName = new MaterialLabel();

            //ApplicationTitle
            ApplicationTitle = new MaterialLabel();
            ApplicationTitle.Font = LargeTitleFont;
            ApplicationTitle.ForeColor = Color.FromArgb(60, 60, 60);
            ApplicationTitle.Text = "Vermeer Web Browser";

            this.Controls.Add(ApplicationTitle);
        }

        #endregion Initialization

        #region Override Paint

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            base.OnPaint(e);
        }

        #endregion Override Paint

        #region PositionCompanyName

        private void RepositionCompanyNameLogo()
        {

        }

        #endregion PositionCompanyName

    }
}
