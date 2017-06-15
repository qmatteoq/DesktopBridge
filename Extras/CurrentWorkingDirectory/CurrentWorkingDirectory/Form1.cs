using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurrentWorkingDirectory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnDisplayCurrentWorkingDirectory(object sender, EventArgs e)
        {
            labelCWD.Text = Environment.CurrentDirectory;
        }

        private void OnLaunchSecondApp(object sender, EventArgs e)
        {
            string result = System.Reflection.Assembly.GetExecutingAssembly().Location;
            int index = result.LastIndexOf("\\");
            string processPath = $"{result.Substring(0, index)}\\CurrentWorkingDirectory2.exe";
            Process.Start(processPath);
        }

        private void OnLaunchSecondAppWithLauncher(object sender, EventArgs e)
        {
            string path = $"{Environment.CurrentDirectory}\\CurrentWorkingDirectory2.exe";
            Process.Start(path);
        }
    }
}
