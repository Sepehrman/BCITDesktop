
namespace BCITDesktop
{
    partial class CourseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourseForm));
            this.courseIDLabel = new System.Windows.Forms.Label();
            this.courseNameLabel = new System.Windows.Forms.Label();
            this.closeFormBtn = new System.Windows.Forms.Button();
            this.announcementLabel = new System.Windows.Forms.Label();
            this.announcementPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addAnnoBtn = new System.Windows.Forms.Button();
            this.annoTextBox = new System.Windows.Forms.TextBox();
            this.announcementPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // courseIDLabel
            // 
            this.courseIDLabel.AutoSize = true;
            this.courseIDLabel.Font = new System.Drawing.Font("Nirmala UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseIDLabel.ForeColor = System.Drawing.Color.White;
            this.courseIDLabel.Location = new System.Drawing.Point(12, 9);
            this.courseIDLabel.Name = "courseIDLabel";
            this.courseIDLabel.Size = new System.Drawing.Size(0, 47);
            this.courseIDLabel.TabIndex = 4;
            // 
            // courseNameLabel
            // 
            this.courseNameLabel.AutoSize = true;
            this.courseNameLabel.Font = new System.Drawing.Font("Nirmala UI", 20.25F);
            this.courseNameLabel.ForeColor = System.Drawing.Color.White;
            this.courseNameLabel.Location = new System.Drawing.Point(33, 56);
            this.courseNameLabel.Name = "courseNameLabel";
            this.courseNameLabel.Size = new System.Drawing.Size(26, 37);
            this.courseNameLabel.TabIndex = 5;
            this.courseNameLabel.Text = "";
            // 
            // closeFormBtn
            // 
            this.closeFormBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.closeFormBtn.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeFormBtn.ForeColor = System.Drawing.Color.White;
            this.closeFormBtn.Location = new System.Drawing.Point(738, 9);
            this.closeFormBtn.Name = "closeFormBtn";
            this.closeFormBtn.Size = new System.Drawing.Size(33, 23);
            this.closeFormBtn.TabIndex = 6;
            this.closeFormBtn.Text = "X";
            this.closeFormBtn.UseVisualStyleBackColor = false;
            this.closeFormBtn.Click += new System.EventHandler(this.closeFormBtn_Click);
            // 
            // announcementLabel
            // 
            this.announcementLabel.AutoSize = true;
            this.announcementLabel.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.announcementLabel.Location = new System.Drawing.Point(3, 0);
            this.announcementLabel.Name = "announcementLabel";
            this.announcementLabel.Size = new System.Drawing.Size(165, 30);
            this.announcementLabel.TabIndex = 7;
            this.announcementLabel.Text = "Announcements";
            // 
            // announcementPanel
            // 
            this.announcementPanel.Controls.Add(this.announcementLabel);
            this.announcementPanel.Location = new System.Drawing.Point(40, 135);
            this.announcementPanel.Name = "announcementPanel";
            this.announcementPanel.Size = new System.Drawing.Size(253, 338);
            this.announcementPanel.TabIndex = 8;
            // 
            // addAnnoBtn
            // 
            this.addAnnoBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.addAnnoBtn.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAnnoBtn.ForeColor = System.Drawing.Color.White;
            this.addAnnoBtn.Location = new System.Drawing.Point(260, 104);
            this.addAnnoBtn.Name = "addAnnoBtn";
            this.addAnnoBtn.Size = new System.Drawing.Size(33, 23);
            this.addAnnoBtn.TabIndex = 9;
            this.addAnnoBtn.Text = "+";
            this.addAnnoBtn.UseVisualStyleBackColor = false;
            this.addAnnoBtn.Click += new System.EventHandler(this.addAnnoBtn_Click);
            // 
            // annoTextBox
            // 
            this.annoTextBox.Location = new System.Drawing.Point(48, 106);
            this.annoTextBox.Name = "annoTextBox";
            this.annoTextBox.Size = new System.Drawing.Size(206, 20);
            this.annoTextBox.TabIndex = 10;
            // 
            // CourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(113)))));
            this.ClientSize = new System.Drawing.Size(783, 541);
            this.Controls.Add(this.annoTextBox);
            this.Controls.Add(this.addAnnoBtn);
            this.Controls.Add(this.announcementPanel);
            this.Controls.Add(this.closeFormBtn);
            this.Controls.Add(this.courseNameLabel);
            this.Controls.Add(this.courseIDLabel);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CourseForm";
            this.Text = "CourseForm";
            this.Load += new System.EventHandler(this.CourseForm_Load);
            this.announcementPanel.ResumeLayout(false);
            this.announcementPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label courseIDLabel;
        private System.Windows.Forms.Label courseNameLabel;
        private System.Windows.Forms.Button closeFormBtn;
        private System.Windows.Forms.Label announcementLabel;
        private System.Windows.Forms.FlowLayoutPanel announcementPanel;
        private System.Windows.Forms.Button addAnnoBtn;
        private System.Windows.Forms.TextBox annoTextBox;
    }
}