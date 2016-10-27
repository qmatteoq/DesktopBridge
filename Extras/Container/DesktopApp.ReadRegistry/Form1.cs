using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp.ReadRegistry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

private void OnReadRegistryKey(Object sender, EventArgs e)
{
    bool isAppInstalled = false;

    var RegKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Matteo Pagani\DesktopBridge", true);
    if (RegKey != null)
    {
        string result = RegKey.GetValue("IsAppInstalled").ToString();
        isAppInstalled = result == "True" ? true : false;
    }

    string message = isAppInstalled ? "The app is installed" : "The app isn't installed";
    MessageBox.Show(message);
}
    }
}
