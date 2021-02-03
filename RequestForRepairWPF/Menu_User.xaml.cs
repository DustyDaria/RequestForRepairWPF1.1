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



    public partial class Menu_User : Window
    {
        int mainID = 0;
        DataBase dataBase = new DataBase();


        public Menu_User(int userID)
        {
            InitializeComponent();

            mainID = userID;

            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                this.Title = "Меню системного администратора";

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
                this.Title = "Меню заказчика";

                list_AllUsers.Visibility = Visibility.Collapsed;
                list_Customers.Visibility = Visibility.Collapsed;
                list_Executors.Visibility = Visibility.Collapsed;
                list_RegisterNewUser.Visibility = Visibility.Collapsed;
                list_EditUserAccount.Visibility = Visibility.Visible;
                list_CreateRequest.Visibility = Visibility.Visible;
                list_WatchRequest.Visibility = Visibility.Visible;
                list_WatchArchiveRequest.Visibility = Visibility.Visible;
                list_FileReport.Visibility = Visibility.Visible;
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {
                this.Title = "Меню исполнителя";

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

        private void btn_PopUpPersonalAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_PopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            this.Close();
            authorization.Show();
        }
    }
}
