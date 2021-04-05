using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Models.Windows.UserAccount
{
    public class UsersData_Model : INotifyPropertyChanged
    {
        private Entities.DB_RequestForRepairEntities context = new Entities.DB_RequestForRepairEntities();
        private int _userID_main, _userID_secondary;
        private string _userName, _userLastName, _userMiddleName;
        private string _userPosition, _userPhone, _userCategoryExecutors;
        private string _userEmail, _userPassword, _userTypeOfAccount;

        /// <summary>
        /// Данные авторизованного пользователя
        /// </summary>
        /// <param name="_userEmail">Логин пользователя</param>
        /// <param name="_userPassword">Пароль пользователя</param>
        #region Конструктор
        public UsersData_Model(string _userEmail, string _userPassword)
        {
            this._userEmail = _userEmail;
            this._userPassword = _userPassword;
        }
        #endregion

        /// <summary> Возврат id авторизованного пользователя </summary>
        #region Возврат id авторизованного пользователя
        /// <summary> Возврат id авторизованного пользователя </summary>

        public int UserID
        {
            get
            {
                _userID_main = context.Users
                    .Where(c => c.user_login == _userEmail && c.user_password == _userPassword)
                    .Select(c => c.id_user)
                    .FirstOrDefault();

                return _userID_main;
            }
        }
        #endregion


        /// <summary> Возврат имени авторизованного пользователя </summary>
        #region Возврат имени авторизованного пользователя
        /// <summary> Возврат имени авторизованного пользователя </summary>

        public string UserName
        {
            get
            {
                _userName = context.Users
                    .Where(c => c.id_user == _userID_main)
                    .Select(c => c.name)
                    .FirstOrDefault();

                return _userName;
            }
        }

        #endregion

        /// <summary> Возврат фамилии авторизованного пользователя </summary>
        #region Возврат фамилии авторизованного пользователя
        /// <summary> Возврат фамилии авторизованного пользователя </summary>

        public string UserLastName
        {
            get
            {
                _userLastName = context.Users
                    .Where(c => c.id_user == _userID_main)
                    .Select(c => c.last_name)
                    .FirstOrDefault();

                return _userLastName;
            }
        }

        #endregion

        /// <summary> Возврат Отчества авторизованного пользователя </summary>
        #region Возврат Отчества авторизованного пользователя
        /// <summary> Возврат Отчества авторизованного пользователя </summary>

        public string UserMiddleName
        {
            get
            {
                _userMiddleName = context.Users
                    .Where(c => c.id_user == _userID_main)
                    .Select(c => c.middle_name)
                    .FirstOrDefault();

                return _userMiddleName;
            }
        }

        #endregion

        /// <summary> Возврат Должности авторизованного пользователя </summary>
        #region Возврат Должности авторизованного пользователя
        /// <summary> Возврат Должности авторизованного пользователя </summary>

        public string UserPosition
        {
            get
            {
                _userPosition = context.Users
                    .Where(c => c.id_user == _userID_main)
                    .Select(c => c.position)
                    .FirstOrDefault();

                return _userPosition;
            }
        }

        #endregion

        /// <summary> Возврат Телефона авторизованного пользователя </summary>
        #region Возврат Телефона авторизованного пользователя
        /// <summary> Возврат Телефона авторизованного пользователя </summary>

        public string UserPhone
        {
            get
            {
                _userPhone = context.Users
                    .Where(c => c.id_user == _userID_main)
                    .Select(c => c.phone)
                    .FirstOrDefault();

                return _userPhone;
            }
        }

        #endregion


        /// <summary> Возврат Логина авторизованного пользователя </summary>
        #region Возврат Логина авторизованного пользователя
        /// <summary> Возврат Логина авторизованного пользователя </summary>

        public string UserLogin
        {
            get
            {
                _userEmail = context.Users
                    .Where(c => c.id_user == _userID_main)
                    .Select(c => c.user_login)
                    .FirstOrDefault();

                return _userEmail;
            }
        }

#endregion

        /// <summary> Возврат Пароля авторизованного пользователя </summary>
        #region Возврат Пароля авторизованного пользователя
        /// <summary> Возврат Пароля авторизованного пользователя </summary>

        public string UserPassword
        {
            get
            {
                _userPassword = context.Users
                    .Where(c => c.id_user == _userID_main)
                    .Select(c => c.user_password)
                    .FirstOrDefault();

                return _userPassword;
            }
        }

        #endregion

        /// <summary> Возврат Типа аккаунта авторизованного пользователя </summary>
        #region Возврат Типа аккаунта авторизованного пользователя
        /// <summary> Возврат Типа аккаунта авторизованного пользователя </summary>

        public string UserTypeOfAccount
        {
            get
            {
                _userTypeOfAccount = context.Users
                    .Where(c => c.id_user == _userID_main)
                    .Select(c => c.type_of_account)
                    .FirstOrDefault();

                return _userTypeOfAccount;
            }
        }

        #endregion

        /// <summary> Возврат Категории исполнителя авторизованного пользователя </summary>
        #region Возврат Категории исполнителя авторизованного пользователя
        /// <summary> Возврат Категории исполнителя авторизованного пользователя </summary>

        public string UserCategoryExecutors
        {
            get
            {
                _userCategoryExecutors = context.Users
                    .Where(c => c.id_user == _userID_main)
                    .Select(c => c.category_executors)
                    .FirstOrDefault();

                return _userCategoryExecutors;
            }
        }

        #endregion


        #region Проверка пользовательских данных

        #region Проверка пароля пользователя
        public string CheckUserPass
        {
            get
            {
                _userPassword = context.Users
                    .Where(c => c.user_login == _userEmail)
                    .Select(c => c.user_password)
                    .FirstOrDefault();
                return _userPassword;
            }
        }
        #endregion

        #region Проверка типа аккаунта пользователя
        public string CheckUserType
        {
            get
            {
                _userTypeOfAccount = context.Users
                    .Where(c => c.user_login == _userEmail &&
                    c.user_password == _userPassword)
                    .Select(c => c.type_of_account)
                    .FirstOrDefault();
                return _userTypeOfAccount;
            }
        }
        #endregion

        #endregion

        /// <summary> Событие на изменение модели </summary>
        #region Событие на изменение модели
        /// <summary> Событие на изменение модели </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        //Метод, который скажет ViewModel, что нужно передать виду новые данные
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
