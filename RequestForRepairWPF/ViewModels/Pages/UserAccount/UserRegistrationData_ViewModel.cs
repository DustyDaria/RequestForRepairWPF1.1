using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.ViewModels.Base;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.Views.DialogWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.Pages.UserAccount
{
    public class UserRegistrationData_ViewModel : ViewModel
    {
        #region Логин
        private static string _userEmail;
        public string UserEmail
        {
            get => _userEmail;
            set => Set(ref _userEmail, value);
        }
        #endregion

        #region Пароль
        private static string _userPassword;
        public string UserPassword
        {
            get => _userPassword;
            set => Set(ref _userPassword, value);
        }
        #endregion

        #region Повторите пароль
        private static string _userRepeatPassword;
        public string UserRepeatPassword
        {
            get => _userRepeatPassword;
            set => Set(ref _userRepeatPassword, value);
        }
        #endregion

        #region Тип аккаунта
        private static string _userType;
        public string UserType
        {
            get => _userType;
            set => Set(ref _userType, value);
        }

        #endregion

        #region Фамилия
        private static string _userLastName;
        public string UserLastName
        {
            get => _userLastName;
            set => Set(ref _userLastName, value);
        }
        #endregion

        #region Имя
        private static string _userName;
        public string UserName
        {
            get => _userName;
            set => Set(ref _userName, value);
        }
        #endregion

        #region Отчество
        private static string _userMiddleName;
        public string UserMiddleName
        {
            get => _userMiddleName;
            set => Set(ref _userMiddleName, value);
        }
        #endregion

        #region Должность
        private static string _userPosition;
        public string UserPosition
        {
            get => _userPosition;
            set => Set(ref _userPosition, value);
        }
        #endregion

        #region Телефон
        private static string _userPhone;
        public string UserPhone
        {
            get => _userPhone;
            set => Set(ref _userPhone, value);
        }
        #endregion

        #region Номер помещения
        private static int _userRoomNumber;
        public int UserRoomNumber
        {
            get => _userRoomNumber;
            set => Set(ref _userRoomNumber, value);
        }
        #endregion

        #region Категория исполнителя
        private static string _userCategoryExecutors;
        public string UserCategoryExecutors
        {
            get => _userCategoryExecutors;
            set => Set(ref _userCategoryExecutors, value);
        }
        #endregion

        #region Список типов аккаунтов пользователей
        private List<string> _listUsersType;
        public List<string> ListUsersType
        {
            get => _listUsersType;
            set => Set(ref _listUsersType, value);
        }
        #endregion

        #region Команда на добаление пользовательских типов аккаунтов при загрузке
        private ICommand _loadUsersType;
        public ICommand LoadUsersType
        {
            get
            {
                _loadUsersType = new LoadUsersTypeCommand(this);
                return _loadUsersType;
            }
        }
        #endregion

        #region Команда на добавление пользовательских регистрационных данных
        private ICommand _regUserData;
        public ICommand RegUserDataCommand
        {
            get
            {
                _regUserData = new RegUserDataCommand(this);
                return _regUserData;
            }
        }
        #endregion
    }

    internal class LoadUsersTypeCommand : MyRegCommand
    {
        public LoadUsersTypeCommand(UserRegistrationData_ViewModel userRegData_ViewModel) : base(userRegData_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => _userRegData_ViewModel.ListUsersType = TypeOfAccount.AllType;

        //private void LoadTypes()
        //{
        //    _userRegData_ViewModel.ListUsersType = TypeOfAccount.AllType;
        //}
    }

    internal class RegUserDataCommand : MyRegCommand
    {
        public RegUserDataCommand(UserRegistrationData_ViewModel userRegData_ViewModel) : base(userRegData_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => SaveClick();
        private void SaveClick()
        {
            MessageBox_ViewModel messageBox_ViewModel = new MessageBox_ViewModel();
            MessageBox_View messageBox_View = new MessageBox_View();

            if (_userRegData_ViewModel.UserType == "Системный администратор")
            {
                if (_userRegData_ViewModel.UserLastName == string.Empty)
                {
                    messageBox_ViewModel.TextMessage = "Пожалуйста, введите фамилию пользователя!";
                    messageBox_View.Show();
                }
                else if (_userRegData_ViewModel.UserName == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserPosition == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserPhone == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserEmail == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserPassword == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserRepeatPassword == string.Empty
                    && _userRegData_ViewModel.UserPassword != _userRegData_ViewModel.UserRepeatPassword)
                {

                }
                else
                {

                }
            }
            else if (_userRegData_ViewModel.UserType == "Заказчик")
            {
                if (_userRegData_ViewModel.UserLastName == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserMiddleName == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserName == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserPosition == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserPhone == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserEmail == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserPassword == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserRepeatPassword == string.Empty
                    && _userRegData_ViewModel.UserPassword != _userRegData_ViewModel.UserRepeatPassword)
                {

                }
                else if (_userRegData_ViewModel.UserRoomNumber == 0)
                {

                }
                else
                {

                }
            }
            else if (_userRegData_ViewModel.UserType == "Исполнитель")
            {
                if (_userRegData_ViewModel.UserLastName == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserMiddleName == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserName == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserPosition == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserPhone == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserEmail == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserPassword == string.Empty)
                {

                }
                else if (_userRegData_ViewModel.UserRepeatPassword == string.Empty
                    && _userRegData_ViewModel.UserPassword != _userRegData_ViewModel.UserRepeatPassword)
                {

                }
                else if (_userRegData_ViewModel.UserCategoryExecutors == string.Empty)
                {

                }
                else
                {

                }
            }

        }
    }

    #region Вспомогательный класс для команд
    abstract class MyRegCommand : ICommand
    {
        protected UserRegistrationData_ViewModel _userRegData_ViewModel;
        public MyRegCommand(UserRegistrationData_ViewModel userRegData_ViewModel)
        {
            _userRegData_ViewModel = userRegData_ViewModel;
        }
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }

    #endregion
}
