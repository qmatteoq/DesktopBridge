using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Notifications;

namespace AppConverter.Step2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnCreateFile(object sender, EventArgs e)
        {
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fileName = $"{userPath}\\centennial.txt";
            File.WriteAllText(fileName, "This file has been created by a Centennial app");
            ShowNotification();
        }

        public void ShowNotification()
        {
            string xml = @"<toast>
                            <visual>
                                <binding template='ToastGeneric'>
                                    <text>Desktop App Converter</text>
                                    <text>The file has been created</text>
                                </binding>
                            </visual>
                        </toast>";

            Windows.Data.Xml.Dom.XmlDocument doc = new Windows.Data.Xml.Dom.XmlDocument();
            doc.LoadXml(xml);

            ToastNotification toast = new ToastNotification(doc);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
