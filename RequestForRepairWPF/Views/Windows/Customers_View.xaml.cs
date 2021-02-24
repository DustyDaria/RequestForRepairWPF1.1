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
    /// Логика взаимодействия для Customer_View.xaml
    /// </summary>
    public partial class Customers_View : Window
    {

        private int mainID = 0;
        public Customers_View(int mainID)
        {
            InitializeComponent();

            this.mainID = mainID;
        }

        private void btn_CloseMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_OpenMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void list_AllUsers_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void list_Customers_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void list_Executors_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void list_RegisterNewUser_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void list_EditUserAccount_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void list_CreateRequest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void list_WatchRequest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void list_WatchArchiveRequest_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void list_FileReport_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
