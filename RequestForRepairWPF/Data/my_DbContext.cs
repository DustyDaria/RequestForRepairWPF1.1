using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data
{
    public class my_DbContext : DbContext
    {
        public my_DbContext() : base("DefaultConnection")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
        //public DbSet<U_R_Room> U_R_Rooms { get; set; }
       //public DbSet<U_R_Executor_Custom> U_R_Executor_Customs { get; set; }
    }
}
