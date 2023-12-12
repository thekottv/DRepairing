using DRepairing.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        private Users _currentUser = new Users();
        bool IsNewUser = false;
        public NewUser(Users selectedUser)
        {
            InitializeComponent();
            AppData.db.Users.ToList();
            CBX_Role.ItemsSource = AppData.db.Role.ToList();
            if (selectedUser != null)
            {
                _currentUser = selectedUser;
                CBX_Role.SelectedIndex = _currentUser.Role.ID - 1;
            }
            else
            {
                IsNewUser = true;
                CBX_Role.SelectedIndex = 0; // Админ по дефолту
            }
            DataContext = _currentUser;
        }
        private void User_Add(object sender, RoutedEventArgs e)
        {
            string pWord = _currentUser.Password;
            bool NoPWordRestriction = ((IsNewUser == true && TBX_PWord.Text != "") | (IsNewUser == false && TBX_PWord.Text != "") | (IsNewUser == false && TBX_PWord.Text == "") ); //Исключает создание пользователя с пустым паролем
            if (TBX_Lastname.Text != "" && NoPWordRestriction)
            {
                if (_currentUser.ID >= 0)
                {
                    _currentUser.RoleID = (CBX_Role.SelectedItem as Role).ID;
                    if (TBX_PWord.Text != "")
                        pWord = MD5Gen.MD5Hash(TBX_PWord.Text);
                    _currentUser.Password = pWord;
                    DeviceRepairingEntities.GetContext().Users.AddOrUpdate(_currentUser);
                }



                try
                {
                    DeviceRepairingEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                    Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
            else
            {
                if (TBX_Lastname.Text == "")
                {
                    LN_Required.Visibility = Visibility.Visible;
                    TBX_Lastname.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden; //Костыль чтобы поле загоралось красным
                }
                if (TBX_PWord.Text == "" && IsNewUser == true)
                {
                    PWord_Required.Visibility = Visibility.Visible;
                    TBX_PWord.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden; //Костыль чтобы поле загоралось красным
                }

            }
        }
        private void TBX_Lastname_TextChanged(object sender, TextChangedEventArgs e)
        {
            TBX_Lastname.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled; //костыль чтобы красное поле потухало
            LN_Required.Visibility = Visibility.Hidden;
        }
        private void TBX_PWord_TextChanged(object sender, TextChangedEventArgs e)
        {
            TBX_PWord.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled; //костыль чтобы красное поле потухало
            PWord_Required.Visibility = Visibility.Hidden;
        }

        private void User_Cancel(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите отменить создание пользователя?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private static readonly string regex_az = "^[a-zA-Z]+$"; //Regex for names
        private static readonly string regex_09 = "^[0-9]+$"; //Regex for digits

        private static bool IsTextAllowed(string Text, string AllowedRegex) // Handling wrong symbols in textboxes to prevent type conflicts
        {
            try
            {
                var regex = new Regex(AllowedRegex);
                return !regex.IsMatch(Text);
            }
            catch
            {
                return true;
            }
        }
        private void TBX_LettersOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text, regex_09);
        }
    }
}
