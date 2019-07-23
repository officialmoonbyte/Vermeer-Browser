using MaterialFramework.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
using Vermeer_Installer.Cards;
using Vermeer_Installer.Controls;

namespace Vermeer_Installer
{
    public partial class VermeerInstaller : MaterialForm
    {

        #region Vars

        DownloadUI downloadUI = new DownloadUI();

        #region Cards

        TitleCard titleCard;
        TestCard testCard;

        #endregion

        #endregion

        #region Initialization

        public VermeerInstaller()
        {
            InitializeComponent();

            // Download UI //
            downloadUI = new DownloadUI();
            downloadUI.Location = new Point(1, 424);

            this.Controls.Add(downloadUI);

            // Title Card //
            titleCard = new TitleCard();
            titleCard.Location = new Point(1, 33);

            this.Controls.Add(titleCard);
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

        int maxTimerTick = 16;
        int movePerTick;
        int moveTimerTick = 0;

        #endregion Vars

        #region 1

        public void SwapPage1()
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

        #endregion 1

        #endregion SwapPage
    }
}
