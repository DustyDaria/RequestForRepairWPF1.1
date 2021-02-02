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
    /// Логика взаимодействия для Menu_Customer.xaml
    /// </summary>
    /// 


    /* МЕНЮ ЗАКАЗЧИКА
        * 
        * Создание новой заявки ("Создать новую заявку")
        * Просмотр текущих заявок ("Мои заявки")
        * Просмотр выполненных заявок ("Мои архивные заявки")
        * Редактирование личного профиля ("Редактировать личный профиль")
        * Создание отчёта ("Создать отчёт")
        */

    public partial class Menu_Customer : Window
    {
        int mainID = 0;

        public Menu_Customer(int userID)
        {
            InitializeComponent();

            mainID = userID;
        }

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
