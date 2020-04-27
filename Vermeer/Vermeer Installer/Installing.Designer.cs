namespace Vermeer_Installer
{
    partial class Installing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Installing));
            this.progressbar_Progress = new Moonbyte.MaterialFramework.Controls.MaterialProgressBar();
            this.btn_Cancel = new Moonbyte.MaterialFramework.Controls.FlatButton();
            this.label_DownloadTitle = new Moonbyte.MaterialFramework.Controls.MaterialLabel();
            this.panelDownload = new System.Windows.Forms.Panel();
            this.label_DownloadUpdate = new Moonbyte.MaterialFramework.Controls.MaterialLabel();
            this.panelDownload.SuspendLayout();
            this.SuspendLayout();
            // 
            // closebutton
            // 
            this.closebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closebutton.Location = new System.Drawing.Point(-303, 2);
            this.closebutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // maxbutton
            // 
            this.maxbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxbutton.Location = new System.Drawing.Point(-375, 2);
            this.maxbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maxbutton.TabIndex = 1;
            this.maxbutton.Visible = false;
            // 
            // minbutton
            // 
            this.minbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minbutton.Location = new System.Drawing.Point(-447, 2);
            this.minbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.minbutton.TabIndex = 2;
            this.minbutton.Visible = false;
            // 
            // progressbar_Progress
            // 
            this.progressbar_Progress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.progressbar_Progress.Location = new System.Drawing.Point(73, 60);
            this.progressbar_Progress.Maximum = 100;
            this.progressbar_Progress.Minimum = 0;
            this.progressbar_Progress.Name = "progressbar_Progress";
            this.progressbar_Progress.ProgressBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(176)))), ((int)(((byte)(37)))));
            this.progressbar_Progress.Size = new System.Drawing.Size(372, 23);
            this.progressbar_Progress.TabIndex = 4;
            this.progressbar_Progress.Value = 0;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btn_Cancel.BackgroundColorClicked = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btn_Cancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btn_Cancel.BorderWidth = 0;
            this.btn_Cancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(201, 127);
            this.btn_Cancel.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Opacity = 100;
            this.btn_Cancel.Size = new System.Drawing.Size(109, 33);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.text = "Cancel";
            this.btn_Cancel.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.btn_Cancel.WaveColor = System.Drawing.Color.Black;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label_DownloadTitle
            // 
            this.label_DownloadTitle.AutoSize = true;
            this.label_DownloadTitle.BackColor = System.Drawing.Color.Transparent;
            this.label_DownloadTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label_DownloadTitle.Location = new System.Drawing.Point(2, 5);
            this.label_DownloadTitle.Name = "label_DownloadTitle";
            this.label_DownloadTitle.Size = new System.Drawing.Size(94, 19);
            this.label_DownloadTitle.TabIndex = 6;
            this.label_DownloadTitle.Text = "Downloading!";
            this.label_DownloadTitle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // panelDownload
            // 
            this.panelDownload.Controls.Add(this.label_DownloadUpdate);
            this.panelDownload.Controls.Add(this.label_DownloadTitle);
            this.panelDownload.Location = new System.Drawing.Point(152, 89);
            this.panelDownload.Name = "panelDownload";
            this.panelDownload.Size = new System.Drawing.Size(293, 27);
            this.panelDownload.TabIndex = 7;
            // 
            // label_DownloadUpdate
            // 
            this.label_DownloadUpdate.AutoSize = true;
            this.label_DownloadUpdate.BackColor = System.Drawing.Color.Transparent;
            this.label_DownloadUpdate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label_DownloadUpdate.Location = new System.Drawing.Point(96, 5);
            this.label_DownloadUpdate.Name = "label_DownloadUpdate";
            this.label_DownloadUpdate.Size = new System.Drawing.Size(120, 19);
            this.label_DownloadUpdate.TabIndex = 7;
            this.label_DownloadUpdate.Text = "%downloadData%";
            this.label_DownloadUpdate.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // Installing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 172);
            this.Controls.Add(this.panelDownload);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.progressbar_Progress);
            this.Controls.Add(this.closebutton);
            this.Controls.Add(this.maxbutton);
            this.Controls.Add(this.minbutton);
            this.EnableMaxButton = false;
            this.EnableMinButton = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Installing";
            this.Sizeable = false;
            this.Snapable = false;
            this.Text = "Vermeer Installer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Installing_FormClosing);
            this.Load += new System.EventHandler(this.Installing_Load);
            this.Controls.SetChildIndex(this.minbutton, 0);
            this.Controls.SetChildIndex(this.maxbutton, 0);
            this.Controls.SetChildIndex(this.closebutton, 0);
            this.Controls.SetChildIndex(this.progressbar_Progress, 0);
            this.Controls.SetChildIndex(this.btn_Cancel, 0);
            this.Controls.SetChildIndex(this.panelDownload, 0);
            this.panelDownload.ResumeLayout(false);
            this.panelDownload.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Moonbyte.MaterialFramework.Controls.MaterialProgressBar progressbar_Progress;
        private Moonbyte.MaterialFramework.Controls.FlatButton btn_Cancel;
        private Moonbyte.MaterialFramework.Controls.MaterialLabel label_DownloadTitle;
        private System.Windows.Forms.Panel panelDownload;
        private Moonbyte.MaterialFramework.Controls.MaterialLabel label_DownloadUpdate;
    }
}