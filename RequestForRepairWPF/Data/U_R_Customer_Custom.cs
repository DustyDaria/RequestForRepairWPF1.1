//using RequestForRepairWPF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data
{
    class U_R_Customer_Custom
    {
        public int userID_URC { get; set; }
        //public List<Entities.Request> Request { get; set; }
        public U_R_Customer_Custom() { }
        /*public U_R_Customer_Custom(Users user)
        {
            this.userID_URC = user.id_user;
            this.Request = user.Request1.ToList();
        }*/
    }
}
