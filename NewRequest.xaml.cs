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
    /// Логика взаимодействия для NewRequest.xaml
    /// </summary>
    public partial class NewRequest : Window
    {
        private Request _currentreq = new Request();
        public NewRequest(Request selectedReq)
        {
            InitializeComponent();
            AppData.db.Request.ToList();
            if (selectedReq != null)
            {
                _currentreq = selectedReq
                //Date = DateTime.Now;
            }
            else
            {
                _currentsotr.Date = DateTime.Now;
            }
            DataContext = _currentsotr;
        }
    }
}
