using RequestForRepairWPF.Infrastructure.Commands.Base;
using RequestForRepairWPF.Models.Windows;
using RequestForRepairWPF.Models.Windows.UserAccount;
using RequestForRepairWPF.Services;
using RequestForRepairWPF.ViewModels.Windows;
using RequestForRepairWPF.ViewModels.Windows.UserAccount;
using RequestForRepairWPF.Views.Pages.UserAccount;
using RequestForRepairWPF.Views.Windows;
using RequestForRepairWPF.Views.Windows.UserAccount;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace RequestForRepairWPF.Infrastructure.Commands.Controls.Password
{
    public class LoginCommand : Command
    {
        private readonly UsersData_ViewModel _viewModel;
        
        public string _email, _password, _typeOfAccount;
        public string _name, _lastName, _middleName;
        public string _position, _phone, _categoryExecutors;
        public int _id;

        public LoginCommand(UsersData_ViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => LogIn();

        public void LogIn()
        {
            _email = _viewModel.UserEmail;
            _password = _viewModel.UserPassword;

            if (_email == string.Empty || _email == null)
            {
                MessageBox.Show("Доделай диалоговые окна\nПожалуйста, введите Ваш логин!");
            }
            else if (_password == string.Empty && _password == null)
            {
                MessageBox.Show("Доделай диалоговые окна\nПожалуйста, введите Ваш пароль!");
            }
            else
            {
                UsersData_Model _model = new UsersData_Model(_email, _password);

                if(_model.CheckUserPass == _password && _model.CheckUserType == "Системный администратор")
                {
                    //_viewModel.Authorization_userID = _model.ID;
                    //_viewModel.UserType = _model.CheckUserType;
                    //_viewModel.UserLastName = _model.LastName;
                    //_viewModel.UserName = _model.Name;
                    //_viewModel.UserMiddleName = _model.MiddleName;
                    //_viewModel.UserPosition = _model.Position;
                    //_viewModel.UserPhone = _model.Phone;
                    //_viewModel.UserCategoryExecutors = _model.CategoryExecutors;

                    _id = _model.ID;
                    _typeOfAccount = _model.CheckUserType;
                    _lastName = _model.LastName;
                    _name = _model.Name;
                    _middleName = _model.MiddleName;
                    _position = _model.Position;
                    _phone = _model.Phone;
                    _categoryExecutors = _model.CategoryExecutors;

                    PageManager.MainFrame.Navigate(new UserAccountPage_View());

                    _viewModel.UserEmail = _model.User_Login;
                    _viewModel.UserPassword = _model.User_Password;
                    _viewModel.Authorization_userID = _model.User_ID;
                    _viewModel.UserType = _model.User_TypeOfAccount;
                    _viewModel.UserLastName = _model.User_LastName;
                    _viewModel.UserName = _model.User_LastName;
                    _viewModel.UserMiddleName = _model.User_MiddleName;
                    _viewModel.UserPosition = _model.User_Position;
                    _viewModel.UserPhone = _model.User_Phone;
                    _viewModel.UserCategoryExecutors = _model.User_CategoryExecutors;

                }
                else if(_model.CheckUserPass == _password && _model.CheckUserType == "Заказчик")
                {
                
                    _viewModel.Authorization_userID = _model.ID;
                    //userAccount_ViewModel.Authorization_userID = _model.UserID;
                    CustomerUserAccount_View customerUserAccount_View = new CustomerUserAccount_View(_model.ID, "Просмотреть", 0);
                    Authorization_View authorization_View = new Authorization_View();
                    customerUserAccount_View.Show();
                    //authorization_View.Close();

                }
                else if(_model.CheckUserPass == _password && _model.CheckUserType == "Исполнитель")
                {
                    _viewModel.Authorization_userID = _model.ID;
                    //userAccount_ViewModel.Authorization_userID = _model.UserID;
                    _viewModel.UserType = _model.CheckUserType;
                    UserAccount_View userAccount_View = new UserAccount_View();
                    Authorization_View authorization_View = new Authorization_View();
                    //userAccount_ViewModel.Authorization_userID = _model.UserID;
                    userAccount_View.Show();
                    //authorization_View.Close();



                    //_openExecutorsView = new OpenUserAccountViewCommand(_viewModel);
                }
            }
        }
    }

   
}
