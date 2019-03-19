using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace Updater
{
    public partial class Form1 : Form
    {

        #region Vars

        string directory = Path.GetTempPath() + @"\Moonbyte\Vermeer\Updater\";
        string installPath = @"C:\Program Files\Moonbyte\Vermeer";
        string fileName = "vermeer.zip";

        #endregion Vars

        #region Initialization

        public Form1()
        {
            InitializeComponent();

            Directory.Delete(installPath, true);
            Directory.CreateDirectory(installPath);

            WebClient client = new WebClient();
            client.DownloadFile("https://moonbyte.net/download/vermeer.zip", directory + fileName);
            client.DownloadFileCompleted += downloadFileCompletedEventHandler;
        }

        #endregion Initialization

        #region Downloading File

        private void downloadFileCompletedEventHandler(object sender, AsyncCompletedEventArgs e)
        {
            ZipFile.ExtractToDirectory(directory + fileName, installPath);
            MessageBox.Show("Vermeer", "Vermeer is fully updated!");
            Process.Start(installPath + @"\vermeer.exe");
            this.Close();
        }

        #endregion Downlaod File
    }
}
