using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCITDesktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Image MyImage = Image.FromFile(".../Resources/home.png");
            this.HomeButton.Image = (Image)(new Bitmap(MyImage, new Size(32, 32)));
        }
    }
}
