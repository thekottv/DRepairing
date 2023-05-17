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
    /// Логика взаимодействия для MoreWindow.xaml
    /// </summary>
    public partial class MoreWindow : Window
    {
        private Request _currentreq = new Request();
        public MoreWindow(Request selectedReq)
        {
            InitializeComponent();
            AppData.db.Request.ToList();
            if (selectedReq != null)
            {
                _currentreq = selectedReq;
            }
            DataContext = selectedReq;

            RTBX_MalfunctionInfo.IsEnabled = false; //temp

            string status = (selectedReq.IsAccepted == true) ? "Принято": "Отказано";
            //Присваивание без контекста из-за того, что лейблы являются заголовками, и забиндить контент не выйдет
            LB_Title.Content = $"{LB_Title.Content} №{selectedReq.ID}";
            LB_FIO.Content = $"{LB_FIO.Content} {selectedReq.C_LastName}";
            LB_Phone.Content = $"{LB_Phone.Content} {selectedReq.C_PhoneNumber}";
            LB_Date.Content = $"{LB_Date.Content} {selectedReq.DateOfRequest}";
            LB_Status.Content = $"{LB_Status.Content} {status}";
            LB_State.Content = $"{LB_State.Content} {selectedReq.State.RequestState}";
            LB_RepairCost.Content = $"{LB_RepairCost.Content} {selectedReq.RepairCost} рублей";

            LB_DeviceManifucator.Content = $"{LB_DeviceManifucator.Content} {selectedReq.Device.Manifucator}";
            LB_DeviceModel.Content = $"{LB_DeviceModel.Content} {selectedReq.Device.Model}";


        }
        //private void EnableSaveButton(object sender, RoutedEventArgs e) //Включает кнопку при нажатии на эдит или изменении текста текстбокса (textbox TextChanged)
        //{
        //    string tbx = new TextRange(RTBX_MalfunctionInfo.Document.ContentStart, RTBX_MalfunctionInfo.Document.ContentEnd).Text; //строка, получающая текстбокс с \r\n
        //    string tbx2;
        //    if (tbx != "") //При инизиализации, текстбокс получает контент не сразу.
        //    {
        //        tbx2 = tbx.Remove(tbx.Length - 2, 2); //получаем очищеный от \r\n текстбокс
        //        if (BTN_Save != null && _currentreq.Device.MalfunctionInfo != tbx2) //сравниваем содержимое текстбокса с изначальным. Только вот, блять, это "изначальное содержимое" автоматически подсасывает контент текстбокса, за каким-то хуем лол епта"
        //            BTN_Save.IsEnabled = true;
        //    }
        //    //Проверка, существует ли кнопка и неравен ли изменённый текст в ричтекстбоксе инфе из бд
        //}
        private void SaveInfo(object sender, RoutedEventArgs e)
        {
            this.Close();//temp
        }

        private void BTN_EditStatus_Click(object sender, RoutedEventArgs e)
        {

            //EnableSaveButton(null, null);
        }
        private void BTN_EditState_Click(object sender, RoutedEventArgs e)
        {
            //EnableSaveButton(null, null);
        }
        private void BTN_EditRepairCost_Click(object sender, RoutedEventArgs e)
        {
            //EnableSaveButton(null, null);
        }
        private void Grid_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)// Костыль, назначающий кнопкам редактирования правильные позиции около соответствующих лейблов, потому что WPF не идеален
        {
            //BTN_EditStatus.Visibility = Visibility.Visible;
            //Thickness statusMargin = LB_Status.Margin;
            //statusMargin.Left += LB_Status.ActualWidth;
            //statusMargin.Top += 5;
            //BTN_EditStatus.Margin = statusMargin;

            //BTN_EditState.Visibility = Visibility.Visible;
            //Thickness stateMargin = LB_State.Margin;
            //stateMargin.Left += LB_State.ActualWidth;
            //stateMargin.Top += 5;
            //BTN_EditState.Margin = stateMargin;

            //BTN_EditRepairCost.Visibility = Visibility.Visible;
            //Thickness repairCostMargin = LB_RepairCost.Margin;
            //repairCostMargin.Left += LB_RepairCost.ActualWidth;
            //repairCostMargin.Top += 5;
            //BTN_EditRepairCost.Margin = repairCostMargin;
        }
    }
}
