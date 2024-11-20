using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTask.Core.Data
{
    public class IGTaskDbContext:DbContext
    {
        public IGTaskDbContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
