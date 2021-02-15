using RequestForRepairWPF.DataGrid;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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

namespace RequestForRepairWPF
{
    /// <summary>
    /// Логика взаимодействия для AllUsers.xaml
    /// </summary>
    public partial class AllUsers : Window
    {
        private string action = string.Empty;
        private int mainID = 0;
        DataBase dataBase = new DataBase();
        UserContext db;

        public AllUsers(int mainID)
        {
            InitializeComponent();

            this.mainID = mainID;
            //this.action = usersAction;
            db = new UserContext();
            db.Users.Load(); // загружаем данные
            DataGrid_AllUsers.ItemsSource = db.Users.Local.ToBindingList(); // Устанавливаем привязку к кэшу



            /// Инициализация элементов управления
            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                //бургер меню
                list_AllUsers.Visibility = Visibility.Visible;
                list_Customers.Visibility = Visibility.Visible;
                list_Executors.Visibility = Visibility.Visible;
                list_RegisterNewUser.Visibility = Visibility.Visible;
                list_EditUserAccount.Visibility = Visibility.Visible;
                list_CreateRequest.Visibility = Visibility.Collapsed;
                list_WatchRequest.Visibility = Visibility.Visible;
                list_WatchArchiveRequest.Visibility = Visibility.Visible;
                list_FileReport.Visibility = Visibility.Visible;
                btn_Edit.IsEnabled = false;

            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {

                //бургер меню
                list_AllUsers.Visibility = Visibility.Collapsed;
                list_Customers.Visibility = Visibility.Collapsed;
                list_Executors.Visibility = Visibility.Collapsed;
                list_RegisterNewUser.Visibility = Visibility.Collapsed;
                list_EditUserAccount.Visibility = Visibility.Visible;
                list_CreateRequest.Visibility = Visibility.Visible;
                list_WatchRequest.Visibility = Visibility.Visible;
                list_WatchArchiveRequest.Visibility = Visibility.Visible;
                list_FileReport.Visibility = Visibility.Visible;
                btn_Edit.IsEnabled = false;


            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {

                //бургер меню
                list_AllUsers.Visibility = Visibility.Collapsed;
                list_Customers.Visibility = Visibility.Collapsed;
                list_Executors.Visibility = Visibility.Collapsed;
                list_RegisterNewUser.Visibility = Visibility.Collapsed;
                list_EditUserAccount.Visibility = Visibility.Visible;
                list_CreateRequest.Visibility = Visibility.Collapsed;
                list_WatchRequest.Visibility = Visibility.Visible;
                list_WatchArchiveRequest.Visibility = Visibility.Visible;
                list_FileReport.Visibility = Visibility.Visible;
                btn_Edit.IsEnabled = false;

            }
        }

        private void btn_PopUpPersonalAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_PopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            // ДИАЛОГОВЫЕ ОКНА
            MessageBox.Show("БЛАБЛАБЛАБЛА, ТУТ ДОЛЖНО БЫТЬ ДИЛОГОВОЕ ОКНО");
            Authorization authorization = new Authorization();
            this.Close();
            authorization.Show();
        }

        private void btn_CloseMenu_Click(object sender, RoutedEventArgs e)
        {
            btn_OpenMenu.Visibility = Visibility.Visible;
            btn_CloseMenu.Visibility = Visibility.Collapsed;
        }

        private void btn_OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btn_OpenMenu.Visibility = Visibility.Collapsed;
            btn_CloseMenu.Visibility = Visibility.Visible;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_UpdateData_Click(object sender, RoutedEventArgs e)
        {
            comboBox_Search.Text = string.Empty;
            textBox_DataForSearch.Text = string.Empty;
            db.Dispose(); // Чистка старых  данных
            db.Users.Load(); // загружаем данные
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
