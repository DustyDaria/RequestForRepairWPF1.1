using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data.User
{
    public class User_DataModel
    {
        public static int _idUser { get; set; }
        public int idUser { get; set; }

        public static int _idType { get; set; }
        public int idType { get; set; }
        public string typeOfAccount { get; set; }

        public static string _userLogin { get; set; }
        public string userLogin { get; set; }

        public static string _userPassword { get; set; }
        public string userPassword { get; set; }

        public static string _lastName { get; set; }
        public string lastName { get; set; }

        public static string _name { get; set; }
        public string name { get; set; }

        public static string _middleName { get; set; }
        public string middleName { get; set; }

        public static string _position { get; set; }
        public string position { get; set; }

        public static string _categoryExecutors { get; set; }
        public string categoryExecutors { get; set; }

        public static string _phone { get; set; }
        public string phone { get; set; }

        public static List<string> AllCategoryExecutors { get; set; } = new List<string>();
        public static List<int> AllUsersID { get; set; } = new List<int>();
    }
}
