using RequestForRepairWPF.Data;
using RequestForRepairWPF.DataGrid;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace RequestForRepairWPF.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для WatchRequests.xaml
    /// </summary>
    public partial class WatchRequests_View : Window
    {
        private int mainID = 0;
        private string typeRequest = string.Empty;
        DataBase dataBase = new DataBase();
        _RequestContext db_R = new _RequestContext();
        UserContext db_U = new UserContext();
        public WatchRequests_View(int mainID, string typeRequest)
        {
            InitializeComponent();

            this.mainID = mainID;
            this.typeRequest = typeRequest;

            #region Инициализация бургер-меню
            ///<summary>
            ///Инициализация бургер-меню
            /// </summary>
            /// 
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
            #endregion

            #region Загрузка данных
            /// <summary>
            /// Загрузка данных
            /// </summary>
            /// 

            //string query = "SELECT id_request, name_request, date_start, date_end, status_request, room_number, category_request FROM Requests WHERE status_request != 'В архиве' AND id_request IN (SELECT requestID FROM U_R_Customers WHERE userID = '" + mainID + "');";
            if (typeRequest == "Текущие")
            {
                db_R._Requests.Load();


                var queryRequest = from q in db_R._Requests
                            where q.status_request != "В архиве"
                            select new
                            {
                                q.id_request,
                                q.name_request,
                                q.date_start,
                                q.date_end,
                                q.status_request,
                                q.room_number,
                                q.UsersE,
                                q.category_request,
                                q.UsersC
                            };
                DataGrid_Request.ItemsSource = queryRequest.ToList();
            }
            else if (typeRequest == "Архивные")
            {
                db_R._Requests.Load();

                var queryRequest = from q in db_R._Requests
                                   where q.status_request == "В архиве"
                                   select new
                                   {
                                       q.id_request,
                                       q.name_request,
                                       q.date_start,
                                       q.date_end,
                                       q.status_request,
                                       q.room_number,
                                       q.UsersE,
                                       q.category_request,
                                       q.UsersC
                                   };
                DataGrid_Request.ItemsSource = queryRequest.ToList();
            }


            

            #endregion
        }


        #region Обработка кнопок бургер-меню
        /// <summary>
        /// Обработка кнопок бургер-меню
        /// </summary>
        /// 
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

        private void list_AllUsers_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AllUsers_View allUsers = new AllUsers_View(mainID);
            this.Close();
            allUsers.Show();
        }

        private void list_Customers_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Customers_View customer_View = new Customers_View(mainID);
            this.Close();
            customer_View.Show();
        }

        private void list_Executors_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Executors_View executors_View = new Executors_View(mainID);
            this.Close();
            executors_View.Show();
        }

        private void list_RegisterNewUser_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UserAccount_View userAccount_View = new UserAccount_View(mainID, "Создать", 0);
            this.Close();
            userAccount_View.Show();
        }

        private void list_EditUserAccount_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UserAccount_View userAccount_View = new UserAccount_View(mainID, "Редактировать", 0);
            this.Close();
            userAccount_View.Show();
        }

        private void list_CreateRequest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CreateAndEditRequest_View createAndEditRequest = new CreateAndEditRequest_View(mainID, "Создать");
            this.Close();
            createAndEditRequest.Show();
        }

        private void list_WatchRequest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WatchRequests_View watchRequests = new WatchRequests_View(mainID, "Архивные");
            this.Close();
            watchRequests.Show();
        }

        private void list_WatchArchiveRequest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WatchRequests_View watchRequests = new WatchRequests_View(mainID, "Текущие");
            this.Close();
            watchRequests.Show();
        }

        private void list_FileReport_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FileReport_View fileReport_View = new FileReport_View(mainID);
            this.Close();
            fileReport_View.Show();
        }


        #endregion
    }
}
