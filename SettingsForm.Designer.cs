
namespace BCITDesktop
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.appSizeComboBox = new System.Windows.Forms.ComboBox();
            this.appSizeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // appSizeComboBox
            // 
            this.appSizeComboBox.FormattingEnabled = true;
            this.appSizeComboBox.Items.AddRange(new object[] {
            "996, 619",
            "640, 480",
            "800, 600",
            "960, 720",
            "1024, 768",
            "1280, 960",
            "1400, 1050",
            "1440, 1080",
            "1600, 1200",
            "1856, 1392",
            "1920, 1440",
            "2048, 1536"});
            this.appSizeComboBox.Location = new System.Drawing.Point(139, 30);
            this.appSizeComboBox.Name = "appSizeComboBox";
            this.appSizeComboBox.Size = new System.Drawing.Size(121, 21);
            this.appSizeComboBox.TabIndex = 0;
            // 
            // appSizeLabel
            // 
            this.appSizeLabel.AutoSize = true;
            this.appSizeLabel.ForeColor = System.Drawing.Color.White;
            this.appSizeLabel.Location = new System.Drawing.Point(33, 33);
            this.appSizeLabel.Name = "appSizeLabel";
            this.appSizeLabel.Size = new System.Drawing.Size(85, 13);
            this.appSizeLabel.TabIndex = 1;
            this.appSizeLabel.Text = "Application Size:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(113)))));
            this.ClientSize = new System.Drawing.Size(275, 450);
            this.Controls.Add(this.appSizeLabel);
            this.Controls.Add(this.appSizeComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox appSizeComboBox;
        private System.Windows.Forms.Label appSizeLabel;
    }
}