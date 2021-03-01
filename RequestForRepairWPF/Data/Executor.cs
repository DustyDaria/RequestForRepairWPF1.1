using RequestForRepairWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data
{
    public class Executor
    {
        //Executor_Model executor_ModelObj = new Executor_Model(); 

        //[Key]
        public int id_user { get; set; }
        public string user_login { get; set; }
        public string last_name { get; set; }
        public string name { get; set; }
        public string middle_name { get; set; }
        public string position { get; set; }
        public string phone { get; set; }
        public string category_executors { get; set; }
        //public int requestID_URE { get; set; }
        /*public ObservableCollection<U_R_Executor_Custom> loadRequestIDCollection
        {
            get
            {
                return loadRequestIDCollection;
            }
            set
            {
                executor_ModelObj.LoadRequestID();
            }
        }*/
        //public string criteriaSearch { get; set; }

        /*public Executor(Entities.Users user)
        {
            this.id_user = user.id_user;
            this.user_login = user.user_login;
            this.last_name = user.last_name;
            this.name = user.name;
            this.middle_name = user.middle_name;
            this.position = user.position;
            this.phone = user.phone;
            this.category_executors = user.category_executors;
            //this.requestID_URE = user.Request.First().

        }*/

        public Executor()
        {
        }
    }
}
