using RequestForRepairWPF.Views.Controls.Room;
using RequestForRepairWPF.Views.Windows.UserAccount;
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

namespace RequestForRepairWPF.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для DescriptionRoom.xaml
    /// </summary>
    public partial class DescriptionRoom : Window
    {
        private int mainID = 0;
        private string usersAction = string.Empty;
        DataBase dataBase = new DataBase();
        Control_radioBtn radioBtn = new Control_radioBtn();
        int roomNumber = 0;
        string typeRoom = string.Empty;
        string descriptionRoom = string.Empty;
        string commentRoom = string.Empty;
        public DescriptionRoom(int mainID, string usersAction)
        {
            InitializeComponent();

            this.mainID = mainID;
            this.usersAction = usersAction;
            //UserControl1 control = new UserControl1();
            //control.checkBox.Name = testcheck;

            //testGrid.Children = 
            BurgerMenu();

            #region Инициализация элементов управления
            ///<summary>
            ///Инициализация элементов управления
            /// </summary>

            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            if (usersAction == "Редактировать")
            {
                GetDataToViewAndChange();

                this.Title = "Редактировать описание помещения";
                label_Header.Text = "Редактировать описание помещения";

                groupBox_type_room.IsEnabled = true;
                textBox_description_room.IsEnabled = true;
                textBox_comment_room.IsEnabled = true;
                groupBox_TE.IsEnabled = true;
                groupBox_SE.IsEnabled = true;
                groupBox_S.IsEnabled = true;

                btn_Edit.IsEnabled = false;
                btn_Edit.Visibility = Visibility.Collapsed;
                btn_Save.IsEnabled = true;
                btn_Cancel.IsEnabled = true;
            }
            else if (usersAction == "Просмотреть")
            {
                GetDataToViewAndChange();

                this.Title = "Просмотреть описание помещения";
                label_Header.Text = "Просмотреть описание помещения";

                groupBox_type_room.IsEnabled = false;
                textBox_description_room.IsEnabled = false;
                textBox_comment_room.IsEnabled = false;
                groupBox_TE.IsEnabled = false;
                groupBox_SE.IsEnabled = false;
                groupBox_S.IsEnabled = false;

                btn_Edit.IsEnabled = true;
                btn_Edit.Visibility = Visibility.Visible;

                btn_Save.IsEnabled = false;
                btn_Cancel.IsEnabled = true;
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

        #region Получение данных из бд
        /// <summary>
        /// Получение данных из бд 
        /// </summary>
        /// 

        private void GetDataToViewAndChange()
        {
            string queryDescription_GET = string.Format("SELECT description_DR FROM DescriptionRoom WHERE userID_DR = " + mainID + ";");
            string queryTypeRoom_GET = string.Format("SELECT name_type_room_TR FROM TypeRoom, U_R_Room WHERE id_type_room_TR = id_type_room_URR AND userID_URR = '" + mainID + "';");
            string queryComment_GET = string.Format("SELECT comment_DR FROM DescriptionRoom WHERE userID_DR = " + mainID + ";");
            string queryRoomNumber_GET = string.Format("SELECT roomNUMBER_URR FROM U_R_Room WHERE userID_URR = '" + mainID + "';");
            
            roomNumber = dataBase.GetID(queryRoomNumber_GET);
            label_RoomNumber.Text = "Номер помещения: " + roomNumber;

            typeRoom = dataBase.GetResult(queryTypeRoom_GET);
            radioBtn.SelectedValue = typeRoom;

            descriptionRoom = dataBase.GetResult(queryDescription_GET);
            textBox_description_room.Text = descriptionRoom;

            commentRoom = dataBase.GetResult(queryComment_GET);
            textBox_comment_room.Text = commentRoom;
        }

        #endregion

        private void btn_PopUpLogout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_PopUpPersonalAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void adm_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void cus_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void exe_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            //string queryDescription_SET = string.Format("INSERT INTO DescriptionRoom (id_type_room_DR, description_DR, comment_DR) VALUES ("
            //    + radioBtn.SelectedValue + ", " + textBox_description_room.Text + ", " + textBox_comment_room.Text + ";");
            //dataBase.Insert(queryDescription_SET);
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        //#region Обработка кнопок бургер-меню
        ///// <summary>
        ///// Обработка кнопок бургер-меню
        ///// </summary>
        //
        //private void btn_OpenMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    btn_OpenMenu.Visibility = Visibility.Collapsed;
        //    btn_CloseMenu.Visibility = Visibility.Visible;
        //}
        //
        //private void btn_CloseMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    btn_OpenMenu.Visibility = Visibility.Visible;
        //    btn_CloseMenu.Visibility = Visibility.Collapsed;
        //}
        //
        //private void list_Executors_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    Executors_View executors_View = new Executors_View(mainID);
        //    this.Close();
        //    executors_View.Show();
        //}
        //
        //private void list_AllUsers_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    AllUsers_View allUsers = new AllUsers_View(mainID);
        //    this.Close();
        //    allUsers.Show();
        //}
        //
        //
        //private void list_Customers_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    Customers_View customer_View = new Customers_View(mainID);
        //    this.Close();
        //    customer_View.Show();
        //}
        //
        //private void list_RegisterNewUser_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //   //UserAccount_View userAccount_View = new UserAccount_View(mainID, "Создать", 0);
        //   //this.Close();
        //   //userAccount_View.Show();
        //}
        //
        //private void list_EditUserAccount_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");
        //
        //    if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
        //    {
        //        //UserAccount_View userAccount_View = new UserAccount_View(mainID, "Редактировать", 0);
        //        //this.Close();
        //        //userAccount_View.Show();
        //    }
        //    else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
        //    {
        //        //UserAccount_View userAccount_View = new UserAccount_View(mainID, "Редактировать", 0);
        //        //this.Close();
        //        //userAccount_View.Show();
        //    }
        //    else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
        //    {
        //        CustomerUserAccount_View customerUser = new CustomerUserAccount_View(mainID, "Редактировать", 0);
        //        this.Close();
        //        customerUser.Show();
        //    }
        //
        //}
        //private void list_DescriptionRoom_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    DescriptionRoom description = new DescriptionRoom(mainID, "Просмотреть");
        //    this.Close();
        //    description.Show();
        //}
        //
        //private void list_CreateRequest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    CreateAndEditRequest_View createAndEditRequest = new CreateAndEditRequest_View(mainID, "Создать", 0);
        //    this.Close();
        //    createAndEditRequest.Show();
        //}
        //
        //private void list_WatchRequest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    WatchRequests_View watchRequests = new WatchRequests_View(mainID, "Текущие");
        //    this.Close();
        //    watchRequests.Show();
        //}
        //
        //private void list_WatchArchiveRequest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    WatchRequests_View watchRequests = new WatchRequests_View(mainID, "Архивные");
        //    this.Close();
        //    watchRequests.Show();
        //}
        //
        //private void list_FileReport_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    FileReport_View fileReport_View = new FileReport_View(mainID);
        //    this.Close();
        //    fileReport_View.Show();
        //}
        //
        //
        //
        //#endregion
    }
}
