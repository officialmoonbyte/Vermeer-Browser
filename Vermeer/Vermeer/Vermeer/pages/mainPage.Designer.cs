namespace Vermeer.Vermeer.pages
{
    partial class mainPage
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
            // mainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(225)))));
            this.BorderSize = 2;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(64)))));
            this.Name = "mainPage";
            this.Showicon = false;
            this.ShowTitleLabel = false;
            this.Sizeable = false;
            this.Text = "Vermeer Web Browser";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainPage_FormClosed);
            this.Load += new System.EventHandler(this.mainPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}