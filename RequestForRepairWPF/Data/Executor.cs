using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data
{
    public class Executor
    {
        [Key]
        public int id_user { get; set; }
        public string user_login { get; set; }
        public string last_name { get; set; }
        public string name { get; set; }
        public string middle_name { get; set; }
        public string position { get; set; }
        public string phone { get; set; }
        public string category_executors { get; set; }
        public string requestID_URE { get; set; }

    }
}
