namespace Vermeer_Installer
{
    partial class VermeerInstaller
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
            this.SuspendLayout();
            // 
            // closebutton
            // 
            this.closebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closebutton.Location = new System.Drawing.Point(-424, 2);
            this.closebutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.closebutton.Size = new System.Drawing.Size(72, 45);
            // 
            // maxbutton
            // 
            this.maxbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxbutton.Location = new System.Drawing.Point(-496, 2);
            this.maxbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maxbutton.Size = new System.Drawing.Size(72, 45);
            this.maxbutton.TabIndex = 1;
            // 
            // minbutton
            // 
            this.minbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minbutton.Location = new System.Drawing.Point(-568, 2);
            this.minbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.minbutton.Size = new System.Drawing.Size(72, 45);
            this.minbutton.TabIndex = 2;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Title.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(26, 6);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(134, 21);
            this.lbl_Title.TabIndex = 4;
            this.lbl_Title.Text = "Vermeer Installer";
            // 
            // VermeerInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.closebutton);
            this.Controls.Add(this.maxbutton);
            this.Controls.Add(this.minbutton);
            this.EnableMaxButton = false;
            this.EnableMinButton = false;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VermeerInstaller";
            this.ShowIcon = false;
            this.ShowTitle = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vermeer Installer";
            this.Load += new System.EventHandler(this.VermeerInstaller_Load);
            this.Controls.SetChildIndex(this.minbutton, 0);
            this.Controls.SetChildIndex(this.maxbutton, 0);
            this.Controls.SetChildIndex(this.closebutton, 0);
            this.Controls.SetChildIndex(this.lbl_Title, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private IndieGoat.MaterialFramework.Controls.MaterialLabel lbl_Title;
    }
}