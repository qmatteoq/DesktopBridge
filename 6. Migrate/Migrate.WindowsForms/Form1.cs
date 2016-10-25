using System;
using System.Windows.Forms;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;

namespace Migrate.Uwp.WinForms
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
                        this.Hide();
                    }
                }
            }
        }
    }
}
