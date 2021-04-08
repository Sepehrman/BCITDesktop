using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCITDesktop.Properties;

namespace BCITDesktop
{
    public partial class SettingsForm : Form
    {
        Student student;
        HomeForm homeref;

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

        public void openUserProfileSettings(Object sender, EventArgs e)
        {
            Console.WriteLine(this.student.FirstName);
            userDataBaseSettings userSettingsForm = new userDataBaseSettings(student, homeref);
            userSettingsForm.ShowDialog();
        }

        public void SetNewWindowsSize(Object sender, EventArgs e)
        {
            // found on https://stackoverflow.com/questions/57205656/c-sharp-split-the-string-by-white-spaces-and-remove-the-comma
            var size = appSizeComboBox.SelectedItem.ToString().Split(" ,".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries).ToArray();

            Size newSize = new Size();
            newSize.Width = Int32.Parse(size[0]);
            newSize.Height = Int32.Parse(size[1]);
            Console.WriteLine(newSize);

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
