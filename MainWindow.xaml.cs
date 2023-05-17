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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DRepairing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TextBoxLogin.Focus();
        }
        public static class Globals //Глобальные переменные для разграничения 
        {
            public static int UserRole;
            public static string UserName;
            public static Users userinfo { get; set; }
        }

        private void Login_button(object sender, RoutedEventArgs e)
        {
            string pword = MD5Gen.MD5Hash(TextBoxPassword.Text);
            var CurrentUser = AppData.db.Users.FirstOrDefault(u => u.Login == TextBoxLogin.Text && u.Password == pword); //Разграничение с проверкой логина и пароля
            if (CurrentUser != null)
            {
                Globals.UserRole = CurrentUser.RoleID;
                Globals.userinfo = CurrentUser;
                Globals.UserName = CurrentUser.FirstName;
                TextBoxLogin.IsEnabled = false;
                TextBoxPassword.IsEnabled = false;

                MainW window0 = new MainW();
                window0.CurrentUserMSG.Text += $"{Globals.UserName} ({Globals.userinfo.Role.Role1})"; //велком такой-то челик переменная
                window0.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неправильное имя пользователя или пароль.");
            }
        }
    }
}
