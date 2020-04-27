using MaterialFramework.Controls;
using System;
using VermeerInstaller.Controls;

namespace VermeerInstaller.Pages
{
    public partial class InstallerPage : MaterialForm
    {

        #region Vars

        LogoHeader logoHeader;

        #endregion Vars

        #region Initialization

        public InstallerPage()
        {
            InitializeComponent();

            //LogoHeader
            logoHeader = new LogoHeader();
            logoHeader.Location = new System.Drawing.Point(1, 32);

            this.Controls.Add(logoHeader);
        }

        #endregion Initialization

        private void InstallerPage_Load(object sender, EventArgs e)
        {

        }
    }
}
