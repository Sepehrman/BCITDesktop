
namespace BCITDesktop
{
    partial class ForgotPassForm
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
            this.IdNumTextBox = new System.Windows.Forms.TextBox();
            this.studentNum = new System.Windows.Forms.Label();
            this.dateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.dobLabel = new System.Windows.Forms.Label();
            this.emailPass = new System.Windows.Forms.Button();
            this.InstructorRadio = new System.Windows.Forms.RadioButton();
            this.studentRadio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // IdNumTextBox
            // 
            this.IdNumTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.IdNumTextBox.Location = new System.Drawing.Point(193, 69);
            this.IdNumTextBox.Name = "IdNumTextBox";
            this.IdNumTextBox.Size = new System.Drawing.Size(200, 34);
            this.IdNumTextBox.TabIndex = 0;
            // 
            // studentNum
            // 
            this.studentNum.AutoSize = true;
            this.studentNum.Font = new System.Drawing.Font("Nirmala UI", 12F);
            this.studentNum.ForeColor = System.Drawing.Color.White;
            this.studentNum.Location = new System.Drawing.Point(12, 68);
            this.studentNum.Name = "studentNum";
            this.studentNum.Size = new System.Drawing.Size(167, 28);
            this.studentNum.TabIndex = 1;
            this.studentNum.Text = "Student Number: ";
            // 
            // dateOfBirth
            // 
            this.dateOfBirth.Location = new System.Drawing.Point(193, 152);
            this.dateOfBirth.Name = "dateOfBirth";
            this.dateOfBirth.Size = new System.Drawing.Size(200, 22);
            this.dateOfBirth.TabIndex = 2;
            // 
            // dobLabel
            // 
            this.dobLabel.AutoSize = true;
            this.dobLabel.Font = new System.Drawing.Font("Nirmala UI", 12F);
            this.dobLabel.ForeColor = System.Drawing.Color.White;
            this.dobLabel.Location = new System.Drawing.Point(28, 146);
            this.dobLabel.Name = "dobLabel";
            this.dobLabel.Size = new System.Drawing.Size(132, 28);
            this.dobLabel.TabIndex = 3;
            this.dobLabel.Text = "Date of Birth: ";
            // 
            // emailPass
            // 
            this.emailPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.emailPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.emailPass.ForeColor = System.Drawing.Color.White;
            this.emailPass.Location = new System.Drawing.Point(158, 256);
            this.emailPass.Name = "emailPass";
            this.emailPass.Size = new System.Drawing.Size(128, 57);
            this.emailPass.TabIndex = 4;
            this.emailPass.Text = "Email Password";
            this.emailPass.UseVisualStyleBackColor = false;
            this.emailPass.Click += new System.EventHandler(this.passEmail_OnClick);
            // 
            // InstructorRadio
            // 
            this.InstructorRadio.AutoSize = true;
            this.InstructorRadio.Font = new System.Drawing.Font("Nirmala UI", 12F);
            this.InstructorRadio.ForeColor = System.Drawing.Color.White;
            this.InstructorRadio.Location = new System.Drawing.Point(84, 194);
            this.InstructorRadio.Name = "InstructorRadio";
            this.InstructorRadio.Size = new System.Drawing.Size(117, 32);
            this.InstructorRadio.TabIndex = 5;
            this.InstructorRadio.TabStop = true;
            this.InstructorRadio.Text = "Instructor";
            this.InstructorRadio.UseVisualStyleBackColor = true;
            // 
            // studentRadio
            // 
            this.studentRadio.AutoSize = true;
            this.studentRadio.Font = new System.Drawing.Font("Nirmala UI", 12F);
            this.studentRadio.ForeColor = System.Drawing.Color.White;
            this.studentRadio.Location = new System.Drawing.Point(238, 194);
            this.studentRadio.Name = "studentRadio";
            this.studentRadio.Size = new System.Drawing.Size(101, 32);
            this.studentRadio.TabIndex = 6;
            this.studentRadio.TabStop = true;
            this.studentRadio.Text = "Student";
            this.studentRadio.UseVisualStyleBackColor = true;
            // 
            // ForgotPassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(113)))));
            this.ClientSize = new System.Drawing.Size(457, 352);
            this.Controls.Add(this.studentRadio);
            this.Controls.Add(this.InstructorRadio);
            this.Controls.Add(this.emailPass);
            this.Controls.Add(this.dobLabel);
            this.Controls.Add(this.dateOfBirth);
            this.Controls.Add(this.studentNum);
            this.Controls.Add(this.IdNumTextBox);
            this.Name = "ForgotPassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forgot Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IdNumTextBox;
        private System.Windows.Forms.Label studentNum;
        private System.Windows.Forms.DateTimePicker dateOfBirth;
        private System.Windows.Forms.Label dobLabel;
        private System.Windows.Forms.Button emailPass;
        private System.Windows.Forms.RadioButton InstructorRadio;
        private System.Windows.Forms.RadioButton studentRadio;
    }
}