using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data.Room
{
    public class U_R_Room
    {
        public static int userID_URR { get; set; }
        public static int id_room { get; set; }
        public static int id_type_room_URR { get; set; }

        public static List<int> listAll_id_room { get; set; } = new List<int>();
        public static List<int> list_user_rooms_number { get; set; } = new List<int>();
    }
}
