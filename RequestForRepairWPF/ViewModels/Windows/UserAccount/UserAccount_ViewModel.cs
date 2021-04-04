using RequestForRepairWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.Windows.UserAccount
{
    class UserAccount_ViewModel : ViewModel
    {
        /// <summary> Получение ID авторизованнного пользователя </summary>
        #region Получение ID авторизованнного пользователя
        /// <summary> Получение ID авторизованнного пользователя </summary>

        public int _authorization_userID;

        public int Authorization_userID
        {
            get => _authorization_userID;
            set => Set(ref _authorization_userID, value);
        }

        #endregion

        #region Фамилия
        public string _userLastName;
        public string UserLastName
        {
            get => _userLastName;
            set => Set(ref _userLastName, value);
        }
        #endregion

        #region Имя
        public string _userName;
        public string UserName
        {
            get => _userName;
            set => Set(ref _userName, value);
        }
        #endregion

        #region Отчество
        public string _userMiddleName;
        public string UserMiddleName
        {
            get => _userMiddleName;
            set => Set(ref _userMiddleName, value);
        }
        #endregion

        #region Должность
        public string _userPosition;
        public string UserPosition
        {
            get => _userPosition;
            set => Set(ref _userPosition, value);
        }
        #endregion

        #region Телефон
        public string _userPhone;
        public string UserPhone
        {
            get => _userPhone;
            set => Set(ref _userPhone, value);
        }
        #endregion

        #region Логин
        public string _userLogin;
        public string UserLogin
        {
            get => _userLogin;
            set => Set(ref _userLogin, value);
        }
        #endregion

        #region Пароль
        public string _userPassword;
        public string UserPassword
        {
            get => _userPassword;
            set => Set(ref _userPassword, value);
        }
        #endregion

        #region Тип аккаунта
        public string _userTypeOfAccount;
        public string UserTypeOfAccount
        {
            get => _userTypeOfAccount;
            set => Set(ref _userTypeOfAccount, value);
        }
        #endregion

        #region Тип Категория исполнителя
        public string _userCategoryExecutors;
        public string UserCategoryExecutors
        {
            get => _userCategoryExecutors;
            set => Set(ref _userCategoryExecutors, value);
        }
        #endregion

        #region Список номеров помещений
        public List<int> _userRoomNumber;
        public List<int> UsetrRoomNumber
        {
            get => _userRoomNumber;
            set
            {
                Set(ref _userRoomNumber, value);
                //_userRoomNumber.CopyTo(value);
            }
        }
        #endregion

        #region начать редактирование
        public bool IsStartEdit { get; set; }
        public ICommand StartEdit
        {
            get
            {

            }
        } 

        #endregion
    }
}
