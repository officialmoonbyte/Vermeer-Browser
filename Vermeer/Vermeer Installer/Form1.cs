using Ionic.Zip;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;

namespace Vermeer_Installer
{
    public partial class Form1 : customForm
    {

        #region Vars

        string TempDirectory = Path.GetTempPath();

        #endregion Vars

        #region Form Initialization

        public Form1()
        {
            InitializeComponent();
        }

        #endregion Form Initialization

        #region On Load ** Required

        private void Form1_Load(object sender, EventArgs e)
        {
            customProgressbar1.BackColor = Color.FromArgb(249, 249, 249);
            customProgressbar1.BorderColor = Color.FromArgb(244, 244, 244);
            customProgressbar2.BackColor = Color.FromArgb(249, 249, 249);
            customProgressbar2.BorderColor = Color.FromArgb(244, 244, 244);

            StartDownload();
        }

        #endregion On Load

        #region Start download

        private void StartDownload()
        {
            TempDirectory += @"\Moonbyte\Vermeer Installer\";
            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += (obj, args) =>
                { customProgressbar1.Value = args.ProgressPercentage; };

                client.DownloadFileCompleted += (obj, args) =>
                {
                    //Download complete, extract file

                    lbl_Step.Text = "Step 2/3";

                    string INSTALL_FOLDER = "C:\\Program Files\\Moonbyte\\Vermeer";
                    string ZIP_LOCATION = TempDirectory + "Vermeer.zip";

                    if (Directory.Exists(INSTALL_FOLDER)) Directory.Delete(INSTALL_FOLDER, true);
                    Directory.CreateDirectory(INSTALL_FOLDER);

                    using (ZipFile zip = ZipFile.Read(ZIP_LOCATION))
                    {
                        zip.ExtractProgress += (objj, Args) =>
                        {
                            if (Args.BytesTransferred != 0 && Args.TotalBytesToTransfer != 0)
                            { customProgressbar2.Value = Int32.Parse(((Args.BytesTransferred / Args.TotalBytesToTransfer) * 100).ToString()); }
                            if (customProgressbar2.Value == 100)
                            {
                                this.Controls.Remove(customProgressbar1);
                                this.Controls.Remove(customProgressbar2);
                                this.Controls.Remove(label5);
                                this.Controls.Remove(label6);
                            }
                        };
                        zip.ExtractAll(INSTALL_FOLDER);
                    }
                };
                if (!Directory.Exists(TempDirectory)) Directory.CreateDirectory(TempDirectory);
                if (File.Exists(TempDirectory + "Vermeer.zip")) File.Delete(TempDirectory + "Vermeer.zip");
                client.DownloadFileAsync(new Uri("https://moonbyte.net/download/Vermeer.zip"), TempDirectory + "Vermeer.zip");
            }
        }

        #endregion Start Download

    }
}
