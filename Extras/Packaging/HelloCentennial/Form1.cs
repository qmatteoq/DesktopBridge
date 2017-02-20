using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Windows.ApplicationModel.Background;

namespace HelloCentennial
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

        private async void Form1_Load(object sender, EventArgs e)
        {
            DesktopBridge.Helpers helpers = new DesktopBridge.Helpers();
            bool isUwp = helpers.IsRunningAsUwp();
            isUwpLabel.Text = isUwp ? "The app is running inside the UWP container" : "The app is running as desktop app";

            string triggerName = "TimeZoneTriggerTest";

            // Check if the task is already registered
            foreach (var cur in BackgroundTaskRegistration.AllTasks)
            {
                if (cur.Value.Name == triggerName)
                {
                    // The task is already registered.
                    return;
                }
            }

            BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
            builder.Name = triggerName;
            builder.SetTrigger(new SystemTrigger(SystemTriggerType.TimeZoneChange, false));
            builder.TaskEntryPoint = "TileBackgroundTask.TileTask";
            builder.Register();
        }
    }
}
