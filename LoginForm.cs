using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp;
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
        private PictureBox Logo;
        IFirebaseConfig firebaseConfigurations = new FirebaseConfig()
        {
            AuthSecret = "xyEfrWdHzVWmoXvV11MFgTmMRv8g28oLaJs8kRnH",
            BasePath = "https://bcitdesktop-default-rtdb.firebaseio.com/"
        };


        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.pass = new System.Windows.Forms.Label();
            this.passLog = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.Label();
            this.userLog = new System.Windows.Forms.TextBox();
            this.registerBtn = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.studentRadio = new System.Windows.Forms.RadioButton();
            this.InstructorRadio = new System.Windows.Forms.RadioButton();
            this.Logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // pass
            // 
            this.pass.AutoSize = true;
            this.pass.Location = new System.Drawing.Point(64, 256);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(83, 21);
            this.pass.TabIndex = 18;
            this.pass.Text = "Password: ";
            // 
            // passLog
            // 
            this.passLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passLog.Location = new System.Drawing.Point(162, 256);
            this.passLog.Name = "passLog";
            this.passLog.Size = new System.Drawing.Size(174, 28);
            this.passLog.TabIndex = 17;
            this.passLog.UseSystemPasswordChar = true;
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(64, 196);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(88, 21);
            this.username.TabIndex = 16;
            this.username.Text = "Username: ";
            // 
            // userLog
            // 
            this.userLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLog.Location = new System.Drawing.Point(161, 196);
            this.userLog.Name = "userLog";
            this.userLog.Size = new System.Drawing.Size(174, 28);
            this.userLog.TabIndex = 15;
            this.userLog.TextChanged += new System.EventHandler(this.userLog_TextChanged);
            // 
            // registerBtn
            // 
            this.registerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.registerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerBtn.Location = new System.Drawing.Point(93, 327);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(131, 42);
            this.registerBtn.TabIndex = 19;
            this.registerBtn.Text = "Register User";
            this.registerBtn.UseVisualStyleBackColor = false;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.btnLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLog.ForeColor = System.Drawing.Color.White;
            this.btnLog.Location = new System.Drawing.Point(278, 327);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(82, 42);
            this.btnLog.TabIndex = 20;
            this.btnLog.Text = "Login";
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // studentRadio
            // 
            this.studentRadio.AutoSize = true;
            this.studentRadio.Location = new System.Drawing.Point(140, 166);
            this.studentRadio.Name = "studentRadio";
            this.studentRadio.Size = new System.Drawing.Size(81, 25);
            this.studentRadio.TabIndex = 21;
            this.studentRadio.TabStop = true;
            this.studentRadio.Text = "Student";
            this.studentRadio.UseVisualStyleBackColor = true;
            // 
            // InstructorRadio
            // 
            this.InstructorRadio.AutoSize = true;
            this.InstructorRadio.Location = new System.Drawing.Point(242, 166);
            this.InstructorRadio.Name = "InstructorRadio";
            this.InstructorRadio.Size = new System.Drawing.Size(95, 25);
            this.InstructorRadio.TabIndex = 22;
            this.InstructorRadio.TabStop = true;
            this.InstructorRadio.Text = "Instructor";
            this.InstructorRadio.UseVisualStyleBackColor = true;
            // 
            // Logo
            // 
            this.Logo.Image = global::BCITDesktop.Properties.Resources.bcit;
            this.Logo.Location = new System.Drawing.Point(150, 12);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(168, 136);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 23;
            this.Logo.TabStop = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLog;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(113)))));
            this.ClientSize = new System.Drawing.Size(456, 436);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.InstructorRadio);
            this.Controls.Add(this.studentRadio);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.passLog);
            this.Controls.Add(this.username);
            this.Controls.Add(this.userLog);
            this.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private bool hasEmptyFields()
        {
            if (string.IsNullOrWhiteSpace(userLog.Text) || (string.IsNullOrWhiteSpace(passLog.Text)))
            {
                return true;
            }
            return false;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            client = new FirebaseClient(firebaseConfigurations);
            if (client == null)
            {
                MessageBox.Show("Connection Error");
            }
            else
            {
                MessageBox.Show("Connected");
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            RegistrationForm registration = new RegistrationForm();
            registration.ShowDialog();

        }


        private void btnLog_Click(object sender, EventArgs e)
        {
            if (hasEmptyFields() || !(studentRadio.Checked || InstructorRadio.Checked))
            {
                MessageBox.Show("Please fill in all the fields to proceed");
            }
            else
            {
                // Retrieves data from the database using Get()
                FirebaseResponse response = client.Get(@"Students/" + userLog.Text);
                Student resStudent = response.ResultAs<Student>(); // Database Results
                Student currentStudent = new Student()
                {
                    StudentNumber = userLog.Text,
                    Password = passLog.Text
                };

                if (Student.areTheSameUsers(resStudent, currentStudent))
                {
                    // Passes the student info to the homepage
                    HomeForm home = new HomeForm(resStudent);
                    home.ShowDialog();

                    if (home.DialogResult == DialogResult.Cancel)
                    {
                        userLog.Clear();
                        passLog.Clear();
                        home.Close();
                        home.Dispose();
                    }

                }
                else
                {
                    Student.ShowErrorMessage();
                }
            }
        }

        private void userLog_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
