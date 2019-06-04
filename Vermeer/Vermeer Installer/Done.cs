using IWshRuntimeLibrary;
using MaterialFramework.Controls;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Vermeer_Installer
{
    public partial class Done : MaterialForm
    {

        #region Vars

        Installer InstallerObject;

        #endregion

        #region Initialization

        public Done(bool StartMenuShortcut, bool DesktopShortcut, Installer _InstallerObject)
        {
            InitializeComponent();

            //
            // Initializing values
            //
            cek_StartMenu.Checked = StartMenuShortcut;
            cek_DesktopShortcut.Checked = DesktopShortcut;
            InstallerObject = _InstallerObject;

            //
            // Centering all objects
            //
            CenterObject(pnl_CreateDesktopShortcut);
            CenterObject(pnl_CreateStartMenuShortcut);
            CenterObject(lbl_Title);
            CenterObject(lbl_Title2);
            CenterObject(btn_Finish);
        }

        #endregion Initialization

        #region BTN_Finish

        private void Btn_Finish_Click(object sender, System.EventArgs e)
        {
            string DesktopShortcutLocation = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string StartMenuShortcutLocation = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
            string VermeerLocation = InstallerObject.extractPath + @"\Vermeer.exe";
            string VermeerIconLocation = InstallerObject.extractPath + @"\icon.ico";

            if (cek_DesktopShortcut.Checked)
            { CreateShortcut("Vermeer", DesktopShortcutLocation, VermeerLocation); Console.WriteLine("G"); }
            if (cek_StartMenu.Checked)
            { CreateShortcut("Vermeer", StartMenuShortcutLocation, VermeerLocation); Console.WriteLine("W"); }

            System.Diagnostics.Process.Start(VermeerLocation);
            this.Close();
            Environment.Exit(0);
        }

        #endregion

        #region Create Shortcut

        public void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            try
            {
                string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
                Console.WriteLine(shortcutLocation);
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

                shortcut.IconLocation = InstallerObject.extractPath + @"\icon.ico";
                shortcut.TargetPath = targetFileLocation;
                shortcut.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        #endregion Create Shortcut

        #region CenterObject

        private void CenterObject(Control _Object)
        {
            decimal newLocation = (((decimal.Divide(_Object.Width, this.Width) - 1) / 2) * this.Width) * -1;
            _Object.Location = new Point(decimal.ToInt32(newLocation), _Object.Location.Y);
        }

        #endregion CenterObject

    }
}
