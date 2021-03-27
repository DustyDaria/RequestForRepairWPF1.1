
using RequestForRepairWPF.Data;
using RequestForRepairWPF.Views.Windows;
using RequestForRepairWPF.Views.Windows.UserAccount;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class AllUsers_View : Window
    {
        private string action = string.Empty;
        private int mainID = 0;
        public string typeSearchTransfer;
        public string stringReaderBoxTransfer;
        DataBase dataBase = new DataBase();
        my_DbContext db = new my_DbContext();
        ObservableCollection<string[]> usersData = new ObservableCollection<string[]>();

        public AllUsers_View() { }

        public AllUsers_View(int mainID)
        {
            InitializeComponent();

            this.mainID = mainID;
            //this.action = usersAction;
            db.Users.Load(); // загружаем данные
            DataGrid_AllUsers.ItemsSource = db.Users.Local.ToBindingList(); // Устанавливаем привязку к кэшу

            //LoadDataAll();

            BurgerMenu();

        }

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
                list_FileReport.Visibility = Visibility.Visible;

            }

        }
        #endregion


        #region Загрузка данных всех пользователей
        /*private void LoadDataAll()
        {
            string connectionString = @"Server = DESKTOP-BSEODEL\SQLEXPRESS; DataBase = DB_RegistrationOfRequest; Trusted_Connection = True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string queryPat = "SELECT id_user, user_login, last_name, name, middle_name, position, type_of_account, category_executors, phone FROM Users ORDER BY id_user;";

            SqlCommand command = new SqlCommand(queryPat, myConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[9]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
                data[data.Count - 1][8] = reader[8].ToString();
            }
            reader.Close();
            myConnection.Close();
            foreach (string[] all in data)
                usersData.Add(all);

            DataGrid_AllUsers.Items.Add(usersData);
        }*/
        #endregion

        private void btn_PopUpPersonalAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_PopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            // ДИАЛОГОВЫЕ ОКНА
            MessageBox.Show("БЛАБЛАБЛАБЛА, ТУТ ДОЛЖНО БЫТЬ ДИЛОГОВОЕ ОКНО");
            Authorization_View authorization = new Authorization_View();
            this.Close();
            authorization.Show();
        }

        

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //db.Dispose();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {

        }


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

        private void list_FileReport_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FileReport_View fileReport_View = new FileReport_View(mainID);
            this.Close();
            fileReport_View.Show();
        }



        #endregion


        #region Поиск
        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            typeSearchTransfer = comboBox_Search.Text;
            stringReaderBoxTransfer = textBox_DataForSearch.Text;

            ListStatus(typeSearchTransfer, stringReaderBoxTransfer);
        }

        public void ListStatus(string typeSearch, string stringReaderBox)
        {
            //DataGrid_AllUsers.Items.Clear();// Чистка старых  данных.
            DataGrid_AllUsers.ItemsSource = null;
           // db.Dispose();

            if (typeSearch == "ID")
            {
                //db.Users.Load();
                var data = Convert.ToInt32(stringReaderBox);
                var query = from u in db.Users
                            where u.id_user == data
                            select new
                            {
                                u.id_user,
                                u.user_login,
                                u.last_name,
                                u.name,
                                u.middle_name,
                                u.position,
                                u.type_of_account,
                                u.category_executors,
                                u.phone
                            };
                DataGrid_AllUsers.ItemsSource = query.ToList();
            }
            else if(typeSearch == "Логин")
            {
                var query = from u in db.Users
                            where u.user_login == stringReaderBox
                            select new
                            {
                                u.id_user,
                                u.user_login,
                                u.last_name,
                                u.name,
                                u.middle_name,
                                u.position,
                                u.type_of_account,
                                u.category_executors,
                                u.phone
                            };
                DataGrid_AllUsers.ItemsSource = query.ToList();
            }
            else if(typeSearch == "Фамилия")
            {
                var query = from u in db.Users
                            where u.last_name == stringReaderBox
                            select new
                            {
                                u.id_user,
                                u.user_login,
                                u.last_name,
                                u.name,
                                u.middle_name,
                                u.position,
                                u.type_of_account,
                                u.category_executors,
                                u.phone
                            };
                DataGrid_AllUsers.ItemsSource = query.ToList();
            }
            else if (typeSearch == "Имя")
            {
                var query = from u in db.Users
                            where u.name == stringReaderBox
                            select new
                            {
                                u.id_user,
                                u.user_login,
                                u.last_name,
                                u.name,
                                u.middle_name,
                                u.position,
                                u.type_of_account,
                                u.category_executors,
                                u.phone
                            };
                DataGrid_AllUsers.ItemsSource = query.ToList();
            }
            else if(typeSearch == "Отчество")
            {
                var query = from u in db.Users
                            where u.middle_name == stringReaderBox
                            select new
                            {
                                u.id_user,
                                u.user_login,
                                u.last_name,
                                u.name,
                                u.middle_name,
                                u.position,
                                u.type_of_account,
                                u.category_executors,
                                u.phone
                            };
                DataGrid_AllUsers.ItemsSource = query.ToList();
            }
            else if(typeSearch == "Должность")
            {
                var query = from u in db.Users
                            where u.position == stringReaderBox
                            select new
                            {
                                u.id_user,
                                u.user_login,
                                u.last_name,
                                u.name,
                                u.middle_name,
                                u.position,
                                u.type_of_account,
                                u.category_executors,
                                u.phone
                            };
                DataGrid_AllUsers.ItemsSource = query.ToList();
            }
            else if(typeSearch == "Тип аккаунта")
            {
                var query = from u in db.Users
                            where u.type_of_account == stringReaderBox
                            select new
                            {
                                u.id_user,
                                u.user_login,
                                u.last_name,
                                u.name,
                                u.middle_name,
                                u.position,
                                u.type_of_account,
                                u.category_executors,
                                u.phone
                            };
                DataGrid_AllUsers.ItemsSource = query.ToList();
            }
            else if(typeSearch == "Категория исполнителя")
            {
                var query = from u in db.Users
                            where u.category_executors == stringReaderBox
                            select new
                            {
                                u.id_user,
                                u.user_login,
                                u.last_name,
                                u.name,
                                u.middle_name,
                                u.position,
                                u.type_of_account,
                                u.category_executors,
                                u.phone
                            };
                DataGrid_AllUsers.ItemsSource = query.ToList();
            }
            else if(typeSearch == "Телефон")
            {
                var query = from u in db.Users
                            where u.phone == stringReaderBox
                            select new
                            {
                                u.id_user,
                                u.user_login,
                                u.last_name,
                                u.name,
                                u.middle_name,
                                u.position,
                                u.type_of_account,
                                u.category_executors,
                                u.phone
                            };
                DataGrid_AllUsers.ItemsSource = query.ToList();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите категорию поиска!");
            }

           
        }
        #endregion

        #region Обновление данных
        private void btn_UpdateData_Click(object sender, RoutedEventArgs e)
        {

            comboBox_Search.Text = string.Empty;
            textBox_DataForSearch.Text = string.Empty;

            DataGrid_AllUsers.ItemsSource = null;
            DataGrid_AllUsers.ItemsSource = db.Users.Local.ToBindingList(); // Устанавливаем привязку к кэшу
        }
        #endregion
    }
}
