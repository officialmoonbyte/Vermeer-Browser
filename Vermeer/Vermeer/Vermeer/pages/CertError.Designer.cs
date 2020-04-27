namespace Vermeer.Vermeer.pages
{
    partial class CertError
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
            this.materialLabel1 = new Moonbyte.MaterialFramework.Controls.MaterialLabel();
            this.flatButton1 = new Moonbyte.MaterialFramework.Controls.FlatButton();
            this.flatButton2 = new Moonbyte.MaterialFramework.Controls.FlatButton();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.materialLabel1.Location = new System.Drawing.Point(406, 185);
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(68, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "SSL CERT ";
            this.materialLabel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.flatButton1.BackgroundColorClicked = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.flatButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.flatButton1.BorderWidth = 0;
            this.flatButton1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.flatButton1.Location = new System.Drawing.Point(557, 227);
            this.flatButton1.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Opacity = 100;
            this.flatButton1.Size = new System.Drawing.Size(272, 156);
            this.flatButton1.TabIndex = 1;
            this.flatButton1.text = "flatButton1";
            this.flatButton1.TextColor = System.Drawing.Color.Black;
            this.flatButton1.WaveColor = System.Drawing.Color.Black;
            this.flatButton1.Click += new System.EventHandler(this.flatButton1_Click);
            // 
            // flatButton2
            // 
            this.flatButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.flatButton2.BackgroundColorClicked = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.flatButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.flatButton2.BorderWidth = 0;
            this.flatButton2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.flatButton2.Location = new System.Drawing.Point(96, 263);
            this.flatButton2.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.flatButton2.Name = "flatButton2";
            this.flatButton2.Opacity = 100;
            this.flatButton2.Size = new System.Drawing.Size(272, 156);
            this.flatButton2.TabIndex = 2;
            this.flatButton2.text = "flatButton2";
            this.flatButton2.TextColor = System.Drawing.Color.Black;
            this.flatButton2.WaveColor = System.Drawing.Color.Black;
            this.flatButton2.Click += new System.EventHandler(this.flatButton2_Click);
            // 
            // CertError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 450);
            this.Controls.Add(this.flatButton2);
            this.Controls.Add(this.flatButton1);
            this.Controls.Add(this.materialLabel1);
            this.Name = "CertError";
            this.Text = "CertError";
            this.Load += new System.EventHandler(this.CertError_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moonbyte.MaterialFramework.Controls.MaterialLabel materialLabel1;
        private Moonbyte.MaterialFramework.Controls.FlatButton flatButton1;
        private Moonbyte.MaterialFramework.Controls.FlatButton flatButton2;
    }
}