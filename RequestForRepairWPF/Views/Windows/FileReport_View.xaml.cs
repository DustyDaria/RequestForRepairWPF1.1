
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
    /// Логика взаимодействия для FileReport_View.xaml
    /// </summary>
    public partial class FileReport_View : Window
    {
        private int mainID = 0;
        DataBase dataBase = new DataBase();
        public FileReport_View(int mainID)
        {
            InitializeComponent();

            this.mainID = mainID;

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


        #region Выход из аккаунта
        /// <summary>
        /// Выход из аккаунта
        /// </summary>
        private void btn_PopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            // ДИАЛОГОВЫЕ ОКНА
            //MessageBox.Show("БЛАБЛАБЛАБЛА, ТУТ ДОЛЖНО БЫТЬ ДИЛОГОВОЕ ОКНО");
            //Authorization_View authorization = new Authorization_View();
            //this.Close();
            //authorization.Show();
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
                //CustomerUserAccount_View customerUser = new CustomerUserAccount_View(mainID, "Редактировать", 0);
                //this.Close();
                //customerUser.Show();
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
    }
}
