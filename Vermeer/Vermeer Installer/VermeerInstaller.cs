using MaterialFramework.Controls;
using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;
using Vermeer_Installer.Cards;
using Vermeer_Installer.Controls;

namespace Vermeer_Installer
{
    public partial class VermeerInstaller : MaterialForm
    {

        #region Vars

        string tempDirectory = Path.GetTempPath();

        public DownloadUI downloadUI = new DownloadUI();

        #region Cards

        TitleCard titleCard;
        SettingsCard settingsCard;
        TestCard testCard;
        InstallingCard installingCard;

        #endregion

        #endregion

        #region Initialization

        public VermeerInstaller()
        {
            InitializeComponent();

            // Vars
            string DownloadDirectory = tempDirectory + @"\Moonbyte\";
            string zipDirectory = DownloadDirectory + "vermeer.zip";

            // Download UI //
            downloadUI = new DownloadUI();
            downloadUI.Location = new Point(1, 424);

            this.Controls.Add(downloadUI);

            // Title Card //
            titleCard = new TitleCard();
            titleCard.Location = new Point(1, 33);

            this.Controls.Add(titleCard);

            // Download //
            WebClient client = new WebClient();

            //Checks if the zip file exists, if it does deletes the file.
            if (File.Exists(zipDirectory)) File.Delete(zipDirectory);

            client.DownloadProgressChanged += (obj, args) =>
            {
                double bytesIn = double.Parse(args.BytesReceived.ToString());
                double totalBytes = double.Parse(args.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                downloadUI.UpdatePercentData(int.Parse(Math.Truncate(percentage).ToString()));
            };
            client.DownloadFileCompleted += (obj, args) =>
            {
                settingsCard.ChangeButtonColor(true);
            };

            if (!Directory.Exists(DownloadDirectory)) { Directory.CreateDirectory(DownloadDirectory); }

            try
            {
                client.DownloadFileAsync(new Uri("https://moonbyte.net/Download/Vermeer/Vermeer.zip"), zipDirectory);
            }
            catch
            {
                MessageBox.Show("You have to be connected to the internet for Vermeer to download!");
                Environment.Exit(0);
            }

        }

        #region OnLoad

        private void VermeerInstaller_Load(object sender, EventArgs e)
        {
            this.closebutton.Size = new System.Drawing.Size(48, 28);

        }

        #endregion

        #endregion

        #region SwapPage

        #region Vars

        int maxTimerTick = 12;
        int movePerTick;
        int moveTimerTick = 0;

        #endregion Vars

        #region TestPage

        public void SwapPageTest()
        {
            testCard = new TestCard(); int testCard_X = titleCard.Location.X + titleCard.Width; Console.WriteLine(testCard_X);
            testCard.Location = new Point(testCard_X, titleCard.Location.Y);

            this.Controls.Add(testCard);

            Timer moveTimer = new Timer();
            moveTimerTick = 0;
            decimal moveP = decimal.Divide(testCard.Width, maxTimerTick); Console.WriteLine("E : " + moveP);
            movePerTick = decimal.ToInt32(moveP);
            moveTimer.Interval = 1;
            moveTimer.Tick += (obj, args) =>
            {
                moveTimerTick++;
                titleCard.Left -= movePerTick;
                testCard.Left -= movePerTick;

                if (moveTimerTick == maxTimerTick)
                {
                    testCard.Location = new Point(1, 33);
                    this.Controls.Remove(titleCard);
                    moveTimer.Stop();
                }
            };
            moveTimer.Start();
        }

        #endregion TestPage

        #region RemoveDownloadUI

        public void RemoveDownloadUI()
        {
            this.Controls.Remove(downloadUI);

            // Vars
            string DownloadDirectory = tempDirectory + @"\Moonbyte\";
            string zipDirectory = DownloadDirectory + "vermeer.zip";
            string InstallDirectory = settingsCard.textbox_InstallLocation.Text;

            // Start extracting the zip file
            if (!Directory.Exists(InstallDirectory)) Directory.CreateDirectory(InstallDirectory); //Creates the install directory if it doesn't exist's
            ZipFile.ExtractToDirectory(zipDirectory, settingsCard.textbox_InstallLocation.Text);

            //Extract complete

        }

        #endregion RemoveDownloadUI

        #region 1

        public void SwapPage1()
        {
            settingsCard = new SettingsCard(); int testCard_X = titleCard.Location.X + titleCard.Width;
            settingsCard.Location = new Point(testCard_X, titleCard.Location.Y);

            this.Controls.Add(settingsCard);

            settingsCard.textbox_InstallLocation.Text = "";

            int moveSpeed = 28;

            Timer moveTimer = new Timer();
            moveTimer.Interval = 1;
            moveTimer.Tick += (obj, args) =>
            {
                if ((settingsCard.Location.X - moveSpeed) < 1)
                {
                    settingsCard.Location = new Point(1, 33);

                    this.Controls.Remove(titleCard);
                    moveTimer.Enabled = false;
                }
                else if (settingsCard.Location.X > 1)
                {
                    settingsCard.Left -= moveSpeed;
                    titleCard.Left -= moveSpeed;
                }
                else
                {
                    settingsCard.Location = new Point(1, 33);

                    this.Controls.Remove(titleCard);
                    moveTimer.Enabled = false;
                }
            };
            moveTimer.Start();
        }

        public void SwapPage2()
        {
            installingCard = new InstallingCard(); int testCard_X = settingsCard.Location.X + settingsCard.Width;
            installingCard.Location = new Point(testCard_X, titleCard.Location.Y);

            this.Controls.Add(installingCard);

            //settingsCard.textbox_InstallLocation.Text = "";

            int moveSpeed = 28;

            Timer moveTimer = new Timer();
            moveTimer.Interval = 1;
            moveTimer.Tick += (obj, args) =>
            {
                if ((installingCard.Location.X - moveSpeed) < 1)
                {
                    installingCard.Location = new Point(1, 33);

                    this.Controls.Remove(settingsCard);
                    moveTimer.Enabled = false;
                }
                else if (installingCard.Location.X > 1)
                {
                    installingCard.Left -= moveSpeed;
                    settingsCard.Left -= moveSpeed;
                }
                else
                {
                    installingCard.Location = new Point(1, 33);

                    this.Controls.Remove(settingsCard);
                    moveTimer.Enabled = false;
                }
            };
            moveTimer.Start();
        }

        #endregion 1

        #endregion SwapPage
    }
}
