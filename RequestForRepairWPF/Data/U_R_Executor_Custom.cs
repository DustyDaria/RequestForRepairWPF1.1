using RequestForRepairWPF.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data
{
    public class U_R_Executor_Custom
    {
        public int userID_URE { get; set; }
        public List<Entities.Request> Request { get; set; }
        public U_R_Executor_Custom() { }
        public U_R_Executor_Custom(Users user)
        {
            this.userID_URE = user.id_user;
            this.Request = user.Request.ToList();
        }
    }
}
