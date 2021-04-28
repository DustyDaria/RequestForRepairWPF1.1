
using RequestForRepairWPF.Data;
using RequestForRepairWPF.Data.User;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Models.Pages.ViewingEditDelete_UsersData
{
    class AllUsers_Model : INotifyPropertyChanged
    {
        Entities.DB_RequestForRepairEntities3 context = new Entities.DB_RequestForRepairEntities3();

        //private List<int> _allIdUsers;
        public List<int> AllIdUsers
        {
            get
            {
                var query = from u in context.Users
                            select u.id_user;

                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(i);
                //_allIdUsers.Add(i);

                return User_DataModel.AllUsersID;
            }
        }


        public string UserLogin(int id)
        {
            string _login = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.user_login)
                .FirstOrDefault();

            return _login;
        }

        public string UserPass(int id)
        {
            string _password = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.user_password)
                .FirstOrDefault();

            return _password;
        }

        public string UserTypeOfAccount(int id)
        {
            string _typeOfAccount = null;
            int _idType = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.id_type)
                .FirstOrDefault();

            if (_idType == 1)
            {
                _typeOfAccount = "Системный администратор";
            }
            else if(_idType == 2)
            {
                _typeOfAccount = "Заказчик";
            }
            else if(_idType == 3)
            {
                _typeOfAccount = "Исполнитель";
            }

            return _typeOfAccount;
        }

        public string UserLastName(int id)
        {
            string _lastName = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.last_name)
                .FirstOrDefault();

            return _lastName;
        }

        public string UserName(int id)
        {
            string _name = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.name)
                .FirstOrDefault();

            return _name;
        }

        public string UserMiddleName(int id)
        {
            string _middleName = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.middle_name)
                .FirstOrDefault();

            return _middleName;
        }

        public string UserPosition(int id)
        {
            string _position = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.position)
                .FirstOrDefault();

            return _position;
        }

        public string UserCategoryExecutors(int id)
        {
            string _categoryExecutors = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.category_executors)
                .FirstOrDefault();

            return _categoryExecutors;
        }

        public string UserPhone(int id)
        {
            string _phone = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.phone)
                .FirstOrDefault();

            return _phone;
        }

        public List<User_DataModel> GetPeople(List<int> AllIdUsers)
        {
            List<User_DataModel> output = new List<User_DataModel>();

            foreach(var i in AllIdUsers)
            {
                output.Add(GetPerson(i));
            }

            return output;
        }

        private User_DataModel GetPerson(int id)
        {
            User_DataModel output = new User_DataModel();

            output.idUser = id;
            output.userLogin = UserLogin(id);
            output.userPassword = UserPass(id);
            output.typeOfAccount = UserTypeOfAccount(id);
            output.lastName = UserLastName(id);
            output.name = UserName(id);
            output.middleName = UserMiddleName(id);
            output.position = UserPosition(id);
            output.categoryExecutors = UserCategoryExecutors(id);
            output.phone = UserPhone(id);

            return output;
        }

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
