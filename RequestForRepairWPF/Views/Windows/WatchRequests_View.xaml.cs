using RequestForRepairWPF.Data;
using RequestForRepairWPF.Views.Windows.UserAccount;
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

namespace RequestForRepairWPF.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для WatchRequests.xaml
    /// </summary>
    public partial class WatchRequests_View : Window
    {
        private int mainID = 0;
        private string typeRequest = string.Empty;
        //BindingListCollectionView requestCollection = new BindingListCollectionView();
        List<object> requestList = new List<object>();
        DataBase dataBase = new DataBase();
        my_DbContext db = new my_DbContext();
        //UserContext db_U = new UserContext();
        public WatchRequests_View(int mainID, string typeRequestGet)
        {
            InitializeComponent();

            this.mainID = mainID;
            this.typeRequest = typeRequestGet;

            BurgerMenu();

            #region Загрузка данных
            /// <summary>
            /// Загрузка данных
            /// </summary>
            /// 

            //string query = "SELECT id_request, name_request, date_start, date_end, status_request, room_number, category_request FROM Requests WHERE status_request != 'В архиве' AND id_request IN (SELECT requestID FROM U_R_Customers WHERE userID = '" + mainID + "');";
            if (typeRequest == "Текущие")
            {
                label_Header.Text = "Просмотр текущих заявок";
                this.Title = "Просмотр текущих заявок";


                //LoadDataRequest();
                //string queryRequestData_GET = string.Format("SELECT id_request, name_request, date_start, date_end, status_request, room_number, category_request FROM Request WHERE status_request != 'В архиве';");
                //requestList = dataBase.GetResultListObj(queryRequestData_GET);
                //DataGrid_Request.ItemsSource = (System.Collections.IEnumerable)requestCollection;


                db.Requests.Load();
                                
                var queryActualRequest = from q in db.Requests
                            where q.status_request != "В архиве"
                            select new
                            {
                                q.id_request,
                                q.name_request,
                                q.date_start,
                                q.date_end,
                                q.status_request,
                                q.room_number,
                                q.category_request
                            };
                DataGrid_Request.ItemsSource = queryActualRequest.ToList();
            }
            else if (typeRequest == "Архивные")
            {
                label_Header.Text = "Просмотр архивных заявок";
                this.Title = "Просмотр архивных заявок";

                db.Requests.Load();
                
                var queryArchiveRequest = from q in db.Requests
                                   where q.status_request == "В архиве"
                                   select new
                                   {
                                       q.id_request,
                                       q.name_request,
                                       q.date_start,
                                       q.date_end,
                                       q.status_request,
                                       q.room_number,
                                       q.category_request
                                   };
                DataGrid_Request.ItemsSource = queryArchiveRequest.ToList();
            }
            else if (typeRequest == "Мои Текущие")
            {
                db.Requests.Load();
                                
                var queryActualRequest = from q in db.Requests
                            where q.status_request != "В архиве"
                            select new
                            {
                                q.id_request,
                                q.name_request,
                                q.date_start,
                                q.date_end,
                                q.status_request,
                                q.room_number,
                                q.category_request
                            };

                //var queryMyRequest = from r in db.Requests
                //                     join u in db.U_R_Executor_Customs
                //                     on r.id_request equals u.requestID_URE
                //                     select new
                //                     {
                //                         r.id_request,
                //                         r.name_request,
                //                         r.date_start,
                //                         r.date_end,
                //                         r.status_request,
                //                         r.room_number,
                //                         r.category_request
                //                     };
                //
                //DataGrid_Request.ItemsSource = queryMyRequest.ToList();
            }
            else if (typeRequest == "Мои Архивные")
            {

            }



            #endregion
        }

        #region Загрузка данных заявок
        private void LoadDataRequest()
        {
            string connectionString = @"Server = DESKTOP-BSEODEL\SQLEXPRESS; DataBase = DB_RequestForRepair; Trusted_Connection = True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string queryRequestData_GET = string.Format("SELECT id_request, name_request, date_start, date_end, status_request, room_number, category_request FROM Requests WHERE status_request != 'В архиве';");
            //string queryPat = "SELECT id_user, user_login, last_name, name, middle_name, position, phone FROM Users WHERE type_of_account = 'Заказчик' ORDER BY id_user;";

            SqlCommand command = new SqlCommand(queryRequestData_GET, myConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[7]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
            }
            reader.Close();
            myConnection.Close();
            foreach (string[] cus in data)
                DataGrid_Request.Items.Add(cus);
        }
        #endregion

        #region Инициализация бургер-меню
        ///<summary>
        ///Инициализация бургер-меню и контента
        /// </summary>
        private void BurgerMenu()
        {
            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                list_AllUsers.Visibility = Visibility.Visible;
                list_Customers.Visibility = Visibility.Visible;
                list_Executors.Visibility = Visibility.Visible;
                list_RegisterNewUser.Visibility = Visibility.Visible;
                list_EditUserAccount.Visibility = Visibility.Visible;
                list_CreateRequest.Visibility = Visibility.Collapsed;
                list_WatchRequest.Visibility = Visibility.Visible;
                list_WatchArchiveRequest.Visibility = Visibility.Visible;
                list_FileReport.Visibility = Visibility.Visible;


            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {

                list_AllUsers.Visibility = Visibility.Collapsed;
                list_Customers.Visibility = Visibility.Collapsed;
                list_Executors.Visibility = Visibility.Collapsed;
                list_RegisterNewUser.Visibility = Visibility.Collapsed;
                list_EditUserAccount.Visibility = Visibility.Visible;
                list_DescriptionRoom.Visibility = Visibility.Visible;
                list_CreateRequest.Visibility = Visibility.Visible;
                list_WatchRequest.Visibility = Visibility.Visible;
                list_WatchArchiveRequest.Visibility = Visibility.Visible;
                list_FileReport.Visibility = Visibility.Visible;

            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {

                list_AllUsers.Visibility = Visibility.Collapsed;
                list_Customers.Visibility = Visibility.Collapsed;
                list_Executors.Visibility = Visibility.Collapsed;
                list_RegisterNewUser.Visibility = Visibility.Collapsed;
                list_EditUserAccount.Visibility = Visibility.Visible;
                list_CreateRequest.Visibility = Visibility.Collapsed;
                list_WatchRequest.Visibility = Visibility.Visible;
                list_WatchArchiveRequest.Visibility = Visibility.Visible;
                list_MyRequest.Visibility = Visibility.Visible;
                list_MyArchiveRequest.Visibility = Visibility.Visible;
                list_FileReport.Visibility = Visibility.Visible;

            }

        }
        #endregion 

        #region Обработка кнопок бургер-меню
        /// <summary>
        /// Обработка кнопок бургер-меню
        /// </summary>

        private void btn_OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btn_OpenMenu.Visibility = Visibility.Collapsed;
            btn_CloseMenu.Visibility = Visibility.Visible;
        }

        private void btn_CloseMenu_Click(object sender, RoutedEventArgs e)
        {
            btn_OpenMenu.Visibility = Visibility.Visible;
            btn_CloseMenu.Visibility = Visibility.Collapsed;
        }

        private void list_Executors_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Executors_View executors_View = new Executors_View(mainID);
            this.Close();
            executors_View.Show();
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

        private void list_RegisterNewUser_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UserAccount_View userAccount_View = new UserAccount_View(mainID, "Создать", 0);
            this.Close();
            userAccount_View.Show();
        }

        private void list_EditUserAccount_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                UserAccount_View userAccount_View = new UserAccount_View(mainID, "Редактировать", 0);
                this.Close();
                userAccount_View.Show();
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                UserAccount_View userAccount_View = new UserAccount_View(mainID, "Редактировать", 0);
                this.Close();
                userAccount_View.Show();
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {
                CustomerUserAccount_View customerUser = new CustomerUserAccount_View(mainID, "Редактировать", 0);
                this.Close();
                customerUser.Show();
            }

        }
        private void list_DescriptionRoom_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DescriptionRoom description = new DescriptionRoom(mainID, "Просмотреть");
            this.Close();
            description.Show();
        }

        private void list_CreateRequest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CreateAndEditRequest_View createAndEditRequest = new CreateAndEditRequest_View(mainID, "Создать", 0);
            this.Close();
            createAndEditRequest.Show();
        }

        private void list_WatchRequest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WatchRequests_View watchRequests = new WatchRequests_View(mainID, "Текущие");
            this.Close();
            watchRequests.Show();
        }

        private void list_WatchArchiveRequest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WatchRequests_View watchRequests = new WatchRequests_View(mainID, "Архивные");
            this.Close();
            watchRequests.Show();
        }


        private void list_MyRequest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WatchRequests_View watchRequests = new WatchRequests_View(mainID, "Мои Текущие");
            this.Close();
            watchRequests.Show();
        }

        private void list_MyArchiveRequest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WatchRequests_View watchRequests = new WatchRequests_View(mainID, "Мои Архивные");
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
