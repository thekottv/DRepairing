using DRepairing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DRepairing
{
    /// <summary>
    /// Логика взаимодействия для MainW.xaml
    /// </summary>
    public partial class MainW : Window
    {
        public MainW()
        {
            InitializeComponent();
            DGridRequests.ItemsSource = DeviceRepairingEntities.GetContext().Request.ToList();
        }

        private void ChangeUser(object sender, RoutedEventArgs e)
        {
            MainWindow Logout = new MainWindow();
            Logout.Show();
            this.Close();
        }

        private void NewReqButton(object sender, RoutedEventArgs e)
        {
            NewRequest newRequest = new NewRequest((sender as Button).DataContext as Request);
            NewRequest.Show();
            this.Close();
        }
    }
}
