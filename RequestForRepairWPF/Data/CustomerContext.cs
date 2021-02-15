using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("DefaultConnection")
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
