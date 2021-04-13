using RequestForRepairWPF.Infrastructure.Commands.Controls.Password;
using RequestForRepairWPF.Services;
using RequestForRepairWPF.ViewModels.Base;
using RequestForRepairWPF.Views.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.Pages.UserAccount
{
    public class UsersData_ViewModel : ViewModel
    {

        /// <summary> Получение ID авторизорованнного пользователя </summary>
        #region Получение ID авторизорованнного пользователя
        /// <summary> Получение ID авторизорованнного пользователя </summary>

        private static int _authorization_userID;
        public int Authorization_userID
        {
            get => _authorization_userID;
            set => Set(ref _authorization_userID, value);
        }
        #endregion

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

        #region Тип аккаунта
        private static string _userType;
        public string UserType
        {
            get => _userType;
            set => Set(ref _userType, value);
            //OpenUserAccount;
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

        #region Категория исполнителя
        private static string _userCategoryExecutors;
        public string UserCategoryExecutors
        {
            get => _userCategoryExecutors;
            set => Set(ref _userCategoryExecutors, value);
        }
        #endregion

       //#region Список номеров помещений
       //private List<int> _userRoomNumber;
       //public List<int> UserRoomNumber
       //{
       //    get => _userRoomNumber;
       //    set
       //    {
       //        Set(ref _userRoomNumber, value);
       //        //_userRoomNumber.CopyTo(value);
       //    }
       //}
       //#endregion


        #region Команда на вход
        public ICommand LoginCommand { get; }
        public UsersData_ViewModel()
        {
            LoginCommand = new LoginCommand(this);

        }
        #endregion

        #region Команда для загрузки страницы "Описание помещения"
        private ICommand _openDescriptionRoomView;
        public ICommand OpenDescriptionRoomView
        {
            get
            {
                _openDescriptionRoomView = new OpenDescriptionRoomViewCommand(this);
                return _openDescriptionRoomView;
            }
        }

        #endregion
    }

    #region Класс для загрузки страницы "Описание помещения"
    internal class OpenDescriptionRoomViewCommand : MyCommand
    {
        public OpenDescriptionRoomViewCommand(UsersData_ViewModel usersData_ViewModel) : base(usersData_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => PageManager.MainFrame.Navigate(new DescriptionRoomPage_View());
    }
    #endregion

    #region Вспомогательный класс для команд
    abstract class MyCommand : ICommand
    {
        protected UsersData_ViewModel _usersData_ViewModel;

        public MyCommand(UsersData_ViewModel usersData_ViewModel)
        {
            _usersData_ViewModel = usersData_ViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
    #endregion
}
