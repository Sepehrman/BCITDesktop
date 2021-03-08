using System;
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
        private RadioButton studentRadio;
        private RadioButton InstructorRadio;
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
            this.studentRadio = new System.Windows.Forms.RadioButton();
            this.InstructorRadio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // pass
            // 
            this.pass.AutoSize = true;
            this.pass.Location = new System.Drawing.Point(65, 210);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(86, 20);
            this.pass.TabIndex = 18;
            this.pass.Text = "Password: ";
            // 
            // passLog
            // 
            this.passLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passLog.Location = new System.Drawing.Point(163, 210);
            this.passLog.Name = "passLog";
            this.passLog.Size = new System.Drawing.Size(174, 28);
            this.passLog.TabIndex = 17;
            this.passLog.UseSystemPasswordChar = true;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(65, 150);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(91, 20);
            this.username.TabIndex = 16;
            this.username.Text = "Username: ";
            // 
            // userLog
            // 
            this.userLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLog.Location = new System.Drawing.Point(162, 150);
            this.userLog.Name = "userLog";
            this.userLog.Size = new System.Drawing.Size(174, 28);
            this.userLog.TabIndex = 15;
            // 
            // registerBtn
            // 
            this.registerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerBtn.Location = new System.Drawing.Point(94, 281);
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
            this.btnLog.Location = new System.Drawing.Point(279, 281);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(82, 42);
            this.btnLog.TabIndex = 20;
            this.btnLog.Text = "Login";
            this.btnLog.UseVisualStyleBackColor = true;
            // 
            // studentRadio
            // 
            this.studentRadio.AutoSize = true;
            this.studentRadio.Location = new System.Drawing.Point(141, 31);
            this.studentRadio.Name = "studentRadio";
            this.studentRadio.Size = new System.Drawing.Size(84, 24);
            this.studentRadio.TabIndex = 21;
            this.studentRadio.TabStop = true;
            this.studentRadio.Text = "Student";
            this.studentRadio.UseVisualStyleBackColor = true;
            // 
            // InstructorRadio
            // 
            this.InstructorRadio.AutoSize = true;
            this.InstructorRadio.Location = new System.Drawing.Point(243, 31);
            this.InstructorRadio.Name = "InstructorRadio";
            this.InstructorRadio.Size = new System.Drawing.Size(95, 24);
            this.InstructorRadio.TabIndex = 22;
            this.InstructorRadio.TabStop = true;
            this.InstructorRadio.Text = "Instructor";
            this.InstructorRadio.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(456, 436);
            this.Controls.Add(this.InstructorRadio);
            this.Controls.Add(this.studentRadio);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.passLog);
            this.Controls.Add(this.username);
            this.Controls.Add(this.userLog);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
