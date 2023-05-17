using DRepairing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;

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
            DGridUsers.ItemsSource = DeviceRepairingEntities.GetContext().Users.ToList();

            BTN_Edit.IsEnabled = false;
            BTN_Remove.IsEnabled = false;
            BTN_EditUser.IsEnabled = false;
            BTN_RemoveUser.IsEnabled = false;

            switch (MainWindow.Globals.UserRole)//Role Restrictions
            {
                case 2: //Operator
                    {
                        UsersTab.Visibility = Visibility.Hidden;
                        BTN_Report.Visibility = Visibility.Hidden;
                        break;
                    }
                case 3: //Engineer
                    {
                        UsersTab.Visibility = Visibility.Hidden;
                        BTN_New.Visibility = Visibility.Hidden;
                        BTN_Edit.Visibility = Visibility.Hidden;
                        BTN_Remove.Visibility = Visibility.Hidden;
                        BTN_Report.Visibility = Visibility.Hidden;
                        break;
                    }
                case 4: //Warehouseman
                    {
                        UsersTab.Visibility = Visibility.Hidden;
                        BTN_New.Visibility = Visibility.Hidden;
                        BTN_Edit.Visibility = Visibility.Hidden;
                        BTN_Remove.Visibility = Visibility.Hidden;
                        BTN_Report.Visibility = Visibility.Hidden;
                        break;
                    }
            }

        }

        private void ChangeUser(object sender, RoutedEventArgs e)
        {
            MainWindow Logout = new MainWindow();
            Logout.Show();
            this.Close();
        }

        private void NewReqButton(object sender, RoutedEventArgs e)
        {
            NewRequest newRequest = new NewRequest(null);
            newRequest.ShowDialog();
            DGridRequests.ItemsSource = AppData.db.Request.ToList();
            DGridRequests.Items.Refresh();
        }

        private void EditReqButton(object sender, RoutedEventArgs e)
        {
            var CurrentRequest = DGridRequests.SelectedItem as Request;
            NewRequest newRequest = new NewRequest((CurrentRequest) as Request);
            newRequest.ShowDialog();

            DGridRequests.Items.Refresh();
            //баг - при добавлении или удалении записи рефреш перестаёт работать. Удаление такого необновленного элемента, офк, вызывает ошибку
        }
        private void RemoveReqButton(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить эту запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    var CurrentRequest = DGridRequests.SelectedItem as Request;
                    DeviceRepairingEntities.GetContext().Request.Remove(DGridRequests.SelectedItem as Request);
                    DeviceRepairingEntities.GetContext().SaveChanges();

                    DGridRequests.ItemsSource = AppData.db.Request.ToList();
                    DGridRequests.Items.Refresh();
                    MessageBox.Show("Удаление завершено");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Что то пошло не так...\nОкно будет перезагружено\n\n{ex}");
                    MainW Mainw = new MainW();
                    Mainw.Show();
                    this.Close();
                }
                //баг - если селекшн не дай бог загорится белым - селектнутый элемент больше нельзя будет удалить до следующего добавления или удаления другого элемента
            }
        }

        private void More_Click(object sender, RoutedEventArgs e)
        {
            var CurrentRequest = DGridRequests.SelectedItem as Request;
            MoreWindow MoreWindow = new MoreWindow((CurrentRequest) as Request);
            MoreWindow.Show();    //MoreWindow.ShowDialog(); после реализации редактирования в окне

            DGridRequests.Items.Refresh();
        }

        private void DGridRequests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DGridRequests.SelectedItem != null)
            {
                BTN_Edit.IsEnabled = true;
                BTN_Remove.IsEnabled = true;
            }
            else 
            {
                BTN_Edit.IsEnabled = false; 
                BTN_Remove.IsEnabled = false; 
            }
        }
        private void DGridUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DGridUsers.SelectedItem != null)
            {
                BTN_EditUser.IsEnabled = true;
                BTN_RemoveUser.IsEnabled = true;
            }
            else
            {
                BTN_EditUser.IsEnabled = false;
                BTN_RemoveUser.IsEnabled = false;
            }
        }
        private void NewRepornButton(object sender, RoutedEventArgs e)
        {
            var allRequests = DeviceRepairingEntities.GetContext().Request.ToList();

            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph userParagraph = document.Paragraphs.Add();
            Word.Range userRange = userParagraph.Range;
            userRange.Text = "Данные о заявках";

            userRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table requestsTable = document.Tables.Add(tableRange, allRequests.Count() + 1, 8);
            requestsTable.Borders.InsideLineStyle = requestsTable.Borders.OutsideLineStyle
                = Word.WdLineStyle.wdLineStyleSingle;
            requestsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = requestsTable.Cell(1, 1).Range;
            cellRange.Text = "№";
            cellRange = requestsTable.Cell(1, 2).Range;
            cellRange.Text = "Фамилия";
            cellRange = requestsTable.Cell(1, 3).Range;
            cellRange.Text = "Телефон";
            cellRange = requestsTable.Cell(1, 4).Range;
            cellRange.Text = "Дата заявки";
            cellRange = requestsTable.Cell(1, 5).Range;
            cellRange.Text = "Статус";
            cellRange = requestsTable.Cell(1, 6).Range;
            cellRange.Text = "Состояние";
            cellRange = requestsTable.Cell(1, 7).Range;
            cellRange.Text = "Модель устройства";
            cellRange = requestsTable.Cell(1, 8).Range;
            cellRange.Text = "Сумма ремонта";


            requestsTable.Rows[1].Range.Bold = 1;
            requestsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < allRequests.Count(); i++)
            {
                var currentCategory = allRequests[i];
                if (currentCategory.C_LastName != null)
                {
                    cellRange = requestsTable.Cell(i + 2, 1).Range;
                    cellRange.Text = Convert.ToString(currentCategory.ID);
                    cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    cellRange = requestsTable.Cell(i + 2, 2).Range;
                    cellRange.Text = Convert.ToString(currentCategory.C_LastName);

                    cellRange = requestsTable.Cell(i + 2, 3).Range;
                    cellRange.Text = Convert.ToString(currentCategory.C_PhoneNumber);

                    cellRange = requestsTable.Cell(i + 2, 4).Range;
                    cellRange.Text = currentCategory.DateOfRequest.ToString("dd.MM.yyyy");

                    cellRange = requestsTable.Cell(i + 2, 5).Range;
                    cellRange.Text = Convert.ToString((currentCategory.IsAccepted == true) ? "Принято" : "Отказано");

                    cellRange = requestsTable.Cell(i + 2, 6).Range;
                    cellRange.Text = Convert.ToString(currentCategory.State.RequestState);

                    cellRange = requestsTable.Cell(i + 2, 7).Range;
                    cellRange.Text = Convert.ToString(currentCategory.Device.Model);

                    cellRange = requestsTable.Cell(i + 2, 8).Range;
                    cellRange.Text = Convert.ToString(currentCategory.RepairCost);
                }
            }

            application.Visible = true;
        }
        private void NewUserButton(object sender, RoutedEventArgs e)
        {
            NewUser NewUser = new NewUser(null);
            NewUser.ShowDialog();
            DGridUsers.ItemsSource = AppData.db.Users.ToList();
            DGridUsers.Items.Refresh();
        }

        private void EditUserButton(object sender, RoutedEventArgs e)
        {
            var CurrentUser = DGridUsers.SelectedItem as Users;
            NewUser NewUser = new NewUser((CurrentUser) as Users);
            NewUser.ShowDialog();

            DGridRequests.Items.Refresh();
            //баг - при добавлении или удалении записи рефреш перестаёт работать. Удаление такого необновленного элемента, офк, вызывает ошибку
        }
        private void RemoveUserButton(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить эту запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    var CurrentUser = DGridUsers.SelectedItem as Users;
                    DeviceRepairingEntities.GetContext().Users.Remove(DGridUsers.SelectedItem as Users);
                    DeviceRepairingEntities.GetContext().SaveChanges();

                    DGridUsers.ItemsSource = AppData.db.Users.ToList();
                    DGridUsers.Items.Refresh();
                    MessageBox.Show("Удаление завершено");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Что то пошло не так...\nОкно будет перезагружено\n\n{ex}");
                    MainW Mainw = new MainW(); //Переоткрывает окно после ошибки для её устранения
                    Mainw.Show();
                    this.Close();

                }
                //баг - если селекшн не дай бог загорится белым - селектнутый элемент больше нельзя будет удалить до следующего добавления или удаления другого элемента
            }
        }
    }
}
