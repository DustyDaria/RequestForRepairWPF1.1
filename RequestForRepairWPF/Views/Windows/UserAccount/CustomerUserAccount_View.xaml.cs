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

namespace RequestForRepairWPF.Views.Windows.UserAccount
{
    /// <summary>
    /// Логика взаимодействия для CustomerUserAccount_View.xaml
    /// </summary>
    public partial class CustomerUserAccount_View : Window
    {
        private int mainID = 0;
        DataBase dataBase = new DataBase();
        private int secondaryID = 0;
        private string usersAction = string.Empty;
        bool btn_EditClick_FLAG = false;
        char charToTrim = ' ';
        
        public CustomerUserAccount_View(int mainID, string usersAction, int secondaryID)
        {
            InitializeComponent();

            this.mainID = mainID;
            this.usersAction = usersAction;
            this.secondaryID = secondaryID;

            BurgerMenu();

            #region Инициализация элементов управления
            ///<summary>
            ///Инициализация элементов управления
            /// </summary>

            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            if (usersAction == "Редактировать")
            {
                GetDataToViewAndChange_Main();

                this.Title = "Редактировать данные пользователя";
                label_Header.Text = "Редактировать данные пользователя";

                textBox_last_name.IsEnabled = true;
                textBox_name.IsEnabled = true;
                textBox_middle_name.IsEnabled = true;
                textBox_position.IsEnabled = true;
                textBox_phone.IsEnabled = true;
                textBox_user_login.IsEnabled = true;
                passBox_user_password.IsEnabled = true;
                passBox_repeat_user_password.IsEnabled = true;
                comboBox_type_of_account.IsEnabled = false;
                textBox_room_number.Visibility = Visibility.Visible;
                textBox_room_number.IsEnabled = true;

                btn_Edit.IsEnabled = false;
                btn_Edit.Visibility = Visibility.Collapsed;
                btn_Save.IsEnabled = true;
                btn_Cancel.IsEnabled = true;
            }
            else if (usersAction == "Просмотреть")
            {
                GetDataToViewAndChange_Main();

                this.Title = "Просмотреть данные пользователя";
                label_Header.Text = "Просмотреть данные пользователя";

                textBox_last_name.IsEnabled = false;
                textBox_name.IsEnabled = false;
                textBox_middle_name.IsEnabled = false;
                textBox_position.IsEnabled = false;
                textBox_phone.IsEnabled = false;
                textBox_user_login.IsEnabled = false;
                passBox_user_password.IsEnabled = false;
                passBox_repeat_user_password.IsEnabled = false;
                passBox_repeat_user_password.Visibility = Visibility.Collapsed;
                comboBox_type_of_account.IsEnabled = false;
                textBox_room_number.Visibility = Visibility.Visible;
                textBox_room_number.IsEnabled = false;

                btn_Edit.IsEnabled = true;
                btn_Edit.Visibility = Visibility.Visible;

                btn_Save.IsEnabled = false;
                btn_Cancel.IsEnabled = true;
            }

            #endregion
        }
        //CustomerUserAccount_View() { }

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

        #region Личный кабинет
        /// <summary>
        /// Личный кабинет
        /// </summary>
        private void btn_PopUpPersonalAccount_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Выход из аккаунта
        /// <summary>
        /// Выход из аккаунта
        /// </summary>
        private void btn_PopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            // ДИАЛОГОВЫЕ ОКНА
            //MessageBox.Show("БЛАБЛАБЛАБЛА, ТУТ ДОЛЖНО БЫТЬ ДИЛОГОВОЕ ОКНО");
            Authorization_View authorization = new Authorization_View();
            this.Close();
            authorization.Show();
        }
        #endregion


        #region Редактирование данных
        /// <summary>
        /// Редактирование данных
        /// </summary>
        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            btn_EditClick_FLAG = true;

            label_Header.Text = "Редактировать данные пользователя";

            textBox_last_name.IsEnabled = true;
            textBox_name.IsEnabled = true;
            textBox_middle_name.IsEnabled = true;
            textBox_position.IsEnabled = true;
            textBox_phone.IsEnabled = true;
            textBox_user_login.IsEnabled = true;
            passBox_user_password.IsEnabled = true;
            passBox_repeat_user_password.Visibility = Visibility.Visible;
            passBox_repeat_user_password.IsEnabled = true;
            comboBox_type_of_account.IsEnabled = false;
            textBox_room_number.IsEnabled = true;

            btn_Edit.IsEnabled = false;
            btn_Edit.Visibility = Visibility.Collapsed;
            btn_Save.IsEnabled = true;
            btn_Cancel.IsEnabled = true;
        }
        #endregion


        #region Сохранение измененных данных
        /// <summary>
        /// Сохранение измененных данных
        /// </summary>
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                if (usersAction == "Создать")
                {
                    //INSERT
                    if (textBox_last_name.Text == string.Empty)
                    {
                        MessageBox.Show("Пожалуйста, введите фамилию пользователя!");
                    }
                    else if (textBox_name.Text == string.Empty)
                    {
                        MessageBox.Show("Пожалуйста, введите имя пользователя!");
                    }
                    else if (textBox_position.Text == string.Empty)
                    {
                        MessageBox.Show("Пожалуйста, введите должность пользователя!");
                    }
                    else if (textBox_phone.Text == string.Empty)
                    {
                        MessageBox.Show("Пожалуйста, введите телефон пользователя!");
                    }
                    else if (textBox_user_login.Text == string.Empty)
                    {
                        MessageBox.Show("Пожалуйста, введите Email пользователя!");
                    }
                    else if (passBox_user_password.Password == string.Empty)
                    {
                        MessageBox.Show("Пожалуйста, введите пароль пользователя!");
                    }
                    else if (passBox_user_password.Password != passBox_repeat_user_password.Password)
                    {
                        MessageBox.Show("Введенные пароли не совпадают!");
                    }
                    else if (comboBox_type_of_account.Text == string.Empty)
                    {
                        MessageBox.Show("Пожалуйста, выберите тип аккаунта!");
                    }
                    //else if ((comboBox_category_executors.Text == string.Empty) && (comboBox_type_of_account.Text == "Исполнитель"))
                    //{
                    //    MessageBox.Show("Пожалуйста, выберите категорию исполнителя!");
                    //}
                    else
                    {
                        string queryCheckCountAdm_GET = string.Format("SELECT COUNT(id_user) FROM Users WHERE type_of_account = 'Системный администратор';");

                        try
                        {
                            if ((dataBase.GetID(queryCheckCountAdm_GET) >= 3) && (comboBox_type_of_account.Text == "Системный администратор"))
                            {
                                MessageBox.Show("ОШИБКА!\nВы не можете зарегистрировать в системе более 3 системных администраторов!");
                            }
                            else
                            {
                                //string queryUsersData_SET = string.Format("INSERT INTO Users (user_login, user_password, type_of_account, last_name, name, middle_name, position, category_executors, phone) VALUES ('"
                                //    + textBox_user_login.Text.Trim(charToTrim) + "', '" + passBox_user_password.Password.Trim(charToTrim) + "', '"
                                //    + comboBox_type_of_account.Text.Trim(charToTrim) + "', '" + textBox_last_name.Text.Trim(charToTrim) + "', '"
                                //    + textBox_name.Text.Trim(charToTrim) + "', '" + textBox_middle_name.Text.Trim(charToTrim) + "', '"
                                //    + textBox_position.Text.Trim(charToTrim) + "', '" + comboBox_category_executors.Text.Trim(charToTrim) + "', '"
                                //    + textBox_phone.Text.Trim(charToTrim) + "');");
                                //
                                //dataBase.Insert(queryUsersData_SET);
                                //
                                if (comboBox_type_of_account.Text == "Заказчик")
                                {
                                    //string queryUserID_GET = string.Format("SELECT id_user FROM Users WHERE user_login = '" + textBox_user_login.Text.Trim(charToTrim)
                                    //    + "' AND user_password = '" + passBox_user_password.Password.Trim(charToTrim) + "' AND type_of_account = '"
                                    //    + comboBox_type_of_account.Text.Trim(charToTrim) + "' AND last_name = '" + textBox_last_name.Text.Trim(charToTrim)
                                    //    + "' AND name = '" + textBox_name.Text.Trim(charToTrim) + "' AND middle_name = '" + textBox_middle_name.Text.Trim(charToTrim)
                                    //    + "' AND position = '" + textBox_position.Text.Trim(charToTrim) + "' AND category_executors = '" + comboBox_category_executors.Text.Trim(charToTrim)
                                    //    + "' AND phone = '" + textBox_phone.Text.Trim(charToTrim) + "';");
                                    //
                                    //string queryU_RD_Rooms_SET = string.Format("INSERT INTO U_R_Room (userID_URR, roomNUMBER_URR) VALUES ('" + dataBase.GetID(queryUserID_GET) + "', '"
                                    //+ comboBox_room_number.Text.Trim(charToTrim) + "');");
                                    //
                                    //dataBase.Insert(queryU_RD_Rooms_SET);
                                }
                                MessageBox.Show("Пользователь был успешно зарегистрирован!");

                                UserAccount_View personalAccount = new UserAccount_View(mainID);
                                this.Close();
                                personalAccount.Show();
                            }

                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("ОШИБКА!!!\n" + err.ToString());
                        }


                    }

                }
                else if ((usersAction == "Редактировать") || (btn_EditClick_FLAG == true))
                {
                    //UPDATE
                    try
                    {
                        //string queryUpdateUserData_SET = string.Format("UPDATE Users SET user_login = '" + textBox_user_login.Text.Trim(charToTrim)
                        //+ "', user_password = '" + passBox_user_password.Password.Trim(charToTrim) + "', type_of_account = '"
                        //+ comboBox_type_of_account.Text.Trim(charToTrim) + "', last_name = '" + textBox_last_name.Text.Trim(charToTrim) + "', name = '"
                        //+ textBox_name.Text.Trim(charToTrim) + "', middle_name = '" + textBox_middle_name.Text.Trim(charToTrim) + "', position = '"
                        //+ textBox_position.Text.Trim(charToTrim) + "', category_executors = '" + comboBox_category_executors.Text.Trim(charToTrim) + "', phone = '"
                        //+ textBox_phone.Text.Trim(charToTrim) + "' WHERE id_user = '" + secondaryID + "';");
                        //
                        //dataBase.Update(queryUpdateUserData_SET);

                        MessageBox.Show("Данные пользователя были успешно обновлены!\n");
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("ОШИБКА!!!\n" + err.ToString());
                    }
                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                if ((usersAction == "Редактировать") || (btn_EditClick_FLAG == true))
                {
                    try
                    {
                        string queryUpdateUserData_SET = string.Format("UPDATE Users SET user_login = '" + textBox_user_login.Text.Trim(charToTrim)
                        + "', user_password = '" + passBox_user_password.Password.Trim(charToTrim) + "', type_of_account = '"
                        + comboBox_type_of_account.Text.Trim(charToTrim) + "', last_name = '" + textBox_last_name.Text.Trim(charToTrim) + "', name = '"
                        + textBox_name.Text.Trim(charToTrim) + "', middle_name = '" + textBox_middle_name.Text.Trim(charToTrim) + "', position = '"
                        + textBox_position.Text.Trim(charToTrim) + "', phone = '"
                        + textBox_phone.Text.Trim(charToTrim) + "' WHERE id_user = '" + secondaryID + "';");

                        dataBase.Update(queryUpdateUserData_SET);

                        MessageBox.Show("Ваши данные были успешно обновлены!\n");
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("ОШИБКА!!!\n" + err.ToString());
                    }

                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {
                if ((usersAction == "Редактировать") || (btn_EditClick_FLAG == true))
                {
                    try
                    {
                        //string queryUpdateUserData_SET = string.Format("UPDATE Users SET user_login = '" + textBox_user_login.Text.Trim(charToTrim)
                        //+ "', user_password = '" + passBox_user_password.Password.Trim(charToTrim) + "', type_of_account = '"
                        //+ comboBox_type_of_account.Text.Trim(charToTrim) + "', last_name = '" + textBox_last_name.Text.Trim(charToTrim) + "', name = '"
                        //+ textBox_name.Text.Trim(charToTrim) + "', middle_name = '" + textBox_middle_name.Text.Trim(charToTrim) + "', position = '"
                        //+ textBox_position.Text.Trim(charToTrim) + "', category_executors = '" + comboBox_category_executors.Text.Trim(charToTrim) + "', phone = '"
                        //+ textBox_phone.Text.Trim(charToTrim) + "' WHERE id_user = '" + secondaryID + "';");
                        //
                        //dataBase.Update(queryUpdateUserData_SET);
                        //
                        //MessageBox.Show("Ваши данные были успешно обновлены!\n");
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("ОШИБКА!!!\n" + err.ToString());
                    }
                }
            }
        }
        #endregion


        #region Отмена изменения данных
        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (btn_EditClick_FLAG == true)
            {
                // ДИАЛОГОВЫЕ ОКНА
                //MessageBox.Show("БЛАБЛАБЛАБЛА, ТУТ ДОЛЖНО БЫТЬ ДИЛОГОВОЕ ОКНО");

                btn_EditClick_FLAG = false;

                GetDataToViewAndChange_Main();

                this.Title = "Просмотреть данные пользователя";
                label_Header.Text = "Просмотреть данные пользователя";

                textBox_last_name.IsEnabled = false;
                textBox_name.IsEnabled = false;
                textBox_middle_name.IsEnabled = false;
                textBox_position.IsEnabled = false;
                textBox_phone.IsEnabled = false;
                textBox_user_login.IsEnabled = false;
                passBox_user_password.IsEnabled = false;
                passBox_repeat_user_password.IsEnabled = false;
                passBox_repeat_user_password.Visibility = Visibility.Collapsed;
                comboBox_type_of_account.IsEnabled = false;
                textBox_room_number.Visibility = Visibility.Visible;
                textBox_room_number.IsEnabled = false;

                btn_Edit.IsEnabled = true;
                btn_Edit.Visibility = Visibility.Visible;

                btn_Save.IsEnabled = false;
                btn_Cancel.IsEnabled = true;
            }
            else
            {
                GetDataToViewAndChange_Main();
            }
        }
        #endregion


        #region Получение данных из бд
        /// <summary>
        /// Получение данных из бд 
        /// </summary>
        /// 
        #region Первичные данные 
        private void GetDataToViewAndChange_Main()
        {
            string queryLastName_GET = string.Format("SELECT last_name FROM Users WHERE id_user = '" + mainID + "';");
            string queryName_GET = string.Format("SELECT name FROM Users WHERE id_user = '" + mainID + "';");
            string queryMiddleName_GET = string.Format("SELECT middle_name FROM Users WHERE id_user = '" + mainID + "';");
            string queryPosition_GET = string.Format("SELECT position FROM Users WHERE id_user = '" + mainID + "';");
            string queryPhone_GET = string.Format("SELECT phone FROM Users WHERE id_user = '" + mainID + "';");
            string queryUserLogin_GET = string.Format("SELECT user_login FROM Users WHERE id_user = '" + mainID + "';");
            string queryUserPassword_GET = string.Format("SELECT user_password FROM Users WHERE id_user = '" + mainID + "'; ");
            string queryTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "'; ");
            string queryRoomNumber_GET = string.Format("SELECT roomNUMBER_URR FROM U_R_ROOM WHERE userID_URR = '" + mainID + "';");

            textBox_last_name.Text = dataBase.GetResult(queryLastName_GET);
            textBox_name.Text = dataBase.GetResult(queryName_GET);
            textBox_middle_name.Text = dataBase.GetResult(queryMiddleName_GET);
            textBox_position.Text = dataBase.GetResult(queryPosition_GET);
            textBox_phone.Text = dataBase.GetResult(queryPhone_GET);
            textBox_user_login.Text = dataBase.GetResult(queryUserLogin_GET);
            passBox_user_password.Password = dataBase.GetResult(queryUserPassword_GET);
            comboBox_type_of_account.Text = dataBase.GetResult(queryTypeOfAccount_GET);
            comboBox_type_of_account.IsEnabled = false;
            textBox_room_number.Text = Convert.ToString(dataBase.GetID(queryRoomNumber_GET));

        }
        #endregion

        #region Вторичные данные 
        private void GetDataToViewAndChange_Secondary()
        {
            string queryLastName_GET = string.Format("SELECT last_name FROM Users WHERE id_user = '" + secondaryID + "';");
            string queryName_GET = string.Format("SELECT name FROM Users WHERE id_user = '" + secondaryID + "';");
            string queryMiddleName_GET = string.Format("SELECT middle_name FROM Users WHERE id_user = '" + secondaryID + "';");
            string queryPosition_GET = string.Format("SELECT position FROM Users WHERE id_user = '" + secondaryID + "';");
            string queryPhone_GET = string.Format("SELECT phone FROM Users WHERE id_user = '" + secondaryID + "';");
            string queryUserLogin_GET = string.Format("SELECT user_login FROM Users WHERE id_user = '" + secondaryID + "';");
            string queryUserPassword_GET = string.Format("SELECT user_password FROM Users WHERE id_user = '" + secondaryID + "'; ");
            string queryTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + secondaryID + "'; ");
            string queryRoomNumber_GET = string.Format("SELECT roomNUMBER FROM U_R_ROOM WHERE userID = '" + secondaryID + "';");

            textBox_last_name.Text = dataBase.GetResult(queryLastName_GET);
            textBox_name.Text = dataBase.GetResult(queryName_GET);
            textBox_middle_name.Text = dataBase.GetResult(queryMiddleName_GET);
            textBox_position.Text = dataBase.GetResult(queryPosition_GET);
            textBox_phone.Text = dataBase.GetResult(queryPhone_GET);
            textBox_user_login.Text = dataBase.GetResult(queryUserLogin_GET);
            passBox_user_password.Password = dataBase.GetResult(queryUserPassword_GET);
            comboBox_type_of_account.Text = dataBase.GetResult(queryTypeOfAccount_GET);
            textBox_room_number.Text = dataBase.GetResult(queryRoomNumber_GET);
            
        }
        #endregion
        
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

            if(dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                UserAccount_View userAccount_View = new UserAccount_View(mainID, "Редактировать", 0);
                this.Close();
                userAccount_View.Show();
            }
            else if(dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                UserAccount_View userAccount_View = new UserAccount_View(mainID, "Редактировать", 0);
                this.Close();
                userAccount_View.Show();
            }
            else if(dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {
                CustomerUserAccount_View customerUser = new CustomerUserAccount_View(mainID, "Редактировать", 0);
                this.Close();
                customerUser.Show();
            }
            
        }
        private void list_DescriptionRoom_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DescriptionRoom description = new DescriptionRoom(mainID, "Просмотреть");
            description.Show();
            this.Hide();
            
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

        private void btn_EditRoom_Click(object sender, RoutedEventArgs e)
        {
            DescriptionRoom descriptionRoom = new DescriptionRoom(mainID, "Редактировать");
            this.Close();
            descriptionRoom.Show();
        }

        
    }
}
