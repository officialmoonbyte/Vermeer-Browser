namespace VermeerInstaller.Pages
{
    partial class InstallerPage
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
            this.SuspendLayout();
            // 
            // closebutton
            // 
            this.closebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closebutton.Location = new System.Drawing.Point(459, 3);
            this.closebutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // maxbutton
            // 
            this.maxbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxbutton.Location = new System.Drawing.Point(412, 3);
            this.maxbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maxbutton.TabIndex = 1;
            // 
            // minbutton
            // 
            this.minbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minbutton.Location = new System.Drawing.Point(356, 3);
            this.minbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.minbutton.TabIndex = 2;
            // 
            // InstallerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(510, 600);
            this.Controls.Add(this.closebutton);
            this.Controls.Add(this.maxbutton);
            this.Controls.Add(this.minbutton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "InstallerPage";
            this.ShowTitle = false;
            this.Text = "Vermeer Installer";
            this.Load += new System.EventHandler(this.InstallerPage_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}