﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace BCITDesktop
{
    public partial class LoginForm : Form
    {
        // This is the database connection

        IFirebaseClient client;
        private Label pass;
        private TextBox passLog;
        private Label username;
        private TextBox userLog;
        private Button registerBtn;
        private Button btnLog;

        IFirebaseConfig firebaseConfigurations = new FirebaseConfig()
        {
            AuthSecret = "xyEfrWdHzVWmoXvV11MFgTmMRv8g28oLaJs8kRnH",
            BasePath = "https://bcitdesktop-default-rtdb.firebaseio.com/"
        };


        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(firebaseConfigurations);
            }

            catch
            {
                MessageBox.Show("Connection Error");
            }

        }

        private void InitializeComponent()
        {
            this.pass = new System.Windows.Forms.Label();
            this.passLog = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.Label();
            this.userLog = new System.Windows.Forms.TextBox();
            this.registerBtn = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pass
            // 
            this.pass.AutoSize = true;
            this.pass.Location = new System.Drawing.Point(65, 139);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(59, 13);
            this.pass.TabIndex = 18;
            this.pass.Text = "Password: ";
            // 
            // passLog
            // 
            this.passLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passLog.Location = new System.Drawing.Point(163, 139);
            this.passLog.Name = "passLog";
            this.passLog.Size = new System.Drawing.Size(174, 28);
            this.passLog.TabIndex = 17;
            this.passLog.UseSystemPasswordChar = true;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(65, 79);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(61, 13);
            this.username.TabIndex = 16;
            this.username.Text = "Username: ";
            // 
            // userLog
            // 
            this.userLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLog.Location = new System.Drawing.Point(162, 79);
            this.userLog.Name = "userLog";
            this.userLog.Size = new System.Drawing.Size(174, 28);
            this.userLog.TabIndex = 15;
            // 
            // registerBtn
            // 
            this.registerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerBtn.Location = new System.Drawing.Point(95, 243);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(131, 42);
            this.registerBtn.TabIndex = 19;
            this.registerBtn.Text = "Register User";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // btnLog
            // 
            this.btnLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLog.Location = new System.Drawing.Point(280, 243);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(82, 42);
            this.btnLog.TabIndex = 20;
            this.btnLog.Text = "Login";
            this.btnLog.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(456, 436);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.passLog);
            this.Controls.Add(this.username);
            this.Controls.Add(this.userLog);
            this.Name = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            RegistrationForm registration = new RegistrationForm();
            registration.ShowDialog();

        }
    }
}