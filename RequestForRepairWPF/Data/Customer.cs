using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data
{
    public class Customer
    {
        //[Key]
        public int id_user { get; set; }
        public string user_login { get; set; }
        public string last_name { get; set; }
        public string name { get; set; }
        public string middle_name { get; set; }
        public string position { get; set; }
        public string phone { get; set; }
        //public string roomNUMBER_URR { get; set; }
        //public string requestID_URC { get; set; }

        public Customer(Entities.Users user)
        {
            this.id_user = user.id_user;
            this.user_login = user.user_login;
            this.last_name = user.last_name;
            this.name = user.name;
            this.middle_name = user.middle_name;
            this.position = user.position;
            this.phone = user.phone;
            
        }
        public Customer() { }
    }
}
