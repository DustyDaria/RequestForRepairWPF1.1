using RequestForRepairWPF.Infrastructure.Commands.Base;
using RequestForRepairWPF.Models.Pages.UserAccount;
using RequestForRepairWPF.Services;
using RequestForRepairWPF.ViewModels.Pages.UserAccount;
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
        
        public string _email, _password;
        public string _name, _lastName, _middleName;
        public string _position, _phone, _categoryExecutors;
        public int _idUser, _roomNumber, _idType;
        public List<string> _listUsersType;

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

                if(_model.CheckUserPass == _password && _model.CheckUserType == 1)
                {
                    AddUserDataToModel(_model);

                    PageManager.MainFrame.Navigate(new UserAccountPage_View());

                    AddUserDataToViewModel(_model);

                }
                else if(_model.CheckUserPass == _password && _model.CheckUserType == 2)
                {
                    AddUserDataToModel(_model);

                    PageManager.MainFrame.Navigate(new CustomerUserAccountPage_View());

                    AddUserDataToViewModel(_model);
                }
                else if(_model.CheckUserPass == _password && _model.CheckUserType == 3)
                {
                    AddUserDataToModel(_model);

                    PageManager.MainFrame.Navigate(new UserAccountPage_View());

                    AddUserDataToViewModel(_model);
                }
            }
        }

        private void AddUserDataToModel(UsersData_Model model)
        {
            _idUser = model.ID;
            _idType = model.CheckUserType;
            _lastName = model.LastName;
            _name = model.Name;
            _middleName = model.MiddleName;
            _position = model.Position;
            _phone = model.Phone;
            _categoryExecutors = model.CategoryExecutors;
            _roomNumber = model.RoomNumber;

            _listUsersType = model.ListUsersType;
        }

        private void AddUserDataToViewModel(UsersData_Model model)
        {
            _viewModel.UserEmail = _email;
            _viewModel.UserPassword = _password;
            _viewModel.Authorization_userID = _idUser;
            _viewModel.UserType = _idType;
            _viewModel.UserLastName = _lastName;
            _viewModel.UserName = _name;
            _viewModel.UserMiddleName = _middleName;
            _viewModel.UserPosition = _position;
            _viewModel.UserPhone = _phone;
            _viewModel.UserCategoryExecutors = _categoryExecutors;
            _viewModel.UserRoomNumber = _roomNumber;

            _viewModel.ListUsersType = _listUsersType;
        }
    }

   
}
