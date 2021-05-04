using RequestForRepairWPF.Data.Room;
using RequestForRepairWPF.Data.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Models.Pages.ViewingEditDelete_UsersData
{
    public class Customers_Model
    {
        Entities.DB_RequestForRepairEntities3 context = new Entities.DB_RequestForRepairEntities3();

        public List<int> AllIdUsers
        {
            get
            {
                var query = from u in context.Users
                            where u.id_type == 2
                            select u.id_user;

                foreach (var i in query)
                    User_DataModel.AllUsersID.Add(i);

                return User_DataModel.AllUsersID;
            }
        }

        public List<User_DataModel> GetPeople(List<int> AllIdUsers)
        {
            List<User_DataModel> output = new List<User_DataModel>();

            foreach (var i in AllIdUsers)
                output.Add(GetPerson(i));

            return output;
        }

        private User_DataModel GetPerson(int id)
        {
            User_DataModel output = new User_DataModel();

            output.idUser = id;
            output.userLogin = UserLogin(id);
            output.userPassword = UserPass(id);
            output.lastName = UserLastName(id);
            output.name = UserName(id);
            output.middleName = UserMiddleName(id);
            output.position = UserPosition(id);
            output.phone = UserPhone(id);
            output.ListUserRooms = ListUserRoomsNumber(id);
            //output.ListUserActiveRequest = 

            return output;
        }

       // public List<int> ListUserActiveRequest(int id)
       // {
       //     User_DataModel output = new User_DataModel();

            //context.Users.Include(x => x.Request).Where(entry => entry.id_user == id)
            //    .Select(entry => entry.)


            //var queryRequestID = context.Users.FirstOrDefault(p => p.id_user == id);
            //
            //foreach(var c in queryRequestID)
            //{
            //
            //}

            //var query_user = context.Users
            //    .Where(u => u.id_user == id)
            //    .ToList();
            //
            //foreach(var request in query_user)
            //{
            //    var _req = request.Requests.ToList(u => u.)
            //    output.ListUserActiveRequest.Add(request.Requests.)
            //    request.Requests.
            //}

            //var queryTest = queryRequestID.Requests1.FirstOrDefault();
       // }

        public List<int> ListUserRoomsNumber(int id)
        {
            User_DataModel output = new User_DataModel();

            var queryRoomsID = from r in context.U_R_Room
                               where r.userID_URR == id
                               select r.id_room;

            foreach (var q in queryRoomsID)
            {

                var queryRoomsNumber = context.Rooms
                    .Where(c => c.id_room == q)
                    .Select(c => c.room_number)
                    .FirstOrDefault();

                output.ListUserRooms.Add(queryRoomsNumber);
            }

            return output.ListUserRooms;
        }

        private string UserLogin(int id)
        {
            string _login = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.user_login)
                .FirstOrDefault();

            return _login;
        }

        private string UserPass(int id)
        {
            string _password = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.user_password)
                .FirstOrDefault();

            return _password;
        }

        private string UserLastName(int id)
        {
            string _lastName = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.last_name)
                .FirstOrDefault();

            return _lastName;
        }

        private string UserName(int id)
        {
            string _name = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.name)
                .FirstOrDefault();

            return _name;
        }

        private string UserMiddleName(int id)
        {
            string _middleName = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.middle_name)
                .FirstOrDefault();

            return _middleName;
        }

        private string UserPosition(int id)
        {
            string _position = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.position)
                .FirstOrDefault();

            return _position;
        }

        private string UserPhone(int id)
        {
            string _phone = context.Users
                .Where(c => c.id_user == id)
                .Select(c => c.phone)
                .FirstOrDefault();

            return _phone;
        }

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
