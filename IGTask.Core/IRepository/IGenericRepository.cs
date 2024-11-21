using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTask.Core.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        //
        Task<List<T>> GetAllAsync();

        Task<T> GetAsync(int? id);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<bool> Exists(int id);


    }
}
