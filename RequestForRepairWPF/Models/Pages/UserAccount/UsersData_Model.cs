using RequestForRepairWPF.Data;
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
        //private User user = new User();
        //private int _userID_main, _userID_secondary;
        //private string _userName, _userLastName, _userMiddleName;
        //private string _userPosition, _userPhone, _userCategoryExecutors;
        //private string _userEmail, _userPassword, _userTypeOfAccount;

        /// <summary>
        /// Данные авторизованного пользователя
        /// </summary>
        /// <param name="_userEmail">Логин пользователя</param>
        /// <param name="_userPassword">Пароль пользователя</param>
        #region Конструктор
        public UsersData_Model(string _userEmail, string _userPassword)
        {
            //this._userEmail = _userEmail;
            //this._userPassword = _userPassword;

            User.user_login = _userEmail;
            User.user_password = _userPassword;
        }
        #endregion

        #region Получение данных из класса User
        public int User_ID
        {
            get => User.id_user;
        }

        public string User_Login
        {
            get => User.user_login;
        }

        public string User_Password
        {
            get => User.user_password;
        }

        public string User_TypeOfAccount
        {
            get => User.type_of_account;
        }

        public string User_LastName
        {
            get => User.last_name;
        }

        public string User_Name
        {
            get => User.name;
        }

        public string User_MiddleName
        {
            get => User.middle_name;
        }

        public string User_Position
        {
            get => User.position;
        }

        public string User_CategoryExecutors
        {
            get => User.category_executors;
        }

        public string User_Phone
        {
            get => User.phone;
        }
        #endregion

        #region Получение данных из БД

        /// <summary> Возврат id авторизованного пользователя </summary>
        #region Возврат id авторизованного пользователя
        /// <summary> Возврат id авторизованного пользователя </summary>

        public int ID
        {
            get
            {
                //_userID_main = context.Users
                //    .Where(c => c.user_login == _userEmail && c.user_password == _userPassword)
                //    .Select(c => c.id_user)
                //    .FirstOrDefault();

                User.id_user = context.Users
                    .Where(c => c.user_login == User.user_login && c.user_password == User.user_password)
                    .Select(c => c.id_user)
                    .FirstOrDefault();

                return User.id_user;

                //user.id_user = _userID_main;

                //return _userID_main;
            }
        }
        #endregion

        /// <summary> Возврат имени авторизованного пользователя </summary>
        #region Возврат имени авторизованного пользователя
        /// <summary> Возврат имени авторизованного пользователя </summary>

        public string Name
        {
            get
            {
                //_userName = context.Users
                //    .Where(c => c.id_user == _userID_main)
                //    .Select(c => c.name)
                //    .FirstOrDefault();
                //
                //user.name = _userName;
                //
                //return _userName;

                User.name = context.Users
                    .Where(c => c.id_user == User.id_user)
                    .Select(c => c.name)
                    .FirstOrDefault();

                return User.name;
            }
        }

        #endregion

        /// <summary> Возврат фамилии авторизованного пользователя </summary>
        #region Возврат фамилии авторизованного пользователя
        /// <summary> Возврат фамилии авторизованного пользователя </summary>

        public string LastName
        {
            get
            {
                //_userLastName = context.Users
                //    .Where(c => c.id_user == _userID_main)
                //    .Select(c => c.last_name)
                //    .FirstOrDefault();
                //
                //user.last_name = _userLastName;
                //
                //return _userLastName;

                User.last_name = context.Users
                    .Where(c => c.id_user == User.id_user)
                    .Select(c => c.last_name)
                    .FirstOrDefault();

                return User.last_name;
            }
        }

        #endregion

        /// <summary> Возврат Отчества авторизованного пользователя </summary>
        #region Возврат Отчества авторизованного пользователя
        /// <summary> Возврат Отчества авторизованного пользователя </summary>

        public string MiddleName
        {
            get
            {
                //_userMiddleName = context.Users
                //    .Where(c => c.id_user == _userID_main)
                //    .Select(c => c.middle_name)
                //    .FirstOrDefault();
                //
                //user.middle_name = _userMiddleName;
                //
                //return _userMiddleName;

                User.middle_name = context.Users
                    .Where(c => c.id_user == User.id_user)
                    .Select(c => c.middle_name)
                    .FirstOrDefault();

                return User.middle_name;
            }
        }

        #endregion

        /// <summary> Возврат Должности авторизованного пользователя </summary>
        #region Возврат Должности авторизованного пользователя
        /// <summary> Возврат Должности авторизованного пользователя </summary>

        public string Position
        {
            get
            {
                //_userPosition = context.Users
                //    .Where(c => c.id_user == _userID_main)
                //    .Select(c => c.position)
                //    .FirstOrDefault();
                //
                //user.position = _userPosition;
                //
                //return _userPosition;

                User.position = context.Users
                    .Where(c => c.id_user == User.id_user)
                    .Select(c => c.position)
                    .FirstOrDefault();

                return User.position;
            }
        }

        #endregion

        /// <summary> Возврат Телефона авторизованного пользователя </summary>
        #region Возврат Телефона авторизованного пользователя
        /// <summary> Возврат Телефона авторизованного пользователя </summary>

        public string Phone
        {
            get
            {
               // _userPhone = context.Users
               //     .Where(c => c.id_user == _userID_main)
               //     .Select(c => c.phone)
               //     .FirstOrDefault();
               //
               // user.phone = _userPhone;
               //
               // return _userPhone;

                User.phone = context.Users
                    .Where(c => c.id_user == User.id_user)
                    .Select(c => c.phone)
                    .FirstOrDefault();

                return User.phone;

            }
        }

        #endregion

        /// <summary> Возврат Логина авторизованного пользователя </summary>
        #region Возврат Логина авторизованного пользователя
        /// <summary> Возврат Логина авторизованного пользователя </summary>

        public string Login
        {
            get
            {
                //_userEmail = context.Users
                //    .Where(c => c.id_user == _userID_main)
                //    .Select(c => c.user_login)
                //    .FirstOrDefault();
                //
                //user.user_login = _userEmail;
                //
                //return _userEmail;

                User.user_login = context.Users
                    .Where(c => c.id_user == User.id_user)
                    .Select(c => c.user_login)
                    .FirstOrDefault();

                return User.user_login;
            }
        }

        #endregion

        /// <summary> Возврат Пароля авторизованного пользователя </summary>
        #region Возврат Пароля авторизованного пользователя
        /// <summary> Возврат Пароля авторизованного пользователя </summary>

        public string Password
        {
            get
            {
               // _userPassword = context.Users
               //     .Where(c => c.id_user == _userID_main)
               //     .Select(c => c.user_password)
               //     .FirstOrDefault();
               //
               // user.user_password = _userPassword;
               //
               // return _userPassword;

                User.user_password = context.Users
                    .Where(c => c.id_user == User.id_user)
                    .Select(c => c.user_password)
                    .FirstOrDefault();

                return User.user_password;
            }
        }

        #endregion

        /// <summary> Возврат Типа аккаунта авторизованного пользователя </summary>
        #region Возврат Типа аккаунта авторизованного пользователя
        /// <summary> Возврат Типа аккаунта авторизованного пользователя </summary>

        public string TypeOfAccount
        {
            get
            {
                //_userTypeOfAccount = context.Users
                //    .Where(c => c.id_user == _userID_main)
                //    .Select(c => c.type_of_account)
                //    .FirstOrDefault();
                //
                //user.type_of_account = _userTypeOfAccount;
                //
                //return _userTypeOfAccount;

                User.type_of_account = context.Users
                    .Where(c => c.id_user == User.id_user)
                    .Select(c => c.type_of_account)
                    .FirstOrDefault();

                return User.type_of_account;
            }
        }

        #endregion

        /// <summary> Возврат Категории исполнителя авторизованного пользователя </summary>
        #region Возврат Категории исполнителя авторизованного пользователя
        /// <summary> Возврат Категории исполнителя авторизованного пользователя </summary>

        public string CategoryExecutors
        {
            get
            {
               // _userCategoryExecutors = context.Users
               //     .Where(c => c.id_user == _userID_main)
               //     .Select(c => c.category_executors)
               //     .FirstOrDefault();
               //
               // user.category_executors = _userCategoryExecutors;
               //
               // return _userCategoryExecutors;

                User.category_executors = context.Users
                    .Where(c => c.id_user == User.id_user)
                    .Select(c => c.category_executors)
                    .FirstOrDefault();

                return User.category_executors;
            }
        }

        #endregion

        #endregion

        #region Проверка пользовательских данных

        #region Проверка пароля пользователя
        public string CheckUserPass
        {
            get
            {
                //_userPassword = context.Users
                //    .Where(c => c.user_login == _userEmail)
                //    .Select(c => c.user_password)
                //    .FirstOrDefault();
                //return _userPassword;

                User.user_password = context.Users
                    .Where(c => c.user_login == User.user_login)
                    .Select(c => c.user_password)
                    .FirstOrDefault();

                return User.user_password;
            }
        }
        #endregion

        #region Проверка типа аккаунта пользователя
        public string CheckUserType
        {
            get
            {
               // _userTypeOfAccount = context.Users
               //     .Where(c => c.user_login == _userEmail &&
               //     c.user_password == _userPassword)
               //     .Select(c => c.type_of_account)
               //     .FirstOrDefault();
               // return _userTypeOfAccount;

                User.type_of_account = context.Users
                    .Where(c => c.user_login == User.user_login &&
                    c.user_password == User.user_password)
                    .Select(c => c.type_of_account)
                    .FirstOrDefault();

                return User.type_of_account;
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
