using System;
using System.IO;
using System.Windows.Forms;

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
            var startupTask = await Windows.ApplicationModel.StartupTask.GetAsync("HelloCentennialTask");
            switch (startupTask.State)
            {
                case Windows.ApplicationModel.StartupTaskState.Disabled:
                    chkBoxStartup.Checked = false;
                    break;
                case Windows.ApplicationModel.StartupTaskState.DisabledByUser:
                    chkBoxStartup.Checked = false;
                    break;
                case Windows.ApplicationModel.StartupTaskState.Enabled:
                    chkBoxStartup.Checked = true;
                    break;
            }
        }

        private async void chkBoxStartup_Click(object sender, EventArgs e)
        {
            var startupTask = await Windows.ApplicationModel.StartupTask.GetAsync("HelloCentennialTask");
            if (startupTask.State == Windows.ApplicationModel.StartupTaskState.Enabled)
            {
                startupTask.Disable();
                chkBoxStartup.Checked = false;
                MessageBox.Show("The task has been disabled");
            }
            else
            {
                var state = await startupTask.RequestEnableAsync();
                switch (state)
                {
                    case Windows.ApplicationModel.StartupTaskState.DisabledByUser:
                        MessageBox.Show("The task has been disabled by the user");
                        chkBoxStartup.Checked = false;
                        break;
                    case Windows.ApplicationModel.StartupTaskState.Enabled:
                        MessageBox.Show("The task has been enabled");
                        chkBoxStartup.Checked = true;
                        break;
                }
            }
        }
    }
}