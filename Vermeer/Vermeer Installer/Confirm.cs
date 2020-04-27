using Moonbyte.MaterialFramework.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vermeer_Installer
{
    public partial class Confirm : MaterialForm
    {
        public Confirm()
        {
            InitializeComponent();
        }

        private void Confirm_Load(object sender, EventArgs e)
        {
            CenterObject(label_Title);
            CenterObject(button_Submit);
            CenterObject(label_AlphaWarning);
        }

        #region Center Object

        private void CenterObject(Control _object)
        {
            int formWidth = this.Width;
            int pos = (formWidth - _object.Width) / 2;
            _object.Location = new Point(pos, _object.Location.Y);
        }

        #endregion Center Object

        private void button_Submit_Click(object sender, EventArgs e)
        {
            Installing installer = new Installing(this);
            installer.Show();
            this.Hide();
        }

        private void label_Title_Click(object sender, EventArgs e)
        {

        }
    }
}
