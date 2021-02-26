using RequestForRepairWPF.Views.Windows;
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

namespace RequestForRepairWPF
{
    /// <summary>
    /// Логика взаимодействия для Menu_Administrator.xaml
    /// </summary>
    /// 

    /* МЕНЮ АДМИНИСТРАТОРА
         * 
         * Пользователи ("Все пользователи")
         * Заказчики ("Заказчики")
         * Исполнители ("Исполнители")
         * Регистрация нового пользователя ("Зарегистрировать..")
         * Редактирование личного профиля ("Редактировать личный профиль")
         * Просмотр текущих заявок ("Текущие заявки")
         * Просмотр выполненных заявок ("Архивные заявки")
         * Создание отчёта ("Создать отчёт")
         */



    /* МЕНЮ ЗАКАЗЧИКА
        * 
        * Создание новой заявки ("Создать новую заявку")
        * Просмотр текущих заявок ("Мои заявки")
        * Просмотр выполненных заявок ("Мои архивные заявки")
        * Редактирование личного профиля ("Редактировать личный профиль")
        * Создание отчёта ("Создать отчёт")
        */


    /* МЕНЮ ИСПОЛНПИТЕЛЯ
         * 
         * Просмотр текущих заявок ("Мои заявки")
         * Просмотр выполненных заявок ("Мои архивные заявки")
         * Редактирование личного профиля ("Редактировать личный профиль")
         * Создание отчёта ("Создать отчёт")
         */



    public partial class UserAccount_View : Window
    {
        private int mainID = 0;
        DataBase dataBase = new DataBase();
        private int secondaryID = 0;
        private string usersAction = string.Empty;
        bool btn_EditClick_FLAG = false;
        char charToTrim = ' ';

        public UserAccount_View(int mainID)
        {
            InitializeComponent();

            this.mainID = mainID;

            btn_Edit.IsEnabled = true;
            btn_Edit.Visibility = Visibility.Visible;

            btn_Save.IsEnabled = false;
            btn_Cancel.IsEnabled = false;

            #region Инициализация бургер-меню и контента
            ///<summary>
            ///Инициализация бургер-меню и контента
            /// </summary>

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

                //контент
                this.Title = "Личный кабинет системного администратора";
                textBox_last_name.IsEnabled = false;
                textBox_name.IsEnabled = false;
                textBox_middle_name.IsEnabled = false;
                textBox_position.IsEnabled = false;
                textBox_phone.IsEnabled = false;
                textBox_user_login.IsEnabled = false;
                passBox_user_password.IsEnabled = false;
                //label_repeat_user_password.Visible = false;
                passBox_repeat_user_password.IsEnabled = false;
                passBox_repeat_user_password.Visibility = Visibility.Collapsed;
                comboBox_type_of_account.IsEnabled = false;

                // данные
                GetDataToViewAndChange_Main();
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

                //контент
                this.Title = "Личный кабинет заказчика";
                textBox_last_name.IsEnabled = false;
                textBox_name.IsEnabled = false;
                textBox_middle_name.IsEnabled = false;
                textBox_position.IsEnabled = false;
                textBox_phone.IsEnabled = false;
                textBox_user_login.IsEnabled = false;
                passBox_user_password.IsEnabled = false;
                passBox_repeat_user_password.IsEnabled = false;
                passBox_repeat_user_password.Visibility = Visibility.Visible;
                comboBox_type_of_account.IsEnabled = false;
                //label_room_number.Visible = true;
                comboBox_room_number.Visibility = Visibility.Visible;
                comboBox_room_number.IsEnabled = false;
                //label_category_executors.Visibility = Visibility.Collapsed;
                comboBox_category_executors.Visibility = Visibility.Collapsed;
                comboBox_category_executors.IsEnabled = false;

                //данные
                GetDataToViewAndChange_Main();
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

                //контент
                this.Title = "Личный кабинет исполнителя";
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
                //label_room_number.Visible = false;
                comboBox_room_number.Visibility = Visibility.Collapsed;
                comboBox_room_number.IsEnabled = false;
                //label_category_executors.Visible = true;
                comboBox_category_executors.Visibility = Visibility.Visible;
                comboBox_category_executors.IsEnabled = false;

                //данные
                GetDataToViewAndChange_Main();
            }
            #endregion 
        }



        public UserAccount_View(int mainID, string usersAction, int secondaryID)
        {
            InitializeComponent();

            this.mainID = mainID;
            this.usersAction = usersAction;
            this.secondaryID = secondaryID;

            #region Инициализация элементов управления
            ///<summary>
            ///Инициализация элементов управления
            /// </summary>

            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");
            //string queryUserLastName_GET = string.Format("SELECT last_name FROM Users WHERE id_user = '" + mainID + "';");
            //string queryUserName_GET = string.Format("SELECT name FROM Users WHERE id_user = '" + mainID + "';");
            //string queryUserMiddleName_GET = string.Format("SELECT middle_name FROM Users WHERE id_user = '" + mainID + "';");

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                if (usersAction == "Создать")
                {
                    this.Title = "Зарегистрировать нового пользователя";
                    label_Header.Text = "Зарегистрировать нового пользователя";
                    //linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    //+ dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

                    btn_Edit.IsEnabled = false;
                    btn_Edit.Visibility = Visibility.Collapsed;
                    btn_Save.IsEnabled = true;
                }
                else if (usersAction == "Редактировать")
                {
                    string queryCheckCategoryExecutors_GET = string.Format("SELECT category_executors FROM Users WHERE id_user = '" + secondaryID + "';");
                    string queryCheckRoomNumber_GET = string.Format("SELECT roomNUMBER FROM U_RD_Rooms WHERE userID = '" + secondaryID + "';");

                    GetDataToViewAndChange_Secondary();
                    

                    this.Title = "Редактировать данные пользователя";
                    label_Header.Text = "Редактировать данные пользователя";
                    //linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    //+ dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

                    /*maskedTextBox_last_name.Enabled = true;
                    maskedTextBox_name.Enabled = true;
                    maskedTextBox_middle_name.Enabled = true;
                    textBox_position.Enabled = true;
                    maskedTextBox_phone.Enabled = true;
                    textBox_user_login.Enabled = true;
                    maskedTextBox_user_password.Enabled = true;
                    maskedTextBox_repeat_user_password.Enabled = true;
                    comboBox_type_of_account.Enabled = true;*/

                    if (dataBase.Check(queryCheckRoomNumber_GET, Convert.ToString(secondaryID)) == true)
                    {
                        //label_room_number.Visible = true;
                        comboBox_room_number.Visibility = Visibility.Visible;
                        comboBox_room_number.IsEnabled = true;
                    }
                    else
                    {
                        //label_room_number.Visible = false;
                        comboBox_room_number.Visibility = Visibility.Collapsed;
                        comboBox_room_number.IsEnabled = false;
                    }

                    if (dataBase.Check(queryCheckCategoryExecutors_GET, Convert.ToString(secondaryID)) == true)
                    {
                        //label_category_executors.Visible = true;
                        comboBox_category_executors.Visibility = Visibility.Visible;
                        comboBox_category_executors.IsEnabled = true;
                    }
                    else
                    {
                        //label_category_executors.Visible = false;
                        comboBox_category_executors.Visibility = Visibility.Collapsed;
                        comboBox_category_executors.IsEnabled = false;
                    }

                    btn_Edit.IsEnabled = false;
                    btn_Edit.Visibility = Visibility.Collapsed;
                    btn_Save.IsEnabled = true;
                    btn_Cancel.IsEnabled = true;

                }
                else if (usersAction == "Просмотреть")
                {
                    string queryCheckCategoryExecutors_GET = string.Format("SELECT category_executors FROM Users WHERE id_user = '" + secondaryID + "';");
                    string queryCheckRoomNumber_GET = string.Format("SELECT roomNUMBER FROM U_RD_Rooms WHERE userID = '" + secondaryID + "';");

                    GetDataToViewAndChange_Secondary();
                    

                    this.Title = "Просмотреть данные пользователя";
                    label_Header.Text = "Просмотреть данные пользователя";
                    //linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    //+ dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

                    textBox_last_name.IsEnabled = false;
                    textBox_name.IsEnabled = false;
                    textBox_middle_name.IsEnabled = false;
                    textBox_position.IsEnabled = false;
                    textBox_phone.IsEnabled = false;
                    textBox_user_login.IsEnabled = false;
                    passBox_user_password.IsEnabled = false;
                    //label_repeat_user_password.Visible = false;
                    passBox_repeat_user_password.IsEnabled = false;
                    passBox_repeat_user_password.Visibility = Visibility.Collapsed;
                    comboBox_type_of_account.IsEnabled = false;

                    if (dataBase.Check(queryCheckRoomNumber_GET, Convert.ToString(secondaryID)) == true)
                    {
                        //label_room_number.Visible = true;
                        comboBox_room_number.Visibility = Visibility.Visible;
                        comboBox_room_number.IsEnabled = false;
                    }
                    else
                    {
                        //label_room_number.Visible = false;
                        comboBox_room_number.Visibility = Visibility.Collapsed;
                        comboBox_room_number.IsEnabled = false;
                    }

                    if (dataBase.Check(queryCheckCategoryExecutors_GET, Convert.ToString(secondaryID)) == true)
                    {
                        //label_category_executors.Visible = true;
                        comboBox_category_executors.Visibility = Visibility.Visible;
                        comboBox_category_executors.IsEnabled = false;
                    }
                    else
                    {
                        //label_category_executors.Visible = false;
                        comboBox_category_executors.Visibility = Visibility.Collapsed;
                        comboBox_category_executors.IsEnabled = false;
                    }

                    btn_Edit.IsEnabled = true;
                    btn_Edit.Visibility = Visibility.Visible;

                    btn_Save.IsEnabled = false;
                    btn_Cancel.IsEnabled = true;
                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                if (usersAction == "Редактировать")
                {
                    GetDataToViewAndChange_Secondary();
                    

                    this.Title = "Редактировать данные пользователя";
                    label_Header.Text = "Редактировать данные пользователя";
                    //linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    //+ dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

                    textBox_last_name.IsEnabled = true;
                    textBox_name.IsEnabled = true;
                    textBox_middle_name.IsEnabled = true;
                    textBox_position.IsEnabled = true;
                    textBox_phone.IsEnabled = true;
                    textBox_user_login.IsEnabled = true;
                    passBox_user_password.IsEnabled = true;
                    passBox_repeat_user_password.IsEnabled = true;
                    comboBox_type_of_account.IsEnabled = false;
                    //label_room_number.Visibility = Visibility.Visible;
                    comboBox_room_number.Visibility = Visibility.Visible;
                    comboBox_room_number.IsEnabled = true;
                    //label_category_executors.Visibility = Visibility.Collapsed;
                    comboBox_category_executors.Visibility = Visibility.Collapsed;
                    comboBox_category_executors.IsEnabled = false;

                    btn_Edit.IsEnabled = false;
                    btn_Edit.Visibility = Visibility.Collapsed;
                    btn_Save.IsEnabled = true;
                    btn_Cancel.IsEnabled = true;
                }
                else if (usersAction == "Просмотреть")
                {
                    GetDataToViewAndChange_Secondary();
                    

                    this.Title = "Просмотреть данные пользователя";
                    label_Header.Text = "Просмотреть данные пользователя";
                    //linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    //+ dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

                    textBox_last_name.IsEnabled = false;
                    textBox_name.IsEnabled = false;
                    textBox_middle_name.IsEnabled = false;
                    textBox_position.IsEnabled = false;
                    textBox_phone.IsEnabled = false;
                    textBox_user_login.IsEnabled = false;
                    passBox_user_password.IsEnabled = false;
                    passBox_repeat_user_password.IsEnabled = false;
                    passBox_repeat_user_password.Visibility = Visibility.Visible;
                    comboBox_type_of_account.IsEnabled = false;
                    //label_room_number.Visible = true;
                    comboBox_room_number.Visibility = Visibility.Visible;
                    comboBox_room_number.IsEnabled = false;
                    //label_category_executors.Visibility = Visibility.Collapsed;
                    comboBox_category_executors.Visibility = Visibility.Collapsed;
                    comboBox_category_executors.IsEnabled = false;

                    btn_Edit.IsEnabled = true;
                    btn_Edit.Visibility = Visibility.Visible;

                    btn_Save.IsEnabled = false;
                    btn_Cancel.IsEnabled = true;
                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {

                if (usersAction == "Редактировать")
                {
                    GetDataToViewAndChange_Secondary();
                    
                    this.Title = "Редактировать данные пользователя";
                    label_Header.Text = "Редактировать данные пользователя";
                    //linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    //+ dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

                    textBox_last_name.IsEnabled = true;
                    textBox_name.IsEnabled = true;
                    textBox_middle_name.IsEnabled = true;
                    textBox_position.IsEnabled = true;
                    textBox_phone.IsEnabled = true;
                    textBox_user_login.IsEnabled = true;
                    passBox_user_password.IsEnabled = true;
                    passBox_repeat_user_password.IsEnabled = true;
                    comboBox_type_of_account.IsEnabled = false;
                    //label_room_number.Visibility = Visibility.Visible;
                    comboBox_room_number.Visibility = Visibility.Collapsed;
                    comboBox_room_number.IsEnabled = false;
                    //label_category_executors.Visibility = Visibility.Visible;
                    comboBox_category_executors.Visibility = Visibility.Visible;
                    comboBox_category_executors.IsEnabled = false;

                    btn_Edit.IsEnabled = false;
                    btn_Edit.Visibility = Visibility.Collapsed;
                    btn_Save.IsEnabled = true;
                    btn_Cancel.IsEnabled = true;

                }
                else if (usersAction == "Просмотреть")
                {
                    GetDataToViewAndChange_Secondary();
                    

                    this.Title = "Просмотреть данные пользователя";
                    label_Header.Text = "Просмотреть данные пользователя";
                    //linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    //+ dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

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
                    //label_room_number.Visible = false;
                    comboBox_room_number.Visibility = Visibility.Collapsed;
                    comboBox_room_number.IsEnabled = false;
                    //label_category_executors.Visible = true;
                    comboBox_category_executors.Visibility = Visibility.Visible;
                    comboBox_category_executors.IsEnabled = false;

                    btn_Edit.IsEnabled = true;
                    btn_Edit.Visibility = Visibility.Visible;
                    btn_Save.IsEnabled = false;
                    btn_Cancel.IsEnabled = true;
                }
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
            MessageBox.Show("БЛАБЛАБЛАБЛА, ТУТ ДОЛЖНО БЫТЬ ДИЛОГОВОЕ ОКНО");
            Authorization authorization = new Authorization();
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

            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                string queryCheckCategoryExecutors_GET = string.Format("SELECT category_executors FROM Users WHERE id_user = '" + secondaryID + "';");
                string queryCheckRoomNumber_GET = string.Format("SELECT roomNUMBER FROM U_RD_Rooms WHERE userID = '" + secondaryID + "';");

                GetDataToViewAndChange_Main();

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
                //label_type_of_account.Visible = true;
                comboBox_type_of_account.IsEnabled = true;

                if (dataBase.Check(queryCheckCategoryExecutors_GET, Convert.ToString(secondaryID)) == true)
                {
                    //label_category_executors.Visible = true;
                    comboBox_category_executors.Visibility = Visibility.Visible;
                    comboBox_category_executors.IsEnabled = true;
                }
                else
                {
                    //label_category_executors.Visible = false;
                    comboBox_category_executors.Visibility = Visibility.Collapsed;
                    comboBox_category_executors.IsEnabled = false;
                }

                if (dataBase.Check(queryCheckRoomNumber_GET, Convert.ToString(secondaryID)) == true)
                {
                    //label_room_number.Visible = true;
                    comboBox_room_number.Visibility = Visibility.Visible;
                    comboBox_room_number.IsEnabled = true;
                }
                else
                {
                    //label_room_number.Visible = false;
                    comboBox_room_number.Visibility = Visibility.Collapsed;
                    comboBox_room_number.IsEnabled = false;
                }

                btn_Edit.IsEnabled = false;
                btn_Edit.Visibility = Visibility.Collapsed;
                btn_Save.IsEnabled = true;
                btn_Cancel.IsEnabled = true;
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                GetDataToViewAndChange_Main();

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
                //label_type_of_account.Visible = true;
                comboBox_type_of_account.IsEnabled = false;
                //label_room_number.Visible = true;
                comboBox_room_number.Visibility = Visibility.Visible;
                comboBox_room_number.IsEnabled = true;
                //label_type_of_account.Visible = false;
                comboBox_category_executors.Visibility = Visibility.Collapsed;
                comboBox_category_executors.IsEnabled = false;

                btn_Edit.IsEnabled = false;
                btn_Edit.Visibility = Visibility.Collapsed;
                btn_Save.IsEnabled = true;
                btn_Cancel.IsEnabled = true;
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {
                GetDataToViewAndChange_Main();

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
                //label_type_of_account.Visible = true;
                comboBox_type_of_account.IsEnabled = false;
                //label_type_of_account.Visible = false;
                comboBox_category_executors.Visibility = Visibility.Visible;
                comboBox_category_executors.IsEnabled = false;

                btn_Edit.IsEnabled = false;
                btn_Edit.Visibility = Visibility.Collapsed;
                btn_Save.IsEnabled = true;
                btn_Cancel.IsEnabled = true;
            }
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
                    else if (comboBox_type_of_account.Text == string.Empty)//нужна проверка от левых данных
                    {//нужна проверка от левых данных
                        MessageBox.Show("Пожалуйста, выберите тип аккаунта!");
                    }
                    else if ((comboBox_category_executors.Text == string.Empty) && (comboBox_type_of_account.Text == "Исполнитель"))
                    {//нужна проверка от левых данных
                        MessageBox.Show("Пожалуйста, выберите категорию исполнителя!");
                    }
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
                                string queryUsersData_SET = string.Format("INSERT INTO Users (user_login, user_password, type_of_account, last_name, name, middle_name, position, category_executors, phone) VALUES ('"
                                    + textBox_user_login.Text.Trim(charToTrim) + "', '" + passBox_user_password.Password.Trim(charToTrim) + "', '"
                                    + comboBox_type_of_account.Text.Trim(charToTrim) + "', '" + textBox_last_name.Text.Trim(charToTrim) + "', '"
                                    + textBox_name.Text.Trim(charToTrim) + "', '" + textBox_middle_name.Text.Trim(charToTrim) + "', '"
                                    + textBox_position.Text.Trim(charToTrim) + "', '" + comboBox_category_executors.Text.Trim(charToTrim) + "', '"
                                    + textBox_phone.Text.Trim(charToTrim) + "');");

                                dataBase.Insert(queryUsersData_SET);

                                if (comboBox_type_of_account.Text == "Заказчик")
                                {
                                    string queryUserID_GET = string.Format("SELECT id_user FROM Users WHERE user_login = '" + textBox_user_login.Text.Trim(charToTrim)
                                        + "' AND user_password = '" + passBox_user_password.Password.Trim(charToTrim) + "' AND type_of_account = '"
                                        + comboBox_type_of_account.Text.Trim(charToTrim) + "' AND last_name = '" + textBox_last_name.Text.Trim(charToTrim)
                                        + "' AND name = '" + textBox_name.Text.Trim(charToTrim) + "' AND middle_name = '" + textBox_middle_name.Text.Trim(charToTrim)
                                        + "' AND position = '" + textBox_position.Text.Trim(charToTrim) + "' AND category_executors = '" + comboBox_category_executors.Text.Trim(charToTrim)
                                        + "' AND phone = '" + textBox_phone.Text.Trim(charToTrim) + "';");

                                    string queryU_RD_Rooms_SET = string.Format("INSERT INTO U_RD_Rooms (userID, roomNUMBER) VALUES ('" + dataBase.GetID(queryUserID_GET) + "', '"
                                    + comboBox_room_number.Text.Trim(charToTrim) + "');");

                                    dataBase.Insert(queryU_RD_Rooms_SET);
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
                        string queryUpdateUserData_SET = string.Format("UPDATE Users SET user_login = '" + textBox_user_login.Text.Trim(charToTrim)
                        + "', user_password = '" + passBox_user_password.Password.Trim(charToTrim) + "', type_of_account = '"
                        + comboBox_type_of_account.Text.Trim(charToTrim) + "', last_name = '" + textBox_last_name.Text.Trim(charToTrim) + "', name = '"
                        + textBox_name.Text.Trim(charToTrim) + "', middle_name = '" + textBox_middle_name.Text.Trim(charToTrim) + "', position = '"
                        + textBox_position.Text.Trim(charToTrim) + "', category_executors = '" + comboBox_category_executors.Text.Trim(charToTrim) + "', phone = '"
                        + textBox_phone.Text.Trim(charToTrim) + "' WHERE id_user = '" + secondaryID + "';");

                        dataBase.Update(queryUpdateUserData_SET);

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
                        + textBox_position.Text.Trim(charToTrim) + "', category_executors = '" + comboBox_category_executors.Text.Trim(charToTrim) + "', phone = '"
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
                        string queryUpdateUserData_SET = string.Format("UPDATE Users SET user_login = '" + textBox_user_login.Text.Trim(charToTrim)
                        + "', user_password = '" + passBox_user_password.Password.Trim(charToTrim) + "', type_of_account = '"
                        + comboBox_type_of_account.Text.Trim(charToTrim) + "', last_name = '" + textBox_last_name.Text.Trim(charToTrim) + "', name = '"
                        + textBox_name.Text.Trim(charToTrim) + "', middle_name = '" + textBox_middle_name.Text.Trim(charToTrim) + "', position = '"
                        + textBox_position.Text.Trim(charToTrim) + "', category_executors = '" + comboBox_category_executors.Text.Trim(charToTrim) + "', phone = '"
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
        }
        #endregion


        #region Отмена изменения данных
        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (btn_EditClick_FLAG == true)
            {
                // ДИАЛОГОВЫЕ ОКНА
                MessageBox.Show("БЛАБЛАБЛАБЛА, ТУТ ДОЛЖНО БЫТЬ ДИЛОГОВОЕ ОКНО");

                
            }
        }
        #endregion


        #region Получение данных и их изменение 
        /// <summary>
        /// Получение данных и их изменение 
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
            string queryCategoryExecutors_GET = string.Format("SELECT category_executors FROM Users WHERE id_user = '" + mainID + "'; ");
            string queryRoomNumber_GET = string.Format("SELECT roomNUMBER FROM U_RD_ROOMS WHERE userID = '" + mainID + "';");

            //label1.Text = "Проверка на добавление: " + queryLastName_GET;
            textBox_last_name.Text = dataBase.GetResult(queryLastName_GET);
            textBox_name.Text = dataBase.GetResult(queryName_GET);

            textBox_middle_name.Text = dataBase.GetResult(queryMiddleName_GET);
            /*if (dataBase.Check(queryMiddleName_GET, Convert.ToString(mainID)) == true)
            {
                maskedTextBox_middle_name.Text = dataBase.GetResult(queryMiddleName_GET);
            }
            else
            {
                maskedTextBox_middle_name.Text = string.Empty;
            }*/

            textBox_position.Text = dataBase.GetResult(queryPosition_GET);
            textBox_phone.Text = dataBase.GetResult(queryPhone_GET);
            textBox_user_login.Text = dataBase.GetResult(queryUserLogin_GET);
            passBox_user_password.Password = dataBase.GetResult(queryUserPassword_GET);
            comboBox_type_of_account.Text = dataBase.GetResult(queryTypeOfAccount_GET);

            if (dataBase.Check(queryCategoryExecutors_GET, Convert.ToString(mainID)) == true)
            {
                comboBox_category_executors.Text = dataBase.GetResult(queryCategoryExecutors_GET);
            }
            else
            {
                comboBox_category_executors.Text = string.Empty;
            }

            if (dataBase.Check(queryRoomNumber_GET, Convert.ToString(mainID)) == true)
            {
                comboBox_room_number.Text = dataBase.GetResult(queryRoomNumber_GET);
            }
            else
            {
                comboBox_room_number.Text = string.Empty;
            }

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
            string queryCategoryExecutors_GET = string.Format("SELECT category_executors FROM Users WHERE id_user = '" + secondaryID + "'; ");
            string queryRoomNumber_GET = string.Format("SELECT roomNUMBER FROM U_RD_ROOMS WHERE userID = '" + secondaryID + "';");

            //label1.Text = "Проверка на добавление: " + queryLastName_GET;
            textBox_last_name.Text = dataBase.GetResult(queryLastName_GET);
            textBox_name.Text = dataBase.GetResult(queryName_GET);

            if (dataBase.Check(queryMiddleName_GET, Convert.ToString(secondaryID)) == true)
            {
                textBox_middle_name.Text = dataBase.GetResult(queryMiddleName_GET);
            }
            else
            {
                textBox_middle_name.Text = string.Empty;
            }

            textBox_position.Text = dataBase.GetResult(queryPosition_GET);
            textBox_phone.Text = dataBase.GetResult(queryPhone_GET);
            textBox_user_login.Text = dataBase.GetResult(queryUserLogin_GET);
            passBox_user_password.Password = dataBase.GetResult(queryUserPassword_GET);
            comboBox_type_of_account.Text = dataBase.GetResult(queryTypeOfAccount_GET);

            if (dataBase.Check(queryCategoryExecutors_GET, Convert.ToString(secondaryID)) == true)
            {
                comboBox_category_executors.Text = dataBase.GetResult(queryCategoryExecutors_GET);
            }
            else
            {
                comboBox_category_executors.Text = string.Empty;
            }

            if (dataBase.Check(queryRoomNumber_GET, Convert.ToString(secondaryID)) == true)
            {
                comboBox_room_number.Text = dataBase.GetResult(queryRoomNumber_GET);
            }
            else
            {
                comboBox_room_number.Text = string.Empty;
            }
        }
        #endregion
        /*
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
            string queryCategoryExecutors_GET = string.Format("SELECT category_executors FROM Users WHERE id_user = '" + mainID + "'; ");
            string queryRoomNumber_GET = string.Format("SELECT roomNUMBER FROM U_RD_ROOMS WHERE userID = '" + mainID + "';");

            //label1.Text = "Проверка на добавление: " + queryLastName_GET;
            maskedTextBox_last_name.Text = dataBase.GetResult(queryLastName_GET);
            maskedTextBox_name.Text = dataBase.GetResult(queryName_GET);

            maskedTextBox_middle_name.Text = dataBase.GetResult(queryMiddleName_GET);
            /*if (dataBase.Check(queryMiddleName_GET, Convert.ToString(mainID)) == true)
            {
                maskedTextBox_middle_name.Text = dataBase.GetResult(queryMiddleName_GET);
            }
            else
            {
                maskedTextBox_middle_name.Text = string.Empty;
            }*/

        /*textBox_position.Text = dataBase.GetResult(queryPosition_GET);
        maskedTextBox_phone.Text = dataBase.GetResult(queryPhone_GET);
        textBox_user_login.Text = dataBase.GetResult(queryUserLogin_GET);
        maskedTextBox_user_password.Text = dataBase.GetResult(queryUserPassword_GET);
        comboBox_type_of_account.Text = dataBase.GetResult(queryTypeOfAccount_GET);

        if (dataBase.Check(queryCategoryExecutors_GET, Convert.ToString(mainID)) == true)
        {
            comboBox_category_executors.Text = dataBase.GetResult(queryCategoryExecutors_GET);
        }
        else
        {
            comboBox_category_executors.Text = string.Empty;
        }

        if (dataBase.Check(queryRoomNumber_GET, Convert.ToString(mainID)) == true)
        {
            maskedTextBox_room_number.Text = dataBase.GetResult(queryRoomNumber_GET);
        }
        else
        {
            maskedTextBox_room_number.Text = string.Empty;
        }

    }*/
        #endregion


        #region Выбор типа аккаунта
        /// <summary>
        /// Выбор типа аккаунта
        /// </summary>
        private void comboBox_type_of_account_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                if (usersAction == "Создать")
                {
                    if (Convert.ToString(comboBox_type_of_account.Text) == "Исполнитель")
                    {
                        //label_category_executors.Visible = true;
                        comboBox_category_executors.Visibility = Visibility.Visible;
                        comboBox_category_executors.IsEnabled = true;
                    }
                    else if (Convert.ToString(comboBox_type_of_account.Text) == "Заказчик")
                    {
                        //label_room_number.Visible = true;
                        comboBox_room_number.Visibility = Visibility.Visible;
                        comboBox_room_number.IsEnabled = true;
                    }
                    else
                    {
                        //label_category_executors.Visible = false;
                        //label_room_number.Visible = false;
                        comboBox_category_executors.Visibility = Visibility.Collapsed;
                        comboBox_category_executors.IsEnabled = false;
                        comboBox_room_number.Visibility = Visibility.Collapsed;
                        comboBox_room_number.IsEnabled = false;
                    }
                }
                else if (usersAction == "Просмотреть")
                {
                    if (Convert.ToString(comboBox_type_of_account.Text) == "Исполнитель")
                    {
                        //label_category_executors.Visible = true;
                        comboBox_category_executors.Visibility = Visibility.Visible;
                        comboBox_category_executors.IsEnabled = false;
                    }
                    else if (Convert.ToString(comboBox_type_of_account.Text) == "Заказчик")
                    {
                        //label_room_number.Visible = true;
                        comboBox_room_number.Visibility = Visibility.Visible;
                        comboBox_room_number.IsEnabled = false;
                    }
                    else
                    {
                        //label_category_executors.Visible = false;
                        //label_room_number.Visible = false;
                        comboBox_category_executors.Visibility = Visibility.Collapsed;
                        comboBox_category_executors.IsEnabled = false;
                        comboBox_room_number.Visibility = Visibility.Collapsed;
                        comboBox_room_number.IsEnabled = false;
                    }
                }
                else if (usersAction == "Редактировать")
                {
                    if (Convert.ToString(comboBox_type_of_account.Text) == "Исполнитель")
                    {
                        //label_category_executors.Visible = true;
                        comboBox_category_executors.Visibility = Visibility.Visible;
                        comboBox_category_executors.IsEnabled = true;
                    }
                    else if (Convert.ToString(comboBox_type_of_account.Text) == "Заказчик")
                    {
                        //label_room_number.Visible = true;
                        comboBox_room_number.Visibility = Visibility.Visible;
                        comboBox_room_number.IsEnabled = true;
                    }
                    else
                    {
                        //label_category_executors.Visible = false;
                        //label_room_number.Visible = false;
                        comboBox_category_executors.Visibility = Visibility.Collapsed;
                        comboBox_category_executors.IsEnabled = false;
                        comboBox_room_number.Visibility = Visibility.Collapsed;
                        comboBox_room_number.IsEnabled = false;
                    }
                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {
                if (usersAction == "Просмотреть")
                {
                    //label_category_executors.Visible = true;
                    comboBox_category_executors.Visibility = Visibility.Visible;
                    comboBox_category_executors.IsEnabled = false;
                }
                else if (usersAction == "Редактировать")
                {
                    //label_category_executors.Visible = true;
                    comboBox_category_executors.Visibility = Visibility.Visible;
                    comboBox_category_executors.IsEnabled = false;
                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                if (usersAction == "Просмотреть")
                {
                    //label_room_number.Visible = true;
                    comboBox_room_number.Visibility = Visibility.Visible;
                    comboBox_room_number.IsEnabled = false;
                }
                else if (usersAction == "Редактировать")
                {
                    //label_room_number.Visible = true;
                    comboBox_room_number.Visibility = Visibility.Visible;
                    comboBox_room_number.IsEnabled = false;
                }
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
            UserAccount_View userAccount_View = new UserAccount_View(mainID, "Редактировать", 0);
            this.Close();
            userAccount_View.Show();
        }

        private void list_CreateRequest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CreateAndEditRequest_View createAndEditRequest = new CreateAndEditRequest_View(mainID);
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
