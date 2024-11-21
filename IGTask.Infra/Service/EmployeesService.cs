using IGTask.Core.Data;
using IGTask.Core.DTO;
using IGTask.Core.IRepository;
using IGTask.Core.IService;
using IGTask.Infra.Repository;
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

        public EmployeesService(IEmployeesRepository repository) 
        {
            _repository = repository;
            
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            return await _repository.AddAsync(employee);
        }



        public async Task<List<Employee>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<Employee?> GetAsync(Guid? id)
        {
          return await _repository.GetAsync(id);
        }

        public  Task<bool> Exists(Guid id)
        {
            return _repository.Exists(id);
        }
        public async Task SoftDeleteAsync(Guid id)
        {
            var employee = await _repository.GetAsync(id);
            if (employee != null && !employee.IsDeleted)
            {
                await _repository.SoftDeleteAsync(id);
            }
        }

       

        public async Task UpdateAsync(Employee employee)
        {
            await _repository.UpdateAsync(employee);

        }


    }
}
