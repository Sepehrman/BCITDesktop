
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
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.Label();
            this.dateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.dobLabel = new System.Windows.Forms.Label();
            this.emailPass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // emailTextBox
            // 
            this.emailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.emailTextBox.Location = new System.Drawing.Point(193, 69);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(200, 34);
            this.emailTextBox.TabIndex = 0;
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Font = new System.Drawing.Font("Nirmala UI", 12F);
            this.email.ForeColor = System.Drawing.Color.White;
            this.email.Location = new System.Drawing.Point(60, 69);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(68, 28);
            this.email.TabIndex = 1;
            this.email.Text = "Email: ";
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
            this.emailPass.Location = new System.Drawing.Point(168, 212);
            this.emailPass.Name = "emailPass";
            this.emailPass.Size = new System.Drawing.Size(128, 57);
            this.emailPass.TabIndex = 4;
            this.emailPass.Text = "Email Password";
            this.emailPass.UseVisualStyleBackColor = false;
            this.emailPass.Click += new System.EventHandler(this.passEmail_OnClick);
            // 
            // ForgotPassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(113)))));
            this.ClientSize = new System.Drawing.Size(457, 352);
            this.Controls.Add(this.emailPass);
            this.Controls.Add(this.dobLabel);
            this.Controls.Add(this.dateOfBirth);
            this.Controls.Add(this.email);
            this.Controls.Add(this.emailTextBox);
            this.Name = "ForgotPassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forgot Password";
            this.Load += new System.EventHandler(this.ForgotPassForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.DateTimePicker dateOfBirth;
        private System.Windows.Forms.Label dobLabel;
        private System.Windows.Forms.Button emailPass;
    }
}