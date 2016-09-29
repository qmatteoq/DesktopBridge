using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;

namespace AppConverter.Step3.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            AppServiceConnection connection = new AppServiceConnection();
            connection.AppServiceName = "CommunicationService";
            connection.PackageFamilyName = Windows.ApplicationModel.Package.Current.Id.FamilyName;
            var result = await connection.OpenAsync();
            if (result == AppServiceConnectionStatus.Success)
            {
                ValueSet valueSet = new ValueSet();
                valueSet.Add("name", txtName.Text);

                var response = await connection.SendMessageAsync(valueSet);
                if (response.Status == AppServiceResponseStatus.Success)
                {
                    string responseMessage = response.Message["response"].ToString();
                    if (responseMessage == "success")
                    {
                        this.Close();
                    }
                }
            }
        }
    }
}
