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
    public partial class MainWindow : Window
    {
        string Email = string.Empty;
        string Password = string.Empty;

        DataBase dataBase = new DataBase();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            Email = textBox_Email.Text;
            Password = textBox_Password.Password.ToString();

            string queryCheckUserData_GET = string.Format("SELECT user_password FROM Users WHERE user_login = '" + Email + "';");

            if (Email == string.Empty || Email == "Enter your email address")
            {
                MessageBox.Show("Пожалуйста, введите Email!");
            }
            else if (Password == string.Empty || Password == "Enter your password")
            {
                MessageBox.Show("Пожалуйста, введите пароль!");
            }
            else
            {
                if (dataBase.GetResult(queryCheckUserData_GET) == Password)
                {
                    Authorization_TypeOfAccount authorization_TypeOfAccount = new Authorization_TypeOfAccount(Email, Password);
                    //this.Enabled = false;
                    this.Hide();
                    authorization_TypeOfAccount.Show();
                    //authorization_TypeOfAccount.FormClosed += (obj, args) => this.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректные пользовательские данные!");
                }


            }
        }
    }
}
