using RequestForRepairWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для Request_View.xaml
    /// </summary>
    public partial class CreateAndEditRequest_View : Window
    {
        private int mainID = 0;
        private string action = string.Empty;
        DataBase dataBase = new DataBase();

        string statusRequest = string.Empty;



        public CreateAndEditRequest_View(int mainID, string action)
        {
            InitializeComponent();

            this.mainID = mainID;
            this.action = action;

            #region Даты по умолчанию в календарях
            ///<summary>
            /// Даты по умолчанию в календарях
            /// </summary>
            /// 

            dateTime_Start.DisplayDateStart = DateTime.Now;
            dateTime_End.DisplayDateStart = DateTime.Now;
            dateTime_End.SelectedDate = DateTime.Now.AddDays(14);
            #endregion

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
                //btn_Edit.IsEnabled = false;

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
                //btn_Edit.IsEnabled = false;


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
                //btn_Edit.IsEnabled = false;

            }
            #endregion

            //string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");
            string queryUserLastName_GET = string.Format("SELECT last_name FROM Users WHERE id_user = '" + mainID + "';");
            string queryUserName_GET = string.Format("SELECT name FROM Users WHERE id_user = '" + mainID + "';");
            string queryUserMiddleName_GET = string.Format("SELECT middle_name FROM Users WHERE id_user = '" + mainID + "';");


            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                if (action == "Модерация")
                {
                    this.Title = "Редактировать заявку";
                    label_Header.Text = "Редактировать заявку";
                    //linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    //+ dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

                    //GetDataToViewAndChange();

                    textBox_name_request.IsEnabled = false;
                    textBox_description_request.IsEnabled = false;
                    textBox_comment_request.IsEnabled = false;
                    comboBox_room_number.IsEnabled = false;
                    textBox_inventory_number.IsEnabled = false;
                    dateTime_Start.IsEnabled = false;
                    dateTime_End.IsEnabled = false;
                    comboBox_category_request.IsEnabled = false;
                    btn_Save.IsEnabled = true;
                    btn_Cancel.IsEnabled = true;
                    radioButton_OnModeration.IsEnabled = false;
                    radioButton_ModerationIsNotPassed.IsEnabled = true;
                    radioButton_Waiting.IsEnabled = true;
                    radioButton_WorkIsCompleted.IsEnabled = false;
                    radioButton_AcceptedForWork.IsEnabled = false;
                    radioButton_ReturnToWork.IsEnabled = false;
                    radioButton_Finished.IsEnabled = false;
                    radioButton_InTheArchive.IsEnabled = false;
                }
                if (action == "В архив")
                {
                    this.Title = "Редактировать заявку";
                    label_Header.Text = "Редактировать заявку";
                    //linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    //+ dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);
                    //
                    //GetDataToViewAndChange();

                    textBox_name_request.IsEnabled = false;
                    textBox_description_request.IsEnabled = false;
                    textBox_comment_request.IsEnabled = false;
                    comboBox_room_number.IsEnabled = false;
                    textBox_inventory_number.IsEnabled = false;
                    dateTime_Start.IsEnabled = false;
                    dateTime_End.IsEnabled = false;
                    comboBox_category_request.IsEnabled = false;
                    btn_Save.IsEnabled = true;
                    btn_Cancel.IsEnabled = true;
                    radioButton_OnModeration.IsEnabled = false;
                    radioButton_ModerationIsNotPassed.IsEnabled = false;
                    radioButton_Waiting.IsEnabled = false;
                    radioButton_WorkIsCompleted.IsEnabled = false;
                    radioButton_AcceptedForWork.IsEnabled = false;
                    radioButton_ReturnToWork.IsEnabled = false;
                    radioButton_Finished.IsEnabled = false;
                    radioButton_InTheArchive.IsEnabled = true;
                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                if (action == "Создать")
                {
                    this.Title = "Создать новую заявку";
                    label_Header.Text = "Создать новую заявку";
                    //linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    //+ dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

                    textBox_name_request.IsEnabled = true;
                    textBox_description_request.IsEnabled = true;
                    textBox_comment_request.IsEnabled = true;
                    comboBox_room_number.IsEnabled = true;
                    textBox_inventory_number.IsEnabled = true;
                    dateTime_Start.IsEnabled = true;
                    dateTime_End.IsEnabled = true;
                    comboBox_category_request.IsEnabled = true;
                    btn_Save.IsEnabled = true;
                    btn_Cancel.IsEnabled = true;
                    radioButton_OnModeration.IsEnabled = false;
                    radioButton_ModerationIsNotPassed.IsEnabled = false;
                    radioButton_Waiting.IsEnabled = false;
                    radioButton_WorkIsCompleted.IsEnabled = false;
                    radioButton_AcceptedForWork.IsEnabled = false;
                    radioButton_ReturnToWork.IsEnabled = false;
                    radioButton_Finished.IsEnabled = false;
                    radioButton_InTheArchive.IsEnabled = false;

                }
                else if (action == "Просмотреть")
                {
                    this.Title = "Просмотреть заявку";
                    label_Header.Text = "Просмотреть заявку";
                    //linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    //+ dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);
                    //
                    //GetDataToViewAndChange();

                    textBox_name_request.IsEnabled = false;
                    textBox_description_request.IsEnabled = false;
                    textBox_comment_request.IsEnabled = false;
                    comboBox_room_number.IsEnabled = false;
                    textBox_inventory_number.IsEnabled = false;
                    dateTime_Start.IsEnabled = false;
                    dateTime_End.IsEnabled = false;
                    comboBox_category_request.IsEnabled = false;
                    btn_Save.IsEnabled = false;
                    btn_Cancel.IsEnabled = true;
                    radioButton_OnModeration.IsEnabled = false;
                    radioButton_ModerationIsNotPassed.IsEnabled = false;
                    radioButton_Waiting.IsEnabled = false;
                    radioButton_WorkIsCompleted.IsEnabled = false;
                    radioButton_AcceptedForWork.IsEnabled = false;
                    radioButton_ReturnToWork.IsEnabled = false;
                    radioButton_Finished.IsEnabled = false;
                    radioButton_InTheArchive.IsEnabled = false;
                }
                else if (action == "Завершить/вернуть")
                {
                    this.Title = "Редактировать заявку";
                    label_Header.Text = "Редактировать заявку";
                    //linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    //+ dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);
                    //
                    //GetDataToViewAndChange();

                    textBox_name_request.IsEnabled = false;
                    textBox_description_request.IsEnabled = false;
                    textBox_comment_request.IsEnabled = false;
                    comboBox_room_number.IsEnabled = false;
                    textBox_inventory_number.IsEnabled = false;
                    dateTime_Start.IsEnabled = false;
                    dateTime_End.IsEnabled = false;
                    comboBox_category_request.IsEnabled = false;
                    btn_Save.IsEnabled = true;
                    btn_Cancel.IsEnabled = true;
                    radioButton_OnModeration.IsEnabled = false;
                    radioButton_ModerationIsNotPassed.IsEnabled = false;
                    radioButton_Waiting.IsEnabled = false;
                    radioButton_WorkIsCompleted.IsEnabled = false;
                    radioButton_AcceptedForWork.IsEnabled = false;
                    radioButton_ReturnToWork.IsEnabled = true;
                    radioButton_Finished.IsEnabled = true;
                    radioButton_InTheArchive.IsEnabled = false;
                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {
                if (action == "Принять")
                {
                    this.Title = "Принять заявку";
                    label_Header.Text = "Принять заявку";
                    //linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    //+ dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);
                    //
                    //GetDataToViewAndChange();

                    textBox_name_request.IsEnabled = false;
                    textBox_description_request.IsEnabled = false;
                    textBox_comment_request.IsEnabled = false;
                    comboBox_room_number.IsEnabled = false;
                    textBox_inventory_number.IsEnabled = false;
                    dateTime_Start.IsEnabled = false;
                    dateTime_End.IsEnabled = false;
                    comboBox_category_request.IsEnabled = false;
                    btn_Save.IsEnabled = true;
                    btn_Cancel.IsEnabled = true;
                    radioButton_OnModeration.IsEnabled = false;
                    radioButton_ModerationIsNotPassed.IsEnabled = false;
                    radioButton_Waiting.IsEnabled = false;
                    radioButton_WorkIsCompleted.IsEnabled = false;
                    radioButton_AcceptedForWork.IsEnabled = true;
                    radioButton_ReturnToWork.IsEnabled = false;
                    radioButton_Finished.IsEnabled = true;
                    radioButton_InTheArchive.IsEnabled = false;
                }
                else if (action == "Сдать")
                {
                    this.Title = "Сдать заявку";
                    label_Header.Text = "Сдать заявку";
                    //linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    //+ dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);
                    //
                    //GetDataToViewAndChange();

                    textBox_name_request.IsEnabled = false;
                    textBox_description_request.IsEnabled = false;
                    textBox_comment_request.IsEnabled = false;
                    comboBox_room_number.IsEnabled = false;
                    textBox_inventory_number.IsEnabled = false;
                    dateTime_Start.IsEnabled = false;
                    dateTime_End.IsEnabled = false;
                    comboBox_category_request.IsEnabled = false;
                    btn_Save.IsEnabled = true;
                    btn_Cancel.IsEnabled = true;
                    radioButton_OnModeration.IsEnabled = false;
                    radioButton_ModerationIsNotPassed.IsEnabled = false;
                    radioButton_Waiting.IsEnabled = false;
                    radioButton_WorkIsCompleted.IsEnabled = true;
                    radioButton_AcceptedForWork.IsEnabled = false;
                    radioButton_ReturnToWork.IsEnabled = false;
                    radioButton_Finished.IsEnabled = true;
                    radioButton_InTheArchive.IsEnabled = false;
                }
            }
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

        private void comboBox_room_number_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBox_category_request_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        #region События на изменение статуса заявки
        private void radioButton_OnModeration_Checked(object sender, RoutedEventArgs e)
        {
            statusRequest = (string)radioButton_OnModeration.Content;
        }

        private void radioButton_ModerationIsNotPassed_Checked(object sender, RoutedEventArgs e)
        {
            statusRequest = (string)radioButton_ModerationIsNotPassed.Content;
        }

        private void radioButton_Waiting_Checked(object sender, RoutedEventArgs e)
        {
            statusRequest = (string)radioButton_Waiting.Content;
        }

        private void radioButton_WorkIsCompleted_Checked(object sender, RoutedEventArgs e)
        {
            statusRequest = (string)radioButton_WorkIsCompleted.Content;
        }

        private void radioButton_AcceptedForWork_Checked(object sender, RoutedEventArgs e)
        {
            statusRequest = (string)radioButton_AcceptedForWork.Content;
        }

        private void radioButton_ReturnToWork_Checked(object sender, RoutedEventArgs e)
        {
            statusRequest = (string)radioButton_ReturnToWork.Content;
        }

        private void radioButton_Finished_Checked(object sender, RoutedEventArgs e)
        {
            statusRequest = (string)radioButton_Finished.Content;
        }

        private void radioButton_InTheArchive_Checked(object sender, RoutedEventArgs e)
        {
            statusRequest = (string)radioButton_InTheArchive.Content;
        }
        #endregion
    }
}
