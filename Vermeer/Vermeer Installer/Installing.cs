using IWshRuntimeLibrary;
using Moonbyte.MaterialFramework.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Vermeer_Installer
{
    public partial class Installing : MaterialForm
    {

        #region Vars

        MaterialForm FirstForm;
        WebClient DownloadClient;
        string TempZipDirectory = Path.Combine(Path.GetTempPath(), "Moonbyte");
        string TempZipFileName = "vermeer.zip";
        string InstallDirectory = Path.Combine(@"C:\", "Moonbyte", "Vermeer");

        int totalProgress = 0;

        #endregion Vars

        #region Initialization

        public Installing(MaterialForm firstForm)
        {
            InitializeComponent();

            CenterObject(progressbar_Progress);
            CenterObject(panelDownload);
            CenterObject(btn_Cancel);

            FirstForm = firstForm;
            string zipDirectory = Path.Combine(TempZipDirectory, TempZipFileName);

            if (!Directory.Exists(TempZipDirectory)) { Directory.CreateDirectory(TempZipDirectory); }
            if (!Directory.Exists(InstallDirectory)) { Directory.CreateDirectory(InstallDirectory); }
            if (System.IO.File.Exists(zipDirectory)) { System.IO.File.Delete(zipDirectory); }
            if (!IsDirectoryEmpty(InstallDirectory)) { Directory.Delete(InstallDirectory, true); Directory.CreateDirectory(InstallDirectory); }

            StartDownload();
        }

        #endregion Initialization

        #region StartWebClient

        private void StartDownload()
        {
            new Thread(() =>
            {
                DownloadClient = new WebClient();
                DownloadClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                DownloadClient.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileComplete);
                DownloadClient.DownloadFileAsync(new Uri("https://moonbyte.net/download/vermeer/vermeer.zip"), Path.Combine(TempZipDirectory, TempZipFileName));
            }).Start();
        }

        #endregion StartWebClient

        #region DownloadProgressChange

        DateTime lastUpdate;
        long lastBytes = 0;

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    double bytesIn = double.Parse(e.BytesReceived.ToString());
                    double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                    double percentage = bytesIn / totalBytes * 100;
                    long bytesPerSecond = 0;

                    if (lastBytes == 0)
                    { lastUpdate = DateTime.Now; lastBytes = e.BytesReceived; }
                    else
                    {
                        try
                        {
                            var now = DateTime.Now;
                            var timeSpan = now - lastUpdate;
                            var bytesChanged = e.BytesReceived - lastBytes;
                            if (timeSpan.Seconds > 0)
                            { bytesPerSecond = bytesChanged / timeSpan.Seconds; }
                        }
                        catch { }
                    }

                    label_DownloadUpdate.Text = ConvertBytesToMegabytes(e.BytesReceived).ToString("0.0") + "MB / " + ConvertBytesToMegabytes(e.TotalBytesToReceive).ToString("0.0") + "MB" + ", " + ConvertBytesToMegabytes(bytesPerSecond).ToString("0.0") + "MB/s";
                    progressbar_Progress.Value = Convert.ToInt32(percentage) / 2;
                });
            }
            catch { }
        }

        private double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        #endregion DownloadProgressChange

        #region DownloadFileComplete

        private void client_DownloadFileComplete(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                progressbar_Progress.Value = 50;
                ExtractVermeer();
            });
        }

        #endregion DownloadFileComplete

        #region Extracting Vermmer

        private void ExtractVermeer()
        {
            string zipDirectory = Path.Combine(TempZipDirectory, TempZipFileName);
            ZipFile.ExtractToDirectory(zipDirectory , InstallDirectory);

            string commonStartMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
            string appStartMenuPath = Path.Combine(commonStartMenuPath, "Programs", "Vermeer");

            if (!Directory.Exists(appStartMenuPath)) Directory.CreateDirectory(appStartMenuPath);

            AddShortcut(appStartMenuPath);
            AddShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            FirstForm.Close(); 
        }

        #endregion Extracting Vermeer

        #region CreateShortcut

        private void AddShortcut(string ShortcutDirectory)
        {
            string shortcutLocation = Path.Combine(ShortcutDirectory, "Vermeer" + ".lnk");
            string pathToExe = Path.Combine(InstallDirectory, "Vermeer.exe");

            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "Vermeer web browser developed by Moonbyte Corporation";
            shortcut.IconLocation = Path.Combine(InstallDirectory, "icon.ico");
            shortcut.TargetPath = pathToExe;
            shortcut.Save();
        }

        #endregion CreateShortcut

        #region Directory Empty Check

        public bool IsDirectoryEmpty(string path)
        { return !Directory.EnumerateFileSystemEntries(path).Any(); }

        #endregion

        #region FormLoading_Event

        private void Installing_Load(object sender, EventArgs e)
        {

        }

        #endregion FormLoading_Event

        #region Center Object

        private void CenterObject(Control _object)
        {
            int formWidth = this.Width;
            int pos = (formWidth - _object.Width) / 2;
            _object.Location = new Point(pos, _object.Location.Y);
        }

        #endregion Center Object

        #region FormClosing_Event

        private void Installing_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult msgResult = MessageBox.Show("Vermeer Installer", "Are you sure you want to stop installing Vermeer?", MessageBoxButtons.YesNo);
            if (msgResult == DialogResult.Yes)
            {
                FirstForm.Close();
            }
            else { e.Cancel = true; }
        }

        #endregion FormClosing_Event

        #region Btn_Cancel Click Event

        private void btn_Cancel_Click(object sender, EventArgs e)
        { this.Close(); }

        #endregion Btn_Cancel Click Event

    }
}
