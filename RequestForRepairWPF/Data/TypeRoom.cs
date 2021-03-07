using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data
{
    public class TypeRoom
    {
        [Key]
        public int id_type_room_TR { get; set; } // Первичный ключ
        public string name_type_room_TR { get; set; }

        public TypeRoom() { }
    }
}
