using RealmDesktop.Model;
using Realms;
using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace RealmDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Realm realm;

        public MainWindow()
        {
            InitializeComponent();
            InitializeRealm();
        }

        private void InitializeRealm()
        {
            string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\RealmDesktop";
            bool isDatabaseInitialized = Directory.Exists(path);
            if (!isDatabaseInitialized)
            {
                Directory.CreateDirectory(path);
            }

            string file = $"{path}\\default.realm";

            RealmConfiguration config = new RealmConfiguration(file);
            realm = Realm.GetInstance(config);
        }

        private void OnSaveUser(object sender, RoutedEventArgs e)
        {
            realm.Write(() =>
            {
                Person person = new Person
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text
                };

                realm.Add(person);
            });

            txtName.Text = string.Empty;
            txtSurname.Text = string.Empty;
        }

        private void OnGetCount(object sender, RoutedEventArgs e)
        {
            var list = realm.All<Person>();
            MessageBox.Show($"Number of customers: {list.Count()}");
        }

        private void OnListCustomers(object sender, RoutedEventArgs e)
        {
            var result = realm.All<Person>().ToList();
            listCustomers.ItemsSource = result;
        }

        private void OnUpdateCustomer(object sender, RoutedEventArgs e)
        {
            Person person = realm.All<Person>().FirstOrDefault(x => x.Surname == "Pagani");
            realm.Write(() =>
            {
                person.Name = "Giulia";
            });
        }
    }
}
