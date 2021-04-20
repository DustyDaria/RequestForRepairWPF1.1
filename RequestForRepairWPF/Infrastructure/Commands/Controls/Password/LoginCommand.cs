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
            _viewModel.UserEmail = model.User_Login;
            _viewModel.UserPassword = model.User_Password;
            _viewModel.Authorization_userID = model.User_ID;
            _viewModel.UserType = model.User_IDType;
            _viewModel.UserLastName = model.User_LastName;
            _viewModel.UserName = model.User_Name;
            _viewModel.UserMiddleName = model.User_MiddleName;
            _viewModel.UserPosition = model.User_Position;
            _viewModel.UserPhone = model.User_Phone;
            _viewModel.UserCategoryExecutors = model.User_CategoryExecutors;
            _viewModel.UserRoomNumber = model.RoomNumber;

            _viewModel.ListUsersType = model.ListUsersType;
        }
    }

   
}
