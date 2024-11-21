using IGTask.Core.IRepository;
using IGTask.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTask.Infra.Service
{
    public class EmployeesService:IEmployeesService
    {
        private readonly IEmployeesRepository _repository;

        public EmployeesService(IEmployeesRepository  repository)
        {
            _repository = repository;
        }
    }
}
