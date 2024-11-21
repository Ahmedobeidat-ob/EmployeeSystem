using IGTask.Core.Data;
using IGTask.Core.DTO;
using IGTask.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTask.Core.IService
{
    public interface IEmployeesService:IEmployeesRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee?> GetAsync(Guid? id);
        Task<Employee> AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task SoftDeleteAsync(Guid id);
        Task<bool> Exists(Guid id);
    }
}
