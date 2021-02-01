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


    public partial class Menu_Administrator : Window
    {
        int mainID = 0;

        public Menu_Administrator(int userID)
        {
            InitializeComponent();

            mainID = userID;
        }

        private void btn_Hamburger_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_PopUpLogout_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void btn_PopUpPersonalAccount_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

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
    }
}
