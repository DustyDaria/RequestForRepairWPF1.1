using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.DataGrid
{
    public class User
    {
        //[Key]
        public int id_user { get; set; }
        public string user_login { get; set; }
        public string last_name { get; set; }
        public string name { get; set; }
        public string middle_name { get; set; }
        public string position { get; set; }
        public string type_of_account { get; set; }
        public string category_executors { get; set; }
        public string phone { get; set; }
        
        public User() { }

        public User(Entities.Users user)
        {
            this.id_user = user.id_user;
            this.user_login = user.user_login;
            this.last_name = user.last_name;
            this.name = user.name;
            this.middle_name = user.middle_name;
            this.position = user.position;
            this.type_of_account = user.type_of_account;
            this.category_executors = user.category_executors;
            this.phone = user.phone;
        }

    }
}
