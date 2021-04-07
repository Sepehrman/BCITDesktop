
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
            this.courseIDLabel = new System.Windows.Forms.Label();
            this.courseNameLabel = new System.Windows.Forms.Label();
            this.closeFormBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // courseIDLabel
            // 
            this.courseIDLabel.AutoSize = true;
            this.courseIDLabel.Font = new System.Drawing.Font("Nirmala UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseIDLabel.ForeColor = System.Drawing.Color.White;
            this.courseIDLabel.Location = new System.Drawing.Point(12, 9);
            this.courseIDLabel.Name = "courseIDLabel";
            this.courseIDLabel.Size = new System.Drawing.Size(0, 38);
            this.courseIDLabel.TabIndex = 4;
            // 
            // courseNameLabel
            // 
            this.courseNameLabel.AutoSize = true;
            this.courseNameLabel.Font = new System.Drawing.Font("Nirmala UI", 20.25F);
            this.courseNameLabel.ForeColor = System.Drawing.Color.White;
            this.courseNameLabel.Location = new System.Drawing.Point(33, 56);
            this.courseNameLabel.Name = "courseNameLabel";
            this.courseNameLabel.Size = new System.Drawing.Size(21, 30);
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
            // CourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(113)))));
            this.ClientSize = new System.Drawing.Size(783, 541);
            this.Controls.Add(this.closeFormBtn);
            this.Controls.Add(this.courseNameLabel);
            this.Controls.Add(this.courseIDLabel);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "CourseForm";
            this.Text = "CourseForm";
            this.Load += new System.EventHandler(this.CourseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label courseIDLabel;
        private System.Windows.Forms.Label courseNameLabel;
        private System.Windows.Forms.Button closeFormBtn;
    }
}