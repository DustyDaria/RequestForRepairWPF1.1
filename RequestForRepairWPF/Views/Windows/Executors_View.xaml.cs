﻿using RequestForRepairWPF.Data;
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
    /// Логика взаимодействия для Executors_View.xaml
    /// </summary>
    public partial class Executors_View : Window
    {
        private int mainID = 0;
        DataBase dataBase = new DataBase();
        my_DbContext db = new my_DbContext();
        List<User> idList = new List<User>();
        List<int> requestList = new List<int>();
        public string typeSearchTransfer;
        public string stringReaderBoxTransfer;
        ObservableCollection<User> executorsCollection = new ObservableCollection<User>(); 
        public Executors_View(int mainID)
        {
            InitializeComponent();

            this.mainID = mainID;

            db.Users.Load(); // загружаем данные
            var query = from c in db.Users
                        where c.type_of_account == "Исполнитель"
                        select new 
                        {
                            c.id_user,
                            c.user_login,
                            c.last_name,
                            c.name,
                            c.middle_name,
                            c.position,
                            c.category_executors,
                            c.phone
                        };
            
            DataGrid_Executors.ItemsSource = query.ToList();

            // НУЖНЫ ДАННЫЕ В КОМБО-БОКСАХ
            /*foreach (var _user in query)
            {
                idList.Add(new User
                {
                    id_user = _user.id_user
                });
            }
            for (int i=0; i<=idList.Count; i++)
            {
                var item = idList[i];
                string queryRequest = string.Format("SELECT requestID_URE FROM U_R_Executor WHERE userID_URE = " + item +";");
                
                requestList.Add(Convert.ToInt32(dataBase.GetResult(queryRequest)));
                //for(DataGrid_Executors)
                var cellContext = DataGrid_Executors.Columns[1].GetCellContent(DataGrid_Executors.Items(i));
                if ( == item)
                {

                }
            }*/

            //var id = (DataGrid_Executors.SelectedItem as User).id_user;
            //LoadDataExecutor();

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

        #region Загрузка данных исполнителей
        //private void LoadDataExecutor()
        //{
        //    string connectionString = @"Server = DESKTOP-BSEODEL\SQLEXPRESS; DataBase = DB_RegistrationOfRequest; Trusted_Connection = True;";
        //    SqlConnection myConnection = new SqlConnection(connectionString);
        //    myConnection.Open();
        //
        //    string queryPat = "SELECT id_user, user_login, last_name, name, middle_name, position, category_executors, phone FROM Users WHERE type_of_account = 'Исполнитель' ORDER BY id_user;";
        //
        //    SqlCommand command = new SqlCommand(queryPat, myConnection);
        //    SqlDataReader reader = command.ExecuteReader();
        //    List<string[]> data = new List<string[]>();
        //
        //    while (reader.Read())
        //    {
        //        data.Add(new string[8]);
        //
        //        data[data.Count - 1][0] = reader[0].ToString();
        //        data[data.Count - 1][1] = reader[1].ToString();
        //        data[data.Count - 1][2] = reader[2].ToString();
        //        data[data.Count - 1][3] = reader[3].ToString();
        //        data[data.Count - 1][4] = reader[4].ToString();
        //        data[data.Count - 1][5] = reader[5].ToString();
        //        data[data.Count - 1][6] = reader[6].ToString();
        //        data[data.Count - 1][7] = reader[7].ToString();
        //        //data[data.Count - 1][8] = reader[8].ToString();
        //    }
        //    reader.Close();
        //    myConnection.Close();
        //    foreach (string[] exe in data)
        //        DataGrid_Executors.Items.Add(exe);
        //}
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
            //UserAccount_View userAccount_View = new UserAccount_View(mainID, "Создать", 0);
            //this.Close();
            //userAccount_View.Show();
        }

        private void list_EditUserAccount_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                //UserAccount_View userAccount_View = new UserAccount_View(mainID, "Редактировать", 0);
                //this.Close();
                //userAccount_View.Show();
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                //UserAccount_View userAccount_View = new UserAccount_View(mainID, "Редактировать", 0);
                //this.Close();
                //userAccount_View.Show();
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
            DataGrid_Executors.ItemsSource = null;
            
            if (typeSearch == "ID")
            {
                var data = Convert.ToInt32(stringReaderBox);
                
                var query = from u in db.Users
                            where u.type_of_account == "Исполнитель" && u.id_user == data
                            select new
                            {
                                u.id_user,
                                u.user_login,
                                u.last_name,
                                u.name,
                                u.middle_name,
                                u.position,
                                u.category_executors,
                                u.phone
                            };
                DataGrid_Executors.ItemsSource = query.ToList();
            }
            else if (typeSearch == "Логин")
            {
                var query = from u in db.Users
                            where u.type_of_account == "Исполнитель" && u.user_login == stringReaderBox
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
               DataGrid_Executors.ItemsSource = query.ToList();
            }
            else if (typeSearch == "Фамилия")
            {
                var query = from u in db.Users
                            where u.type_of_account == "Исполнитель" && u.last_name == stringReaderBox
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
                DataGrid_Executors.ItemsSource = query.ToList();
            }
            else if (typeSearch == "Имя")
            {
                var query = from u in db.Users
                            where u.type_of_account == "Исполнитель" && u.name == stringReaderBox
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
                DataGrid_Executors.ItemsSource = query.ToList();
            }
            else if (typeSearch == "Отчество")
            {
                var query = from u in db.Users
                            where u.type_of_account == "Исполнитель" && u.middle_name == stringReaderBox
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
                DataGrid_Executors.ItemsSource = query.ToList();
            }
            else if (typeSearch == "Должность")
            {
                var query = from u in db.Users
                            where u.type_of_account == "Исполнитель" && u.position == stringReaderBox
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
                DataGrid_Executors.ItemsSource = query.ToList();
            }
            else if (typeSearch == "Категория исполнителя")
            {
                var query = from u in db.Users
                            where u.type_of_account == "Исполнитель" && u.category_executors == stringReaderBox
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
                DataGrid_Executors.ItemsSource = query.ToList();
            }
            else if (typeSearch == "Телефон")
            {
                var query = from u in db.Users
                            where u.type_of_account == "Исполнитель" && u.phone == stringReaderBox
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
                DataGrid_Executors.ItemsSource = query.ToList();
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

            DataGrid_Executors.ItemsSource = null;
            var query = from c in db.Users
                        where c.type_of_account == "Исполнитель"
                        select new
                        {
                            c.id_user,
                            c.user_login,
                            c.last_name,
                            c.name,
                            c.middle_name,
                            c.position,
                            c.category_executors,
                            c.phone
                        };

            DataGrid_Executors.ItemsSource = query.ToList();
        }
        #endregion
    }
}
