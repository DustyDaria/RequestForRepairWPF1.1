using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Models.Windows
{
    class Authorization_Model : INotifyPropertyChanged
    {
        private Entities.DB_RequestForRepairEntities context = new Entities.DB_RequestForRepairEntities();
        private int _userID;
        private string _userEmail;
        private string _userPassword;
        private string _userType;

        /// <summary> Возврат id авторизованного пользователя </summary>
        #region Возврат id авторизованного пользователя
        /// <summary> Возврат id авторизованного пользователя </summary>

        public int UserID
        {
            get
            {
                _userID = context.Users
                    .Where(c => c.user_login == _userEmail && c.user_password == _userPassword)
                    .Select(c => c.id_user)
                    .FirstOrDefault();

                return _userID;
            }
        }
        #endregion

        /// <summary>
        /// Данные авторизованного пользователя
        /// </summary>
        /// <param name="_userEmail">Логин пользователя</param>
        /// <param name="_userPassword">Пароль пользователя</param>
        #region Конструктор
        public Authorization_Model(string _userEmail, string _userPassword)
        {
            this._userEmail = _userEmail;
            this._userPassword = _userPassword;
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
                _userType = context.Users
                    .Where(c => c.user_login == _userEmail &&
                    c.user_password == _userPassword)
                    .Select(c => c.type_of_account)
                    .FirstOrDefault();
                return _userType;
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
