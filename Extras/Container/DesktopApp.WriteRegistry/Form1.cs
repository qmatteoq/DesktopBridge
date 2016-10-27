using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.WriteRegistry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnCreateRegistryKey(Object sender, EventArgs e)
        {
            var RegKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Matteo Pagani\DesktopBridge", true);

            if (RegKey == null)
            {
                RegKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Matteo Pagani\DesktopBridge", RegistryKeyPermissionCheck.ReadWriteSubTree);
                RegKey.SetValue("IsAppInstalled", true);
            }
        }

        private void OnOpenReadApp(Object sender, EventArgs e)
        {
            Directory.GetCurrentDirectory();
            string result = System.Reflection.Assembly.GetExecutingAssembly().Location;
            int index = result.LastIndexOf("\\");
            string processPath = $"{result.Substring(0, index)}\\DesktopApp.ReadRegistry.exe";
            Process.Start(processPath);
        }
    }
}
