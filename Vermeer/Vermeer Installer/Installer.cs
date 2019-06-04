using System;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace Vermeer_Installer
{
    public class Installer
    {

        #region Vars

        WebClient DownloadClient;

        string DownloadDirectory;
        string DownloadFile;

        #endregion Vars

        #region Events

        public event EventHandler<DownloadProgressChangedEventArgs> DownloadProgressChanged;
        public event EventHandler<EventArgs> DownloadComplete;
        public event EventHandler<EventArgs> ExtractComplete;

        #endregion

        #region Initialization

        public Installer()
        {
            DownloadClient = new WebClient();

            DownloadDirectory = Path.GetTempPath() + @"\Moonbyte\Vermeer";
            DownloadFile = DownloadDirectory + @"\VermeerFiles.zip";

            if (!Directory.Exists(DownloadDirectory))
            { Directory.CreateDirectory(DownloadDirectory); }

            if (File.Exists(DownloadFile))
            { File.Delete(DownloadFile); }
        }

        #endregion Initialization

        #region Downloading

        public void StartDownload()
        {
            DownloadClient.DownloadProgressChanged += (obj, args) =>
            { this.DownloadProgressChanged?.Invoke(obj, args); };
            DownloadClient.DownloadFileCompleted += (obj, args) =>
            { this.DownloadComplete?.Invoke(obj, args); };

            DownloadClient.DownloadFileAsync(new Uri("https://dl.dropboxusercontent.com/s/o447abln5u2cjky/Vermeer.zip?dl=0"), DownloadFile);
        }

        #endregion Downloading

        #region Extracting

        public string extractPath = @"C:\Moonbyte\Vermeer";
        public void StartExtraction()
        {
            if (Directory.Exists(extractPath)) { Directory.Delete(extractPath, true); }
            Directory.CreateDirectory(extractPath);
            ZipFile.ExtractToDirectory(DownloadFile, extractPath);
            ExtractComplete?.Invoke(this, new EventArgs());
        }

        #endregion Extracting

        #region Dispose

        public void Dispose()
        {
            if (File.Exists(DownloadFile))
            { File.Delete(DownloadFile); }

            DownloadDirectory = null;
            DownloadFile = null;
            DownloadClient = null;
        }

        #endregion Dispose

    }
}
