
using RequestForRepairWPF.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Models.Pages
{
    class AllUsers_Model : INotifyPropertyChanged
    {
        //private readonly Entities.DB_RequestForRepairEntities context = new Entities.DB_RequestForRepairEntities();
        //private readonly Entities.DB_RequestForRepairEntities context = new Entities.DB_RequestForRepairEntities();
        public ObservableCollection<User> UsersCollection = new ObservableCollection<User>();

        //User userObj = new User();

        /// <summary>Конструкторы</summary>
        #region Конструкторы
        /// <summary>Конструкторы</summary>
        
        public AllUsers_Model() { }
        //public AllUsers_Model(int id_user, string user_login, string last_name, string name, string middle_name, string position, string type_of_account, string category_executors, string phone)
        //{
        //    userObj.id_user = id_user;
        //    userObj.user_login = user_login;
        //    userObj.last_name = last_name;
        //    userObj.name = name;
        //    userObj.middle_name = middle_name;
        //    userObj.position = position;
        //    userObj.type_of_account = type_of_account;
        //    userObj.category_executors = category_executors;
        //    userObj.phone = phone;
        //}
        #endregion

        // Нужно будет добавить SET при реализации редактирования
        /// <summary>GET,SET</summary>
        #region GET,SET
        /// <summary>GET,SET</summary>
        
        //public int Id_user
        //{
        //    get => userObj.id_user;
        //}
        //public string User_login
        //{
        //    get => userObj.user_login;
        //    
        //}
        //public string Last_name
        //{
        //    get => userObj.last_name;
        //    
        //}
        //public string Name
        //{
        //    get => userObj.name;
        //    
        //}
        //public string Middle_name
        //{
        //    get => userObj.middle_name;
        //    
        //}
        //public string Position
        //{
        //    get => userObj.position;
        //    
        //}
        //public string Type_of_account
        //{
        //    get => userObj.type_of_account;
        //}
        //public string Category_executors
        //{
        //    get => userObj.category_executors;
        //    
        //}
        //
        //public string Phone
        //{
        //    get => userObj.phone;
        //    
        //}
        #endregion


        /// <summary>Загрузка данных</summary>
        #region Загрузка данных

        /// <summary>Загрузка данных</summary>
        public ObservableCollection<User> LoadData()
        {
            /*var _context = context.Users;
            var _query = _context.ToList()
                .ConvertAll(e => new User(e));
            foreach(var _user in _query)
            {
                UsersCollection.Add(new User
                {
                    id_user = _user.id_user,
                    user_login = _user.user_login,
                    last_name = _user.last_name,
                    name = _user.name,
                    middle_name = _user.middle_name,
                    position = _user.position,
                    type_of_account = _user.type_of_account,
                    category_executors = _user.category_executors,
                    phone = _user.phone
                });
            }*/
            return UsersCollection;
        }
        #endregion


        /// <summary>Событие на изменение модели</summary>
        #region Событие на изменение модели
        /// <summary>Событие на изменение модели</summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") // Метод, который скажет ViewModel, что нужно передать виду новые данные
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
            
        #endregion
    }
}
