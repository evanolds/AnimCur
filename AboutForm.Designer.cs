namespace AnimCur
{
    partial class AboutForm
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
            this.iOSLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.gitHubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // iOSLinkLabel
            // 
            this.iOSLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iOSLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iOSLinkLabel.Location = new System.Drawing.Point(12, 32);
            this.iOSLinkLabel.Name = "iOSLinkLabel";
            this.iOSLinkLabel.Size = new System.Drawing.Size(163, 26);
            this.iOSLinkLabel.TabIndex = 0;
            this.iOSLinkLabel.TabStop = true;
            this.iOSLinkLabel.Text = "Link to my iOS apps";
            this.iOSLinkLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iOSLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.iOSLinkLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Developed by Evan Olds";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gitHubLinkLabel
            // 
            this.gitHubLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gitHubLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gitHubLinkLabel.Location = new System.Drawing.Point(12, 58);
            this.gitHubLinkLabel.Name = "gitHubLinkLabel";
            this.gitHubLinkLabel.Size = new System.Drawing.Size(163, 23);
            this.gitHubLinkLabel.TabIndex = 2;
            this.gitHubLinkLabel.TabStop = true;
            this.gitHubLinkLabel.Text = "Link to my GitHub";
            this.gitHubLinkLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.gitHubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gitHubLinkLabel_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 90);
            this.Controls.Add(this.gitHubLinkLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iOSLinkLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AboutForm";
            this.Text = "About";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel iOSLinkLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel gitHubLinkLabel;
    }
}