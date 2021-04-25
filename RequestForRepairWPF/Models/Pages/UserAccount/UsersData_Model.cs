using RequestForRepairWPF.Data;
using RequestForRepairWPF.Data.Room;
using RequestForRepairWPF.Data.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Models.Pages.UserAccount
{
    public class UsersData_Model : INotifyPropertyChanged
    {
        private Entities.DB_RequestForRepairEntities3 context = new Entities.DB_RequestForRepairEntities3();

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

        public int User_IDType
        {
            get => User.id_type;
        }

        public string User_Login
        {
            get => User.user_login;
        }

        public string User_Password
        {
            get => User.user_password;
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
                User.id_user = context.Users
                    .Where(c => c.user_login == User.user_login && c.user_password == User.user_password)
                    .Select(c => c.id_user)
                    .FirstOrDefault();

                return User.id_user;
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

        public int TypeOfAccount_get
        {
            get
            {
                //User.type_of_account = context.Users
                //    .Where(c => c.id_user == User.id_user)
                //    .Select(c => c.type_of_account)
                //    .FirstOrDefault();
                //
                //return User.type_of_account;

                User.id_type = context.Users
                    .Where(c => c.TypeOfAccount.id_type == c.id_type && 
                    c.id_user == User.id_user)
                    .Select(c => c.id_type)
                    .FirstOrDefault();

                return User.id_type;
            }
        }

        #endregion

        /// <summary> Возврат списка типов аккаунтов </summary>
        #region Возврат списка типов аккаунтов
        /// <summary> Возврат списка типов аккаунтов </summary>
        
        public List<string> ListUsersType
        {
            get
            {
                var allTypes = from t in context.TypeOfAccount
                               select t.name_type;
                foreach (var s in allTypes)
                    TypeOfAccount.AllType.Add(s);

                return TypeOfAccount.AllType;
            }
        }
        #endregion

        /// <summary> Возврат списка категорий исполнителя</summary>
        #region Возврат списка категорий исполнителя
        /// <summary> Возврат списка категорий исполнителя</summary>
        public List<string> ListCategoryExecutors
        {
            get
            {
                var allCategory = (from c in context.Users
                                   where c.category_executors != string.Empty && c.category_executors != null
                                   select c.category_executors)
                                  .Distinct();
                foreach (var s in allCategory)
                    User.AllCategoryExecutors.Add(s);

                return User.AllCategoryExecutors;
            }
        }
        #endregion

        /// <summary> Возврат списка всех помещений</summary>
        #region Возврат списка всех помещений
        /// <summary> Возврат списка всех помещений</summary>
        public List<int> ListAllRommsNumber
        {
            get
            {
                var allRooms = from r in context.Rooms
                               select r.room_number;
                foreach (var s in allRooms)
                    Rooms.AllRoomsNumber.Add(s);

                return Rooms.AllRoomsNumber;
            }
        }
        #endregion

        /// <summary> Возврат списка свободных помещений</summary>
        #region Возврат списка свободных помещений
        /// <summary> Возврат списка свободных помещений</summary>
        public List<int> ListLiberyRoomsNumber
        {
            get
            {
                var allLibertyRooms = from r in context.Rooms
                                      where r.room_status == false
                                      select r.room_number;
                foreach (var s in allLibertyRooms)
                    Rooms.AllLibertyRoomsNumber.Add(s);

                return Rooms.AllLibertyRoomsNumber;
            }
        }
        #endregion

        /// <summary> Возврат списка всех помещений авторизованного пользователя</summary>
        #region Возврат списка всех помещений авторизованного пользователя
        /// <summary> Возврат списка всех помещений авторизованного пользователя</summary>
        /// 
        //private List<int> _listUserRoomsNumber;
        public List<int> ListUserRoomsNumber
        {
            get
            {
                var queryRoomsID = from r in context.U_R_Room
                                       where r.userID_URR == User.id_user
                                       select r.id_room;

                foreach (var q in queryRoomsID)
                {
                    U_R_Room.listAll_id_room.Add(q);

                    //var queryRoomsNumber = from t in context.Rooms
                    //                       where t.id_room == q
                    //                       select t.room_number;
                    var queryRoomsNumber = context.Rooms
                        .Where(c => c.id_room == q)
                        .Select(c => c.room_number)
                        .FirstOrDefault();
                   // _listUserRoomsNumber.Add(queryRoomsNumber);
                    U_R_Room.list_user_rooms_number.Add(queryRoomsNumber);
                }

                // return _listUserRoomsNumber;
                return U_R_Room.list_user_rooms_number;
            }
        }
        #endregion

        #region Возврат номера помещения заказчика авторизованного пользователя
        public int RoomNumber
        {
            get
            {
                U_R_Room.id_room = context.U_R_Room
                    .Where(c => c.userID_URR == User.id_user)
                    .Select(c => c.id_room)
                    .FirstOrDefault();

                int roomNumber = context.Rooms
                    .Where(c => c.id_room == U_R_Room.id_room)
                    .Select(c => c.room_number)
                    .FirstOrDefault();

                return roomNumber;
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
                User.user_password = context.Users
                    .Where(c => c.user_login == User.user_login)
                    .Select(c => c.user_password)
                    .FirstOrDefault();

                return User.user_password;
            }
        }
        #endregion

        #region Проверка типа аккаунта пользователя
        public int CheckUserType
        {
            get
            {
                //User.type_of_account = context.Users
                //    .Where(c => c.user_login == User.user_login &&
                //    c.user_password == User.user_password)
                //    .Select(c => c.type_of_account)
                //    .FirstOrDefault();
                //
                //return User.type_of_account;
                User.id_type = context.Users
                    .Where(c => c.user_login == User.user_login &&
                    c.user_password == User.user_password)
                    .Select(c => c.id_type)
                    .FirstOrDefault();
                return User.id_type;
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
