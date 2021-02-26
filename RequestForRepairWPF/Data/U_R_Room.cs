using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data
{
    public class U_R_Room
    {
        public int userID_URR { get; set; }
        public int roomNUMBER_URR { get; set; }
        public int id_type_room_URR { get; set; }

        public U_R_Room() { }
        public U_R_Room(Entities.U_R_Room room)
        {
            this.userID_URR = room.userID_URR;
            this.roomNUMBER_URR = room.roomNUMBER_URR;
            this.id_type_room_URR = room.id_type_room_URR;
        }
    }
}
