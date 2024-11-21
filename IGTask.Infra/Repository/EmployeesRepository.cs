using IGTask.Core.Data;
using IGTask.Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTask.Infra.Repository
{
    public class EmployeesRepository:GenericRepository<Employee>, IEmployeesRepository
    {
        private readonly IGTaskDbContext _context;

        public EmployeesRepository(IGTaskDbContext context):base(context)
        {
            _context = context;
        }

      

    }
}
