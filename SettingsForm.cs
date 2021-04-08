using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BCITDesktop.Properties;
/// <summary>
/// Term Project App settings form. 
/// Authors: Eric Dong
/// Include here date/revisions: Version 1.0, April 7th 2021.
/// </summary>
namespace BCITDesktop
{
    /// <summary>
    /// Settings form of app.
    /// Authors: Eric Dong
    /// </summary>
    public partial class SettingsForm : Form
    {
        Student student;
        HomeForm homeref;

        /// <summary>
        /// Initializer.
        /// Authors: Eric Dong
        /// </summary>
        /// <param name="student">Student object that represents the user.</param>
        /// <param name="homeref"></param>
        public SettingsForm(Student student, HomeForm homeref)
        {
            InitializeComponent();
            this.student = student;
            this.homeref = homeref;

            this.appSizeComboBox.SelectedItem = null;
            String defaultSize = "";
            defaultSize += Settings.Default.ApplicationSize.Height + ", " + Settings.Default.ApplicationSize.Width;
            this.appSizeComboBox.SelectedText = defaultSize;
        }    

        /// <summary>
        /// Click handler to open form for editing user settings.
        /// Authors: Eric Dong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void openUserProfileSettings(Object sender, EventArgs e)
        {
            Console.WriteLine(this.student.FirstName);
            userDataBaseSettings userSettingsForm = new userDataBaseSettings(student, homeref);
            userSettingsForm.ShowDialog();
        }

        /// <summary>
        /// Changes the app size in user scope.
        /// Authors: Eric Dong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetNewWindowsSize(Object sender, EventArgs e)
        {
            // parses the string in the combobox into two strings.
            // found on https://stackoverflow.com/questions/57205656/c-sharp-split-the-string-by-white-spaces-and-remove-the-comma
            var size = appSizeComboBox.SelectedItem.ToString().Split(" ,".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries).ToArray();

            Size newSize = new Size();
            newSize.Width = Int32.Parse(size[0]);
            newSize.Height = Int32.Parse(size[1]);

            // changes the value in settings.
            // found on https://www.codeproject.com/Articles/15013/Windows-Forms-User-Settings-in-C
            if (this.WindowState == FormWindowState.Normal)
            {
                Settings.Default.ApplicationSize = newSize;
            }
            else
            {
                Settings.Default.ApplicationSize = this.RestoreBounds.Size;
            }

            Settings.Default.Save();
        }
    }
}
