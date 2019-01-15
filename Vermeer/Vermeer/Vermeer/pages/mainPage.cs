using Moonbyte.Vermeer.bin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vermeer.Vermeer.pages
{
    public partial class mainPage : Form
    {
        public mainPage()
        {
            InitializeComponent();
        }

        #region Form Closed

        private void mainPage_FormClosed(object sender, FormClosedEventArgs e)
        { if (Application.OpenForms.Count == 0) { vermeer.Close(); } }

        #endregion
    }
}
