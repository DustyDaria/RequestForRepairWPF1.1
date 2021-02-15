using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data
{
    public class ExecutorContext : DbContext
    {
        public ExecutorContext() : base("DefaultConnection")
        {

        }
        public DbSet<Executor> Executors { get; set; }
    }
}
