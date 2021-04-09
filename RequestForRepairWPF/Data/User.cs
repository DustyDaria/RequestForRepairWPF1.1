using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data
{
    public class User
    {
        public static int id_user { get; set; }
        public static string user_login { get; set; }
        public static string user_password { get; set; }
        public static string type_of_account { get; set; }
        public static string last_name { get; set; }
        public static string name { get; set; }
        public static string middle_name { get; set; }
        public static string position { get; set; }
        public static string category_executors { get; set; }
        public static string phone { get; set; }
        

    }
}
