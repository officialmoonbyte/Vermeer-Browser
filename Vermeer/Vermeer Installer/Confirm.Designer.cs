namespace Vermeer_Installer
{
    partial class Confirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Confirm));
            this.label_Title = new Moonbyte.MaterialFramework.Controls.MaterialLabel();
            this.button_Submit = new Moonbyte.MaterialFramework.Controls.FlatButton();
            this.materialLabel2 = new Moonbyte.MaterialFramework.Controls.MaterialLabel();
            this.label_AlphaWarning = new Moonbyte.MaterialFramework.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // closebutton
            // 
            this.closebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closebutton.Location = new System.Drawing.Point(570, 1);
            this.closebutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // maxbutton
            // 
            this.maxbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxbutton.Location = new System.Drawing.Point(174, 1);
            this.maxbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.maxbutton.Size = new System.Drawing.Size(195, 28);
            this.maxbutton.TabIndex = 1;
            this.maxbutton.Visible = false;
            // 
            // minbutton
            // 
            this.minbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minbutton.Location = new System.Drawing.Point(377, 1);
            this.minbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.minbutton.Size = new System.Drawing.Size(195, 28);
            this.minbutton.TabIndex = 2;
            this.minbutton.Visible = false;
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.BackColor = System.Drawing.Color.Transparent;
            this.label_Title.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label_Title.Location = new System.Drawing.Point(51, 45);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(499, 60);
            this.label_Title.TabIndex = 3;
            this.label_Title.Text = "Welcome to one of the most powerful web browser\'s! Before we start you \r\nhave to " +
    "click on the install button. Clicking on the button below, you \r\nagree to our te" +
    "rms of service.";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Title.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.label_Title.Click += new System.EventHandler(this.label_Title_Click);
            // 
            // button_Submit
            // 
            this.button_Submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(240)))));
            this.button_Submit.BackgroundColorClicked = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.button_Submit.BorderColor = System.Drawing.Color.Gainsboro;
            this.button_Submit.BorderWidth = 0;
            this.button_Submit.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.button_Submit.Location = new System.Drawing.Point(187, 131);
            this.button_Submit.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.button_Submit.Name = "button_Submit";
            this.button_Submit.Opacity = 100;
            this.button_Submit.Size = new System.Drawing.Size(224, 55);
            this.button_Submit.TabIndex = 4;
            this.button_Submit.text = "Install Vermeer now!";
            this.button_Submit.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.button_Submit.WaveColor = System.Drawing.Color.Black;
            this.button_Submit.Click += new System.EventHandler(this.button_Submit_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.materialLabel2.Location = new System.Drawing.Point(-15, -15);
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(98, 19);
            this.materialLabel2.TabIndex = 5;
            this.materialLabel2.Text = "materialLabel2";
            this.materialLabel2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // label_AlphaWarning
            // 
            this.label_AlphaWarning.AutoSize = true;
            this.label_AlphaWarning.BackColor = System.Drawing.Color.Transparent;
            this.label_AlphaWarning.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_AlphaWarning.Location = new System.Drawing.Point(159, 206);
            this.label_AlphaWarning.Name = "label_AlphaWarning";
            this.label_AlphaWarning.Size = new System.Drawing.Size(268, 15);
            this.label_AlphaWarning.TabIndex = 6;
            this.label_AlphaWarning.Text = "Vermeer is currently in alpha, There may be bugs! ";
            this.label_AlphaWarning.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // Confirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 247);
            this.Controls.Add(this.label_AlphaWarning);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.button_Submit);
            this.Controls.Add(this.label_Title);
            this.Controls.Add(this.closebutton);
            this.Controls.Add(this.maxbutton);
            this.Controls.Add(this.minbutton);
            this.EnableMaxButton = false;
            this.EnableMinButton = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Confirm";
            this.Sizeable = false;
            this.Snapable = false;
            this.Text = "Vermeer Installer";
            this.Load += new System.EventHandler(this.Confirm_Load);
            this.Controls.SetChildIndex(this.minbutton, 0);
            this.Controls.SetChildIndex(this.maxbutton, 0);
            this.Controls.SetChildIndex(this.closebutton, 0);
            this.Controls.SetChildIndex(this.label_Title, 0);
            this.Controls.SetChildIndex(this.button_Submit, 0);
            this.Controls.SetChildIndex(this.materialLabel2, 0);
            this.Controls.SetChildIndex(this.label_AlphaWarning, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moonbyte.MaterialFramework.Controls.MaterialLabel label_Title;
        private Moonbyte.MaterialFramework.Controls.FlatButton button_Submit;
        private Moonbyte.MaterialFramework.Controls.MaterialLabel materialLabel2;
        private Moonbyte.MaterialFramework.Controls.MaterialLabel label_AlphaWarning;
    }
}

