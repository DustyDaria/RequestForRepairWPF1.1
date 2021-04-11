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

        private void LogIn()
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
                    AddUserDataToModel(_model);

                    PageManager.MainFrame.Navigate(new UserAccountPage_View());

                    AddUserDataToViewModel(_model);

                }
                else if(_model.CheckUserPass == _password && _model.CheckUserType == "Заказчик")
                {
                    AddUserDataToModel(_model);

                    PageManager.MainFrame.Navigate(new CustomerUserAccountPage_View());

                    AddUserDataToViewModel(_model);
                }
                else if(_model.CheckUserPass == _password && _model.CheckUserType == "Исполнитель")
                {
                    AddUserDataToModel(_model);

                    PageManager.MainFrame.Navigate(new UserAccountPage_View());

                    AddUserDataToViewModel(_model);
                }
            }
        }

        private void AddUserDataToModel(UsersData_Model model)
        {
            _id = model.ID;
            _typeOfAccount = model.CheckUserType;
            _lastName = model.LastName;
            _name = model.Name;
            _middleName = model.MiddleName;
            _position = model.Position;
            _phone = model.Phone;
            _categoryExecutors = model.CategoryExecutors;
        }

        private void AddUserDataToViewModel(UsersData_Model model)
        {
            _viewModel.UserEmail = model.User_Login;
            _viewModel.UserPassword = model.User_Password;
            _viewModel.Authorization_userID = model.User_ID;
            _viewModel.UserType = model.User_TypeOfAccount;
            _viewModel.UserLastName = model.User_LastName;
            _viewModel.UserName = model.User_LastName;
            _viewModel.UserMiddleName = model.User_MiddleName;
            _viewModel.UserPosition = model.User_Position;
            _viewModel.UserPhone = model.User_Phone;
            _viewModel.UserCategoryExecutors = model.User_CategoryExecutors;
        }
    }

   
}
