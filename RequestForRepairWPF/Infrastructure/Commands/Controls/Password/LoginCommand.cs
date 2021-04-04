using RequestForRepairWPF.Infrastructure.Commands.Base;
using RequestForRepairWPF.Models.Windows;
using RequestForRepairWPF.ViewModels.Windows;
using RequestForRepairWPF.ViewModels.Windows.UserAccount;
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
        private readonly Authorization_ViewModel _viewModel;
        private Authorization_Model _model;
        private UserAccount_ViewModel userAccount_ViewModel = new UserAccount_ViewModel();
        private string _email;
        private string _password;


        public LoginCommand(Authorization_ViewModel viewModel)
        {
            _viewModel = viewModel;
            //_viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        //public event EventHandler CanExecuteChanged;

        //public bool CanExecute(object parameter)
        //{
        //    return !string.IsNullOrEmpty(_viewModel.UserEmail) &&
        //        !string.IsNullOrEmpty(_viewModel.UserPassword);
        //}

        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => LogIn();

        public void LogIn()
        {
            //MessageBox.Show("ДОПИШИ КОМАНДУ");

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
                //ICommand _openExecutorsView;
                _model = new Authorization_Model(_email, _password);

                if(_model.CheckUserPass == _password && _model.CheckUserType == "Системный администратор")
                {
                _viewModel.Authorization_userID = _model.UserID;
                userAccount_ViewModel.Authorization_userID = _model.UserID;
                _viewModel.UserType = _model.CheckUserType;
                    UserAccount_View userAccount_View = new UserAccount_View(_model.UserID);
                    Authorization_View authorization_View = new Authorization_View();
                    userAccount_View.Show();
                    authorization_View.Close();
                //ICommand _openUserAccount;
               // _openUserAccount =  _viewModel.OpenUserAccount;
                    

                    //_openExecutorsView = new OpenUserAccountViewCommand(_viewModel);
                    //UserAccount_View userAccount_View = new UserAccount_View();
                    //Authorization_View authorization = new Authorization_View();
                    //userAccount_View.Show();
                    //authorization.Close();
                }
                else if(_model.CheckUserPass == _password && _model.CheckUserType == "Заказчик")
                {
                
                    _viewModel.Authorization_userID = _model.UserID;
                    userAccount_ViewModel.Authorization_userID = _model.UserID;
                    CustomerUserAccount_View customerUserAccount_View = new CustomerUserAccount_View(_model.UserID, "Просмотреть", 0);
                    Authorization_View authorization_View = new Authorization_View();
                    customerUserAccount_View.Show();
                    authorization_View.Close();

                }
                else if(_model.CheckUserPass == _password && _model.CheckUserType == "Исполнитель")
                {
                    _viewModel.Authorization_userID = _model.UserID;
                    userAccount_ViewModel.Authorization_userID = _model.UserID;
                    _viewModel.UserType = _model.CheckUserType;
                    UserAccount_View userAccount_View = new UserAccount_View(_model.UserID);
                    Authorization_View authorization_View = new Authorization_View();
                    userAccount_View.Show();
                    authorization_View.Close();



                    //_openExecutorsView = new OpenUserAccountViewCommand(_viewModel);
                }
            }

            //return _model.CheckUserType;

        }

        

        //private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    CanExecuteChanged?.Invoke(this, new EventArgs());
        //}
    }

   
}
