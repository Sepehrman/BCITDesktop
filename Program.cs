using System;
using System.Windows.Forms;

/// <summary>
/// Term Project, main program/ driver.
/// Authors: Sepehr Mansouri
/// Include here date/revisions: Version 1.0, April 7th 2021.
/// </summary>
namespace BCITDesktop
{
    /// <summary>
    /// Main program/driver class.
    /// Authors: Sepehr Mansouri
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Authors: Sepehr Mansouri
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
