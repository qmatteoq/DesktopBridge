using DesktopBridge;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Windows.Data.Xml.Dom;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Notifications;

namespace Enhance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (IsRunningAsUwp())
            {
                txtUwp.Text = "I'm running inside a UWP container";
            }
            else
            {
                txtUwp.Text = "I'm running as a native desktop app";
            }
        }

        private bool IsRunningAsUwp()
        {
            Helpers helpers = new Helpers();
            return helpers.IsRunningAsUwp();
        }

        private void OnCreateFile(object sender, EventArgs e)
        {
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fileName = $"{userPath}\\centennial.txt";
            File.WriteAllText(fileName, "This file has been created by a Centennial app");
            ShowNotification();
        }

        [Conditional("DesktopUWP")]
        public void ShowNotification()
        {
            string xml = @"<toast>
            <visual>
                <binding template='ToastGeneric'>
                    <text>Desktop Bridge</text>
                    <text>The file has been created</text>
                </binding>
            </visual>
        </toast>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            ToastNotification toast = new ToastNotification(doc);
            ToastNotificationManager.CreateToastNotifier().Show(toast);


            string tileXml = $@"<tile>
                            <visual>
                                <binding template='TileMedium' branding='logo'>
                                    <group>
                                        <subgroup>
                                            <text hint-style='caption'>The file has been created!</text>
                                            <text hint-style='captionSubtle' hint-wrap='true'>Last update at {DateTime.Now}</text>
                                        </subgroup>
                                    </group>
                                </binding>
                            </visual>
                        </tile>";

            XmlDocument tileDoc = new XmlDocument();
            tileDoc.LoadXml(tileXml);

            TileNotification notification = new TileNotification(tileDoc);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
        }

        [Conditional("DesktopUWP")]
        private async void GenerateAudio()
        {
            SpeechSynthesizer speech = new SpeechSynthesizer();
            var result = await speech.SynthesizeTextToStreamAsync("Hello cenntennial");

            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fileName = $"{userPath}\\speech.wav";

            using (FileStream stream = File.Create(fileName))
            {
                await result.AsStreamForRead().CopyToAsync(stream);
                await stream.FlushAsync();
            }
        }

        private void OnGenerateAudio(object sender, EventArgs e)
        {
            GenerateAudio();
        }
    }
}
