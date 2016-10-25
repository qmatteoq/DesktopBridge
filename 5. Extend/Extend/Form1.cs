using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.Background;
using Windows.Storage;

namespace Extend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void OnRegisterTask(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMessage.Text))
            {
                ApplicationData.Current.LocalSettings.Values.Clear();
                ApplicationData.Current.LocalSettings.Values.Add("message", txtMessage.Text);
            }

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
            var status = await BackgroundExecutionManager.RequestAccessAsync();
            if (status != BackgroundAccessStatus.DeniedByUser && status != BackgroundAccessStatus.DeniedBySystemPolicy)
            {
                builder.Register();
            }
        }
    }
}
