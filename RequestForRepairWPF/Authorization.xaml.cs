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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RequestForRepairWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        string userEmail = string.Empty;
        string userPassword = string.Empty;
        int userID = 0;
        //string Email = string.Empty;
        //string Password = string.Empty;

        DataBase dataBase = new DataBase();

        public Authorization()
        {
            InitializeComponent();
        }

        private void UserAuthorization(string userType)
        {
            userEmail = textBox_Email.Text;
            userPassword = textBox_Password.Password.ToString();

            string queryCheckUserData_GET = string.Format("SELECT user_password FROM Users WHERE user_login = '" + userEmail + "';");
            string queryCheckUserType = string.Format("SELECT type_of_account FROM Users WHERE user_login = '" + userEmail + "' AND user_password = '" + userPassword + "';");

            if (userEmail == string.Empty)
            {
                MessageBox.Show("Пожалуйста, введите Ваш логин!");
            }
            else if (userPassword == string.Empty)
            {
                MessageBox.Show("Пожалуйста, введите Ваш пароль!");
            }
            else
            {
                if (dataBase.GetResult(queryCheckUserData_GET) == userPassword)
                {
                    if(dataBase.GetResult(queryCheckUserType) == userType && userType == "Системный администратор")
                    {
                        UserIsAdmin();
                    }
                    else if (dataBase.GetResult(queryCheckUserType) == userType && userType == "Заказчик")
                    {
                        UserIsCustomer();
                    }
                    else if (dataBase.GetResult(queryCheckUserType) == userType && userType == "Исполнитель")
                    {
                        UserIsExecutor();
                    }
                    else
                    {
                        MessageBox.Show("Ваш тип аккаунта не совпадает с зарегистрированным пользователем!");
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректные пользовательские данные!");
                }
            }
        }

        private void UserIsAdmin()
        {
            string queryUsersID_GET = string.Format("SELECT id_user FROM Users WHERE user_login = '" + userEmail + "' AND user_password = '" + userPassword + "';");
            userID = dataBase.GetID(queryUsersID_GET);

            Menu_Administrator menu_Administrator = new Menu_Administrator(userID);
            this.Close();
            menu_Administrator.Show();
        }

        private void UserIsCustomer()
        {
            string queryUsersID_GET = string.Format("SELECT id_user FROM Users WHERE user_login = '" + userEmail + "' AND user_password = '" + userPassword + "';");
            userID = dataBase.GetID(queryUsersID_GET);

            Menu_Customer menu_Customer = new Menu_Customer(userID);
            this.Close();
            menu_Customer.Show();
        }

        private void UserIsExecutor()
        {
            string queryUsersID_GET = string.Format("SELECT id_user FROM Users WHERE user_login = '" + userEmail + "' AND user_password = '" + userPassword + "';");
            userID = dataBase.GetID(queryUsersID_GET);

            Menu_Executor menu_Executor = new Menu_Executor(userID);
            this.Close();
            menu_Executor.Show();
        }

        private void btn_Administrator_Click(object sender, RoutedEventArgs e)
        {
            UserAuthorization("Системный администратор");
        }

        private void btn_Customer_Click(object sender, RoutedEventArgs e)
        {
            UserAuthorization("Заказчик");
        }

        private void btn_Executor_Click(object sender, RoutedEventArgs e)
        {
            UserAuthorization("Исполнитель");
        }
    }
}
