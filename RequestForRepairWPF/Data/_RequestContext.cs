using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Data
{
    public class _RequestContext : DbContext
    {
        public _RequestContext() : base("DefaultConnection")
        {

        }
        public DbSet<_Request> _Requests { get; set; }
    }
}
