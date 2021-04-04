using RequestForRepairWPF.Infrastructure.Commands.Controls.Password;
using RequestForRepairWPF.ViewModels.Base;
using RequestForRepairWPF.ViewModels.Windows.UserAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.Windows
{
    public class Authorization_ViewModel : ViewModel
    {
        /// <summary> Получение ID авторизорованнного пользователя </summary>
        #region Получение ID авторизорованнного пользователя
        /// <summary> Получение ID авторизорованнного пользователя </summary>

        private int _authorization_userID;

        public int Authorization_userID
        {
            get => _authorization_userID;
            set => Set(ref _authorization_userID, value);
        }

        #endregion

        #region Логин
        private string _userEmail;
        public string UserEmail
        {
            get => _userEmail;
            set => Set(ref _userEmail, value);
        }
        #endregion

        #region Пароль
        private string _userPassword;
        public string UserPassword
        {
            get => _userPassword;
            set => Set(ref _userPassword, value);
        }
        #endregion

        #region Тип аккаунта
        private string _userType;
        public string UserType
        {
            get => _userType;
            set => Set(ref _userType, value);
                //OpenUserAccount;
        }

        #endregion

        #region Команда на вход
        public ICommand LoginCommand { get; }
        public Authorization_ViewModel()
        {
            LoginCommand = new LoginCommand(this);

        }
        #endregion

        //#region Переход в ЛК пользователя
        //
        //private ICommand _loginCusCommand;
        //public ICommand LoginCusCommand
        //{
        //    get
        //    {
        //        if(_loginCusCommand == null)
        //        {
        //            _loginCusCommand = new OpenUserAccountViewCommand(this);
        //        }
        //        return _loginCusCommand;
        //    }
        //}
        //
        //private ICommand _loginExeCommand;
        //public ICommand LoginExeCommand
        //{
        //    get
        //    {
        //        if (_loginExeCommand == null)
        //        {
        //            _loginExeCommand = new OpenUserAccountViewCommand(this);
        //        }
        //        return _loginExeCommand;
        //    }
        //}
        //
        //private ICommand _loginAdmCommand;
        //public ICommand LoginAdmCommand
        //{
        //    get
        //    {
        //        if (_loginAdmCommand == null)
        //        {
        //            _loginAdmCommand = new OpenUserAccountViewCommand(this);
        //        }
        //        return _loginAdmCommand;
        //    }
        //}
        //
        //
        //private ICommand _openCustomerUserAccount;
        ////private void OpenUserAccount()
        //{
        //    if(_userType == "Системный администратор")
        //    {
        //        _openUserAccount = new OpenUserAccountViewCommand(this);
        //    }
        //    else if(_userType == "Заказчик")
        //    {
        //
        //    }
        //    else if(_userType == "Исполнитель")
        //    {
        //        _openUserAccount = new OpenUserAccountViewCommand(this);
        //    }
        //}
        //#endregion

        //#region Переброс в ЛК пользователя
        //
        //private ICommand _openUserAccountView;
        //public ICommand OpenUserAccountView
        //{
        //    get
        //    {
        //        if (_openUserAccountView == null)
        //        {
        //            _openUserAccountView = new OpenUserAccountViewCommand(this);
        //        }
        //        return _openUserAccountView;
        //    }
        //}
        //
        //#endregion
    }

    public class OpenUserAccountViewCommand : MyCommand
    {
        public OpenUserAccountViewCommand(Authorization_ViewModel authorization_ViewModel) : base(authorization_ViewModel)
        {

        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            var displayRootRegistry = (Application.Current as App).displayRootRegistry;

            var userAccount_ViewModel = new UserAccount_ViewModel();
            displayRootRegistry.ShowPresentation(userAccount_ViewModel);
        }
    }

    #region Вспомогательный класс для команд
    public abstract class MyCommand : ICommand
    {
        protected Authorization_ViewModel _authorization_ViewModel;

        public MyCommand(Authorization_ViewModel authorization_ViewModel)
        {
            _authorization_ViewModel = authorization_ViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
    #endregion
}
