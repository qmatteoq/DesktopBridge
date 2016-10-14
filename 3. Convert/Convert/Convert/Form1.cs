using Convert.Model;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace Convert
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
        }

        private void OnSerializeData(object sender, EventArgs e)
        {
            Person person = new Person();
            person.Name = "Matteo";
            person.Surname = "Pagani";

            var json = JsonConvert.SerializeObject(person);
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fileName = $"{userPath}\\person.txt";
            File.WriteAllText(fileName, json);
        }
    }
}
