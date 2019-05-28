namespace Vermeer_Installer
{
    partial class Vermeer_Installer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Title = new IndieGoat.MaterialFramework.Controls.MaterialLabel();
            this.pgb_Progress = new IndieGoat.MaterialFramework.Controls.MaterialProgressBar();
            this.materialLabel1 = new IndieGoat.MaterialFramework.Controls.MaterialLabel();
            this.pnl_MoonbyteLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_Status = new IndieGoat.MaterialFramework.Controls.MaterialLabel();
            this.pnl_CreateDesktopShortcut = new System.Windows.Forms.Panel();
            this.materialLabel2 = new IndieGoat.MaterialFramework.Controls.MaterialLabel();
            this.cek_DesktopShortcut = new IndieGoat.MaterialFramework.Controls.MaterialCheckBox();
            this.pnl_CreateStartMenuShortcut = new System.Windows.Forms.Panel();
            this.materialLabel3 = new IndieGoat.MaterialFramework.Controls.MaterialLabel();
            this.cek_StartMenu = new IndieGoat.MaterialFramework.Controls.MaterialCheckBox();
            this.pnl_MoonbyteLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_CreateDesktopShortcut.SuspendLayout();
            this.pnl_CreateStartMenuShortcut.SuspendLayout();
            this.SuspendLayout();
            // 
            // closebutton
            // 
            this.closebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closebutton.Location = new System.Drawing.Point(555, 2);
            this.closebutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // maxbutton
            // 
            this.maxbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxbutton.Location = new System.Drawing.Point(601, 103);
            this.maxbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maxbutton.Size = new System.Drawing.Size(72, 45);
            this.maxbutton.TabIndex = 1;
            // 
            // minbutton
            // 
            this.minbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minbutton.Location = new System.Drawing.Point(507, 2);
            this.minbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.minbutton.TabIndex = 2;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(5, 6);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(134, 21);
            this.lbl_Title.TabIndex = 4;
            this.lbl_Title.Text = "Vermeer Installer";
            // 
            // pgb_Progress
            // 
            this.pgb_Progress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.pgb_Progress.Location = new System.Drawing.Point(69, 177);
            this.pgb_Progress.Maximum = 100;
            this.pgb_Progress.Minimum = 0;
            this.pgb_Progress.Name = "pgb_Progress";
            this.pgb_Progress.ProgressBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(176)))), ((int)(((byte)(37)))));
            this.pgb_Progress.Size = new System.Drawing.Size(466, 35);
            this.pgb_Progress.TabIndex = 5;
            this.pgb_Progress.Value = 0;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialLabel1.Location = new System.Drawing.Point(34, 6);
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(89, 20);
            this.materialLabel1.TabIndex = 6;
            this.materialLabel1.Text = "Moonbyte";
            // 
            // pnl_MoonbyteLogo
            // 
            this.pnl_MoonbyteLogo.Controls.Add(this.pictureBox1);
            this.pnl_MoonbyteLogo.Controls.Add(this.materialLabel1);
            this.pnl_MoonbyteLogo.Location = new System.Drawing.Point(241, 229);
            this.pnl_MoonbyteLogo.Name = "pnl_MoonbyteLogo";
            this.pnl_MoonbyteLogo.Size = new System.Drawing.Size(124, 32);
            this.pnl_MoonbyteLogo.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::Vermeer_Installer.Properties.Resources.MoonbyteLogo_32bit;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Status.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_Status.Location = new System.Drawing.Point(93, 155);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(421, 19);
            this.lbl_Status.TabIndex = 9;
            this.lbl_Status.Text = "Vermeer is currently downloading with 0Mb / 100 Mb downloaded.";
            // 
            // pnl_CreateDesktopShortcut
            // 
            this.pnl_CreateDesktopShortcut.Controls.Add(this.materialLabel2);
            this.pnl_CreateDesktopShortcut.Controls.Add(this.cek_DesktopShortcut);
            this.pnl_CreateDesktopShortcut.Location = new System.Drawing.Point(209, 115);
            this.pnl_CreateDesktopShortcut.Name = "pnl_CreateDesktopShortcut";
            this.pnl_CreateDesktopShortcut.Size = new System.Drawing.Size(190, 21);
            this.pnl_CreateDesktopShortcut.TabIndex = 10;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.materialLabel2.Location = new System.Drawing.Point(16, 0);
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(160, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Create Desktop Shortcut";
            // 
            // cek_DesktopShortcut
            // 
            this.cek_DesktopShortcut.BackColor = System.Drawing.Color.Transparent;
            this.cek_DesktopShortcut.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.cek_DesktopShortcut.Checked = false;
            this.cek_DesktopShortcut.ClickedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.cek_DesktopShortcut.Location = new System.Drawing.Point(0, 2);
            this.cek_DesktopShortcut.MiddleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cek_DesktopShortcut.Name = "cek_DesktopShortcut";
            this.cek_DesktopShortcut.OnMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cek_DesktopShortcut.Size = new System.Drawing.Size(16, 16);
            this.cek_DesktopShortcut.TabIndex = 0;
            // 
            // pnl_CreateStartMenuShortcut
            // 
            this.pnl_CreateStartMenuShortcut.Controls.Add(this.materialLabel3);
            this.pnl_CreateStartMenuShortcut.Controls.Add(this.cek_StartMenu);
            this.pnl_CreateStartMenuShortcut.Location = new System.Drawing.Point(209, 85);
            this.pnl_CreateStartMenuShortcut.Name = "pnl_CreateStartMenuShortcut";
            this.pnl_CreateStartMenuShortcut.Size = new System.Drawing.Size(189, 21);
            this.pnl_CreateStartMenuShortcut.TabIndex = 11;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.materialLabel3.Location = new System.Drawing.Point(16, 0);
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(174, 19);
            this.materialLabel3.TabIndex = 1;
            this.materialLabel3.Text = "Create StartMenu Shortcut";
            // 
            // cek_StartMenu
            // 
            this.cek_StartMenu.BackColor = System.Drawing.Color.Transparent;
            this.cek_StartMenu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.cek_StartMenu.Checked = false;
            this.cek_StartMenu.ClickedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.cek_StartMenu.Location = new System.Drawing.Point(0, 2);
            this.cek_StartMenu.MiddleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.cek_StartMenu.Name = "cek_StartMenu";
            this.cek_StartMenu.OnMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cek_StartMenu.Size = new System.Drawing.Size(16, 16);
            this.cek_StartMenu.TabIndex = 0;
            // 
            // Vermeer_Installer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(604, 294);
            this.Controls.Add(this.pnl_CreateStartMenuShortcut);
            this.Controls.Add(this.pnl_CreateDesktopShortcut);
            this.Controls.Add(this.lbl_Status);
            this.Controls.Add(this.pnl_MoonbyteLogo);
            this.Controls.Add(this.pgb_Progress);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.closebutton);
            this.Controls.Add(this.maxbutton);
            this.Controls.Add(this.minbutton);
            this.EnableMaxButton = false;
            this.EnableMinButton = false;
            this.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Vermeer_Installer";
            this.ShowIcon = false;
            this.ShowTitle = false;
            this.Text = "Vermeer_Installer";
            this.Controls.SetChildIndex(this.minbutton, 0);
            this.Controls.SetChildIndex(this.maxbutton, 0);
            this.Controls.SetChildIndex(this.closebutton, 0);
            this.Controls.SetChildIndex(this.lbl_Title, 0);
            this.Controls.SetChildIndex(this.pgb_Progress, 0);
            this.Controls.SetChildIndex(this.pnl_MoonbyteLogo, 0);
            this.Controls.SetChildIndex(this.lbl_Status, 0);
            this.Controls.SetChildIndex(this.pnl_CreateDesktopShortcut, 0);
            this.Controls.SetChildIndex(this.pnl_CreateStartMenuShortcut, 0);
            this.pnl_MoonbyteLogo.ResumeLayout(false);
            this.pnl_MoonbyteLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_CreateDesktopShortcut.ResumeLayout(false);
            this.pnl_CreateDesktopShortcut.PerformLayout();
            this.pnl_CreateStartMenuShortcut.ResumeLayout(false);
            this.pnl_CreateStartMenuShortcut.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private IndieGoat.MaterialFramework.Controls.MaterialLabel lbl_Title;
        private IndieGoat.MaterialFramework.Controls.MaterialProgressBar pgb_Progress;
        private IndieGoat.MaterialFramework.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.Panel pnl_MoonbyteLogo;
        private IndieGoat.MaterialFramework.Controls.MaterialLabel lbl_Status;
        private System.Windows.Forms.Panel pnl_CreateDesktopShortcut;
        private IndieGoat.MaterialFramework.Controls.MaterialLabel materialLabel2;
        private IndieGoat.MaterialFramework.Controls.MaterialCheckBox cek_DesktopShortcut;
        private System.Windows.Forms.Panel pnl_CreateStartMenuShortcut;
        private IndieGoat.MaterialFramework.Controls.MaterialLabel materialLabel3;
        private IndieGoat.MaterialFramework.Controls.MaterialCheckBox cek_StartMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}