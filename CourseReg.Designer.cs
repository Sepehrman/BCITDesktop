
namespace BCITDesktop
{
    partial class CourseReg
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.regBtn = new System.Windows.Forms.Button();
            this.crsName = new System.Windows.Forms.TextBox();
            this.crsID = new System.Windows.Forms.TextBox();
            this.instrName = new System.Windows.Forms.TextBox();
            this.credits = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Course Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Course ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Instructor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Credits:";
            // 
            // regBtn
            // 
            this.regBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.regBtn.Location = new System.Drawing.Point(89, 292);
            this.regBtn.Name = "regBtn";
            this.regBtn.Size = new System.Drawing.Size(75, 23);
            this.regBtn.TabIndex = 4;
            this.regBtn.Text = "Register";
            this.regBtn.UseVisualStyleBackColor = false;
            this.regBtn.Click += new System.EventHandler(this.regBtn_Click);
            // 
            // crsName
            // 
            this.crsName.Location = new System.Drawing.Point(133, 28);
            this.crsName.Name = "crsName";
            this.crsName.Size = new System.Drawing.Size(100, 22);
            this.crsName.TabIndex = 6;
            // 
            // crsID
            // 
            this.crsID.Location = new System.Drawing.Point(133, 91);
            this.crsID.Name = "crsID";
            this.crsID.Size = new System.Drawing.Size(100, 22);
            this.crsID.TabIndex = 7;
            // 
            // instrName
            // 
            this.instrName.Location = new System.Drawing.Point(133, 147);
            this.instrName.Name = "instrName";
            this.instrName.Size = new System.Drawing.Size(100, 22);
            this.instrName.TabIndex = 8;
            // 
            // credits
            // 
            this.credits.Location = new System.Drawing.Point(133, 208);
            this.credits.Name = "credits";
            this.credits.Size = new System.Drawing.Size(100, 22);
            this.credits.TabIndex = 9;
            // 
            // CourseReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(113)))));
            this.ClientSize = new System.Drawing.Size(260, 357);
            this.Controls.Add(this.credits);
            this.Controls.Add(this.instrName);
            this.Controls.Add(this.crsID);
            this.Controls.Add(this.crsName);
            this.Controls.Add(this.regBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "CourseReg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CourseReg";
            this.Load += new System.EventHandler(this.CourseReg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button regBtn;
        private System.Windows.Forms.TextBox crsName;
        private System.Windows.Forms.TextBox crsID;
        private System.Windows.Forms.TextBox instrName;
        private System.Windows.Forms.TextBox credits;
    }
}