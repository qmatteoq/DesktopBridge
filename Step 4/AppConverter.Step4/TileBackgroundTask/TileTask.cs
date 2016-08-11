using System;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace TileBackgroundTask
{
    public sealed class TileTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            string tileXml = $@"<tile>
                            <visual>
                                <binding template='TileMedium' branding='logo'>
                                    <group>
                                        <subgroup>
                                            <text hint-style='caption'>Time zone changed!</text>
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

            string toastXml = $@"<toast>
                            <visual>
                                <binding template='ToastGeneric'>
                                    <text>Time zone changed!</text>
                                    <text>Last update at {DateTime.Now}</text>
                                </binding>
                            </visual>
                        </toast>";

            Windows.Data.Xml.Dom.XmlDocument toastDoc = new Windows.Data.Xml.Dom.XmlDocument();
            toastDoc.LoadXml(toastXml);

            ToastNotification toast = new ToastNotification(toastDoc);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
