using Microsoft.Win32;
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
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using DRepairing.Model;
using System.IO;

namespace DRepairing
{
    /// <summary>
    /// Логика взаимодействия для DB_BackupWizard.xaml
    /// </summary>
    public partial class DB_BackupWizard : Window
    {
        public static string serverName = "DRGNBOOK\\SQLEXPRESS"; //Change if using with another SQL Server
        public static string databaseName = "DeviceRepairing";
        public string ToSave; //Backup file save path
        public string ToRestore;  //Backup restore file path
        public string BackupDir = $"{AppDomain.CurrentDomain.BaseDirectory}DB Backups";
        public DB_BackupWizard()
        {
            InitializeComponent();
            BTN_DoBackup.IsEnabled = false;
            BTN_DoRestore.IsEnabled = false;
            if (!Directory.Exists(BackupDir)) { Directory.CreateDirectory(BackupDir); }
        }

        private void BC_Done(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTN_Restore_Path_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = BackupDir;
            openFileDialog1.Filter = "Database Backup Files (*.bak)|*.bak";
            openFileDialog1.Title = "Выберите путь c файлом резервной копии";
            openFileDialog1.DefaultExt = "bak";
            openFileDialog1.ShowDialog();
            ToRestore = openFileDialog1.FileName;
            if (openFileDialog1.FileName != string.Empty)
            {
                TBX_Restore.Text = openFileDialog1.FileName;
                BTN_DoRestore.IsEnabled = true;
            }

        }

        private void BTN_Create_Path_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.InitialDirectory = BackupDir;
            SaveFileDialog1.Filter = "Database Backup Files (*.bak)|*.bak";
            SaveFileDialog1.Title = "Выберите путь для сохранения резервной копии";
            SaveFileDialog1.DefaultExt = "bak";
            SaveFileDialog1.ShowDialog();
            ToSave = SaveFileDialog1.FileName;
            if (SaveFileDialog1.FileName != string.Empty)
            {
                TBX_Backup.Text = SaveFileDialog1.FileName;
            }
        }

        private void BTN_DoBackup_Click(object sender, RoutedEventArgs e)
        {
            BackupMaker();
        }

        private void BTN_DoRestore_Click(object sender, RoutedEventArgs e)
        {
            RestoreMaker();
        }

        private void TBX_Restore_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBX_Restore.Text != string.Empty) { BTN_DoRestore.IsEnabled = true; }
            else                                  { BTN_DoRestore.IsEnabled = false; }
        }

        private void TBX_Backup_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBX_Backup.Text != string.Empty) { BTN_DoBackup.IsEnabled = true; }
            else                                 { BTN_DoBackup.IsEnabled = false; }
        }
        private void BackupMaker()
        {
            ServerConnection serverConnection = new ServerConnection(serverName);
            Server server = new Server(serverConnection);
            Backup backup = new Backup() { Action = BackupActionType.Database, Database = databaseName };
            try
            {
                backup.Devices.AddDevice(ToSave, DeviceType.File);
                backup.Initialize = true;

                try
                {
                    backup.SqlBackup(server);
                    MessageBox.Show("Резервное копирование успешно завершено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Во время резервного копирования произошла ошибка: " + ex.Message, "Ошибка резервного копирования", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Неправильно указан путь.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                BTN_DoBackup.IsEnabled = false;
            }
        }

        private void RestoreMaker()
        {
            string databaseFileName = ToRestore;

            if (File.Exists(ToRestore))
            {
                try
                {
                    string connectionString = $"Data Source={serverName};Initial Catalog=master;Integrated Security=True;";


                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = $"ALTER DATABASE {databaseName} SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE {databaseName} FROM DISK = '{databaseFileName}' WITH REPLACE; ALTER DATABASE {databaseName} SET MULTI_USER";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Восстановление базы данных завершено.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Во время восстановления базы данных произошла ошибка: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Неправильно указан путь.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                BTN_DoRestore.IsEnabled = false;
            }
        }
    }
}
