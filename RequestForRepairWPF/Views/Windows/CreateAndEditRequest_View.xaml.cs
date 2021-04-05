using RequestForRepairWPF.Data;
using RequestForRepairWPF.ViewModels.Base;
using RequestForRepairWPF.Views.Windows.UserAccount;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
        private int requestID_GET = 0;
        DataBase dataBase = new DataBase();
        string statusRequest = string.Empty;
        char charToTrim = ' ';
        //U_R_RoomContext db;

        public CreateAndEditRequest_View(int mainID, string action, int requestID_GET)
        {
            InitializeComponent();

            this.mainID = mainID;
            this.action = action;
            this.requestID_GET = requestID_GET;

            #region Даты по умолчанию в календарях
            ///<summary>
            /// Даты по умолчанию в календарях
            /// </summary>
            /// 

            dateTime_Start.DisplayDateStart = DateTime.Now;
            dateTime_End.DisplayDateStart = DateTime.Now;
            dateTime_End.SelectedDate = DateTime.Now.AddDays(14);
            #endregion

            BurgerMenu();

            #region Отображение элементов управления

            //string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");
            string queryUserLastName_GET = string.Format("SELECT last_name FROM Users WHERE id_user = '" + mainID + "';");
            string queryUserName_GET = string.Format("SELECT name FROM Users WHERE id_user = '" + mainID + "';");
            string queryUserMiddleName_GET = string.Format("SELECT middle_name FROM Users WHERE id_user = '" + mainID + "';");
            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");


            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                if (action == "Модерация")
                {
                    this.Title = "Редактировать заявку";
                    label_Header.Text = "Редактировать заявку";
                    //linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    //+ dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

                    GetDataToViewAndChange();

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
                else if (action == "В архив")
                {
                    this.Title = "Редактировать заявку";
                    label_Header.Text = "Редактировать заявку";
                    //linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    //+ dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);
                    //
                    GetDataToViewAndChange();

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
                else if(action == "Просмотреть")
                {
                    this.Title = "Просмотреть заявку";
                    label_Header.Text = "Просмотреть заявку";
                    //linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    //+ dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);
                    //
                    GetDataToViewAndChange();

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
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                if (action == "Создать")
                {
                    this.Title = "Создать новую заявку";
                    label_Header.Text = "Создать новую заявку";

                    
                    string queryRoomNumberCount_GET = string.Format("SELECT COUNT(roomNUMBER_URR) FROM U_R_Room WHERE userID_URR = '" + mainID + "';");
                    string queryRoomNumber_GET = string.Format("SELECT DISTINCT roomNUMBER_URR FROM U_R_Room WHERE userID_URR = '" + mainID + "';");

                    int roomCount = dataBase.GetID(queryRoomNumberCount_GET);

                    for (int i = 1; i <= roomCount; i++)
                    {
                        comboBox_room_number.Items.Add(dataBase.GetID(queryRoomNumber_GET));
                    } //ПОЛУЧАЮ ОДИНАКОВЫЕ НОМЕРА КАБИНЕТОВ
                      //


                    //db = new U_R_RoomContext();
                    //db.U_R_Rooms.Load();
                    //var query = from r in db.U_R_Rooms
                    //            where r.userID_URR == mainID
                    //            select r.roomNUMBER_URR;
                    //comboBox_room_number.ItemsSource = query.ToList();
                    //foreach(var i in dataBase.GetID(queryRoomNumber_GET))
                    //{
                    //
                    //}
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
                    GetDataToViewAndChange();

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
                    GetDataToViewAndChange();

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
                    GetDataToViewAndChange();

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
                    GetDataToViewAndChange();

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
            #endregion
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

        #region Сохранение
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                if ((action == "Модерация") || (action == "В архив"))
                {
                    string queryStatusRequest_SET = string.Format("UPDATE Requests SET status_request = '" + statusRequest + "' WHERE id_request = '" + requestID_GET + "';");
                    dataBase.Update(queryStatusRequest_SET);

                    MessageBox.Show("Данные заявки были успешно обновлены!\n");
                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                if (action == "Создать")
                {

                    if (textBox_name_request.Text == string.Empty)
                    {
                        MessageBox.Show("Пожалуйста, введите корректное название заявки!");
                    }
                    else if (textBox_description_request.Text == string.Empty)
                    {
                        MessageBox.Show("Пожалуйста, введите соответствующее описание заявки!");
                    }
                    else if (comboBox_room_number.Text == string.Empty)  // Нужна проверка от левых (введенных вручную) значений
                    {
                        MessageBox.Show("Пожалуйста, выберите Ваше помещение!");
                    }
                    else if ((dateTime_End.SelectedDate == dateTime_Start.SelectedDate) || (dateTime_End.SelectedDate < dateTime_Start.SelectedDate))
                    {
                        MessageBox.Show("Необходимая дата окончания выполнения работ по заявке не может быть меньше или равна дате начала выполнения работ.\nПожалуйста, выберите корректную дату окончания выполнения работ по заявке!");
                    }
                    else if (comboBox_category_request.Text == string.Empty)
                    {
                        MessageBox.Show("Пожалуйста, выберите корректную категорию работ для заявки!");
                    }
                    else
                    {
                        try
                        {
                            string queryDataRequest_SET = string.Format("INSERT INTO Requests (date_start, date_end, status_request, room_number, name_request, description_request, comment_request, inventory_number, category_request) VALUES ('"
                            + dateTime_Start.SelectedDate + "', '" + dateTime_End.SelectedDate + "', 'На модерации', '" + comboBox_room_number.Text.Trim(charToTrim) + "', '"
                            + textBox_name_request.Text.Trim(charToTrim) + "', '" + textBox_description_request.Text.Trim(charToTrim) + "', '"
                            + textBox_comment_request.Text.Trim(charToTrim) + "', '" + textBox_inventory_number.Text.Trim(charToTrim) + "', '"
                            + comboBox_category_request.Text.Trim(charToTrim) + "');");

                            dataBase.Insert(queryDataRequest_SET);

                            string queryIDRequest_GET = string.Format("SELECT id_request FROM Requests WHERE date_start = '"
                                + dateTime_Start.SelectedDate + "' AND date_end = '" + dateTime_End.SelectedDate + "' AND status_request = 'На модерации' AND room_number = '"
                                + comboBox_room_number.Text.Trim(charToTrim) + "' AND name_request = '" + textBox_name_request.Text.Trim(charToTrim)
                                + "' AND description_request = '" + textBox_description_request.Text.Trim(charToTrim) + "' AND comment_request = '"
                                + textBox_comment_request.Text.Trim(charToTrim) + "' AND inventory_number = '" + textBox_inventory_number.Text.Trim(charToTrim)
                                + "' AND category_request = '" + comboBox_category_request.Text.Trim(charToTrim) + "';");
                            string queryU_R_CustomersData_SET = string.Format("INSERT INTO U_R_Customer (userID_URC, requestID_URC) VALUES ('"
                                + mainID + "', '" + dataBase.GetID(queryIDRequest_GET) + "');");

                            dataBase.Insert(queryU_R_CustomersData_SET);

                            MessageBox.Show("Ваша заявка была успешно сохранена и передана на модерацию!");

                            WatchRequests_View watchRequests = new WatchRequests_View(mainID, "Текущие");
                            this.Close();
                            watchRequests.Show();
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("ОШИБКА!!!\n" + err.ToString());
                        }
                    }
                }
                else if (action == "Завершить/вернуть")
                {
                    string queryStatusRequest_SET = string.Format("UPDATE Requests SET status_request = '" + statusRequest + "' WHERE id_request = '" + requestID_GET + "';");
                    dataBase.Update(queryStatusRequest_SET);

                    MessageBox.Show("Данные заявки были успешно обновлены!\n");
                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {
                if (action == "Принять")
                {
                    string queryU_R_Executors_SET = string.Format("INSERT INTO U_R_Executor (userID_URC, requestID_URC) VALUES ('"
                        + mainID + "', '" + requestID_GET + "');");
                    string queryStatusRequest_SET = string.Format("UPDATE Requests SET status_request = '" + statusRequest + "' WHERE id_request = '" + requestID_GET + "';");
                    dataBase.Update(queryStatusRequest_SET);
                    dataBase.Insert(queryU_R_Executors_SET);

                    MessageBox.Show("Данные заявки были успешно обновлены!\nДанная заявка закреплена за Вами, можете приступать к выполнению работ по текущей заявке :D");
                }
                else if (action == "Сдать")
                {
                    string queryStatusRequest_SET = string.Format("UPDATE Requests SET status_request = '" + statusRequest + "' WHERE id_request = '" + requestID_GET + "';");
                    dataBase.Update(queryStatusRequest_SET);

                    MessageBox.Show("Данные заявки были успешно обновлены!\nЕсли вы успешно выполнили необходимые по заявке работы, она к Вам больше не вернется :D");
                }
            }
        }
        #endregion

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            //UserAccount_View userAccount = new UserAccount_View(mainID);
            //this.Close();
            //userAccount.Show();
        }

        //private void btn_Edit_Click(object sender, RoutedEventArgs e)
        //{
        //
        //}

        #region Загрузка данных 
        private void GetDataToViewAndChange()
        {
            string queryNameRequest_GET = string.Format("SELECT name_request FROM Request_Description WHERE id_request = '" + requestID_GET + "';");
            string queryDescriptionRequest_GET = string.Format("SELECT description_request FROM Request_Description WHERE id_request = '" + requestID_GET + "';");
            string queryCommentRequest_GET = string.Format("SELECT comment_request FROM Request_Description WHERE id_request = '" + requestID_GET + "';");
            string queryRoomNumberRequest_GET = string.Format("SELECT room_number FROM Request_Description WHERE id_request = '" + requestID_GET + "';");
            string queryInventoryNumberRequest_GET = string.Format("SELECT inventory_number FROM Request_Description WHERE id_request = '" + requestID_GET + "';");
            string queryDateStartRequest_GET = string.Format("SELECT date_start FROM Requests WHERE id_request = '" + requestID_GET + "';");
            string queryDateEndRequest_GET = string.Format("SELECT date_end FROM Requests WHERE id_request = '" + requestID_GET + "';");
            string queryCategoryRequest_GET = string.Format("SELECT category_request Request_Description WHERE id_request = '" + requestID_GET + "';");
            string queryStatusRequest_GET = string.Format("SELECT status_request FROM Requests WHERE id_request = '" + requestID_GET + "';");

            textBox_name_request.Text = dataBase.GetResult(queryNameRequest_GET);
            textBox_description_request.Text = dataBase.GetResult(queryDescriptionRequest_GET);

            if (dataBase.Check(queryCommentRequest_GET, Convert.ToString(requestID_GET)) == true)
            {
                textBox_comment_request.Text = dataBase.GetResult(queryCommentRequest_GET);
            }
            else
            {
                textBox_comment_request.Text = string.Empty;
            }

            comboBox_room_number.Text = dataBase.GetResult(queryRoomNumberRequest_GET);

            if (dataBase.Check(queryInventoryNumberRequest_GET, Convert.ToString(requestID_GET)) == true)
            {
                textBox_inventory_number.Text = dataBase.GetResult(queryInventoryNumberRequest_GET);
            }
            else
            {
                textBox_inventory_number.Text = string.Empty;
            }
            
            dateTime_Start.SelectedDate = Convert.ToDateTime(dataBase.GetResult(queryDateStartRequest_GET));
            dateTime_End.SelectedDate = Convert.ToDateTime(dataBase.GetResult(queryDateEndRequest_GET));
            comboBox_category_request.Text = dataBase.GetResult(queryCategoryRequest_GET);

            if (dataBase.GetResult(queryStatusRequest_GET) == "На модерации")
            {
                radioButton_OnModeration.IsChecked = true;
            }
            else if (dataBase.GetResult(queryStatusRequest_GET) == "Модерация не пройдена")
            {
                radioButton_ModerationIsNotPassed.IsChecked = true;
            }
            else if (dataBase.GetResult(queryStatusRequest_GET) == "Ждет выполнения")
            {
                radioButton_Waiting.IsChecked = true;
            }
            else if (dataBase.GetResult(queryStatusRequest_GET) == "Работа выполнена")
            {
                radioButton_WorkIsCompleted.IsChecked = true;
            }
            else if (dataBase.GetResult(queryStatusRequest_GET) == "Принято в работу")
            {
                radioButton_AcceptedForWork.IsChecked = true;
            }
            else if (dataBase.GetResult(queryStatusRequest_GET) == "Возврат в работу")
            {
                radioButton_ReturnToWork.IsChecked = true;
            }
            else if (dataBase.GetResult(queryStatusRequest_GET) == "Завершено")
            {
                radioButton_Finished.IsChecked = true;
            }
            else if (dataBase.GetResult(queryStatusRequest_GET) == "В архиве")
            {
                radioButton_InTheArchive.IsChecked = true;
            }
        }
        #endregion

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
