using AppConverter.Step1.Model;
using Newtonsoft.Json;
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

namespace AppConverter.Step1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(Program.parameter))
            {
                parameter.Text = Program.parameter;
            }
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
