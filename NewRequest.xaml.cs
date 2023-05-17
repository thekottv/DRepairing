using DRepairing.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
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
    /// Логика взаимодействия для NewRequest.xaml
    /// </summary>
    public partial class NewRequest : Window
    {
        private Request _currentreq = new Request();
        private Device _ddd = new Device(); //костыль для редактирования и добавления
        public NewRequest(Request selectedReq)
        {
            InitializeComponent();
            AppData.db.Request.ToList();
            CBX_Status.ItemsSource = AppData.db.State.ToList();
            if (selectedReq != null)
            {
                _currentreq = selectedReq;
                CBX_Status.SelectedIndex = _currentreq.State.ID - 1;
            }
            else
            {
                _currentreq.DateOfRequest = DateTime.Now;
                CBX_Status.SelectedIndex = 2; // "В ожидании" по дефолту
            }
            DataContext = _currentreq;
        }

        private void Request_Add(object sender, RoutedEventArgs e)
        {
            if (TBX_C_Lastname.Text != "")
            {
                if (_currentreq.ID >= 0)
                {
                    _currentreq.StateID = (CBX_Status.SelectedItem as State).ID;
                    _ddd.Manifucator = TBX_D_Manifucator.Text; //ко
                    _ddd.Model = TBX_D_Model.Text; //сты
                    string StringFromRichTextBox(RichTextBox rtb)
                    {
                        TextRange textRange = new TextRange(
                            // TextPointer to the start of content in the RichTextBox.
                            rtb.Document.ContentStart,
                            // TextPointer to the end of content in the RichTextBox.
                            rtb.Document.ContentEnd
                        );

                        // The Text property on a TextRange object returns a string
                        // representing the plain text content of the TextRange.
                        return textRange.Text;
                    } //ли (получаем данные в переменную из ричтекстбокса)
                    _ddd.MalfunctionInfo = StringFromRichTextBox(TBX_D_Malfunction); //ли

                    DeviceRepairingEntities.GetContext().Request.AddOrUpdate(_currentreq);
                    DeviceRepairingEntities.GetContext().Device.AddOrUpdate(_ddd); //это говно работает, но его желательно бы пофиксить
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
                C_LN_Required.Visibility = Visibility.Visible;
                TBX_C_Lastname.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden; //Костыль чтобы поле загоралось красным

            }
        }
        private void TBX_C_Lastname_TextChanged(object sender, TextChangedEventArgs e)
        {
            TBX_C_Lastname.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled; //костыль чтобы красное поле потухало
            C_LN_Required.Visibility = Visibility.Hidden;
        }
        private void Request_Cancel(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите отменить создание заявки?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes) == MessageBoxResult.Yes)
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
        private void TXB_RepairCost_PreviewTextInput(object sender, TextCompositionEventArgs e) // Repair cost letters handler
        {
            e.Handled = !IsTextAllowed(e.Text, regex_az); //"!"

        }

        private void TBX_LettersOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text, regex_09);
        }
    }
}
