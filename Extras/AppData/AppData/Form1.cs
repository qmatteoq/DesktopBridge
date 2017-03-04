using System;
using System.IO;
using System.Windows.Forms;

namespace AppData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnReadFileFromInstallationFolder(object sender, EventArgs e)
        {
            string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            int index = location.LastIndexOf("\\");
            string path = $"{location.Substring(0, index)}\\test.txt";
            string result = File.ReadAllText(path);
            MessageBox.Show(result);
        }

        private void OnCreateTextFileInAppDataFolder(object sender, EventArgs e)
        {
            string roamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string fullPath = $"{roamingPath}\\AppDataSample";
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            string filePath = $"{fullPath}\\test.txt";
            File.WriteAllText(filePath, "This is a sample text file");
        }

        private void OnFormLoaded(object sender, EventArgs e)
        {
            string roamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string fullPath = $"{roamingPath}\\AppDataSample";
            string destination = $"{fullPath}\\config.txt";
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
                string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                int index = location.LastIndexOf("\\");
                string source = $"{location.Substring(0, index)}\\config.txt";

                File.Copy(source, destination);
            }

            //show the content of the original file
            string beforeUpdate = File.ReadAllText(destination);
            MessageBox.Show(beforeUpdate);

            //show the content after the update
            File.AppendAllText(destination, "\r\nUpdate to the configuration file");
            string afterUpdate = File.ReadAllText(destination);
            MessageBox.Show(afterUpdate);
        }
    }
}
