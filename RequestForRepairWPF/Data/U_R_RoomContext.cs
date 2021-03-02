using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data
{
    public class U_R_RoomContext : DbContext
    {
        public U_R_RoomContext() : base("DefaultConnection")
        {

        }
        public DbSet<U_R_Room> U_R_Rooms { get; set; }

    }
}
