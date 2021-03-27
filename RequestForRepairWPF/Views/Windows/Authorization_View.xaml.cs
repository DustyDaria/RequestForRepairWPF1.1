using RequestForRepairWPF.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RequestForRepairWPF.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Authorization_View : Window
    {
        string userEmail = string.Empty;
        string userPassword = string.Empty;
        int userID = 0;
        //string Email = string.Empty;
        //string Password = string.Empty;

        DataBase dataBase = new DataBase();
        public User _authorizationUser = new User(); 

        public Authorization_View()
        {
            InitializeComponent();
        }

        public void UserAuthorization()
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
                if (dataBase.GetResult(queryCheckUserData_GET) == userPassword && dataBase.GetResult(queryCheckUserType) == "Системный администратор")
                {
                    string queryUsersID_GET = string.Format("SELECT id_user FROM Users WHERE user_login = '" + userEmail + "' AND user_password = '" + userPassword + "';");
                    userID = dataBase.GetID(queryUsersID_GET);
                    _authorizationUser.id_user = userID;

                    UserAccount_View personalAccount = new UserAccount_View(userID, "Просмотреть", 0);
                    personalAccount.Show();
                    this.Close();
                    
                }
                else if(dataBase.GetResult(queryCheckUserData_GET) == userPassword && dataBase.GetResult(queryCheckUserType) == "Заказчик")
                {
                    string queryUsersID_GET = string.Format("SELECT id_user FROM Users WHERE user_login = '" + userEmail + "' AND user_password = '" + userPassword + "';");
                    userID = dataBase.GetID(queryUsersID_GET);
                    _authorizationUser.id_user = userID;

                    CustomerUserAccount_View customerUser = new CustomerUserAccount_View(userID, "Просмотреть", 0);
                    // UserAccount_View personalAccount = new UserAccount_View(userID, "Просмотреть", 0);
                    customerUser.Show();
                    this.Close();
                    
                }
                else if (dataBase.GetResult(queryCheckUserData_GET) == userPassword && dataBase.GetResult(queryCheckUserType) == "Исполнитель")
                {
                    string queryUsersID_GET = string.Format("SELECT id_user FROM Users WHERE user_login = '" + userEmail + "' AND user_password = '" + userPassword + "';");
                    userID = dataBase.GetID(queryUsersID_GET);
                    _authorizationUser.id_user = userID;

                    UserAccount_View personalAccount = new UserAccount_View(userID, "Просмотреть", 0);
                    personalAccount.Show();
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректные пользовательские данные!");
                }
            }
        }


        private void btn_LogIn_Click(object sender, RoutedEventArgs e)
        {

            UserAuthorization();
        }
    }
}
