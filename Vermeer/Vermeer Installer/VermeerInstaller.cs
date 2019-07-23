using MaterialFramework.Controls;
using System;
using System.Drawing;
using Vermeer_Installer.Controls;

namespace Vermeer_Installer
{
    public partial class VermeerInstaller : MaterialForm
    {

        #region Vars

        DownloadUI downloadUI = new DownloadUI();

        #endregion

        #region Initialization

        public VermeerInstaller()
        {
            InitializeComponent();

            // Download UI //
            downloadUI = new DownloadUI();
            downloadUI.Location = new Point(1, 399);
            this.Controls.Add(downloadUI);
        }

        #region OnLoad

        private void VermeerInstaller_Load(object sender, EventArgs e)
        {
            this.closebutton.Size = new System.Drawing.Size(48, 28);
        }

        #endregion

        #endregion
    }
}
