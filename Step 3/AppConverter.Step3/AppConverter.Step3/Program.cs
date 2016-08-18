using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;

namespace AppConverter.Step3
{
    class Program
    {
        static AppServiceConnection connection = null;

        static void Main(string[] args)
        {
            Thread appServiceThread = new Thread(new ThreadStart(HandleAppServiceConnection));
            appServiceThread.Start();
            Console.ReadLine();
        }

        static async void HandleAppServiceConnection()
        {
            connection = new AppServiceConnection();
            connection.AppServiceName = "CommunicationService";
            connection.PackageFamilyName = Windows.ApplicationModel.Package.Current.Id.FamilyName;
            connection.RequestReceived += Connection_RequestReceived;

            AppServiceConnectionStatus status = await connection.OpenAsync();
            switch (status)
            {
                case AppServiceConnectionStatus.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Connection established - waiting for requests");
                    Console.WriteLine();
                    break;
                case AppServiceConnectionStatus.AppNotInstalled:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The app AppServicesProvider is not installed.");
                    return;
                case AppServiceConnectionStatus.AppUnavailable:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The app AppServicesProvider is not available.");
                    return;
                case AppServiceConnectionStatus.AppServiceUnavailable:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(string.Format("The app AppServicesProvider is installed but it does not provide the app service {0}.", connection.AppServiceName));
                    return;
                case AppServiceConnectionStatus.Unknown:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(string.Format("An unkown error occurred while we were trying to open an AppServiceConnection."));
                    return;
            }
        }

        /// <summary>
        /// Receives message from UWP app and sends a response back
        /// </summary>
        private static async void Connection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            string key = args.Request.Message.First().Key;
            string value = args.Request.Message.First().Value.ToString();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Received message {key} with value {value}");
            if (key == "request")
            {
                string userPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string fileName = $"{userPath}\\centennial.txt";
                File.WriteAllText(fileName, value);

                ValueSet valueSet = new ValueSet();
                string message = $"File written at {DateTime.Now}";
                valueSet.Add("response", message);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Sending response: {message}");
                Console.WriteLine();
                await args.Request.SendResponseAsync(valueSet);
            }
        }
    }
}
