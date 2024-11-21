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
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IGTaskDbContext _context;

        public GenericRepository(IGTaskDbContext context)
        {
            _context = context;
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                                 .Where(e => EF.Property<bool>(e, "IsDeleted") == false)
                                 .ToListAsync();
        }






        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }





        public async Task<T> GetAsync(Guid? id)
        {
            if (id is null)
            {
                return null;
            }
            return await _context.Set<T>().FindAsync(id);
        }




        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
          
        }





        public async Task SoftDeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                if (entity is Employee employee)
                {
                    employee.IsDeleted = true;
                    employee.ModifyDate = DateTime.Now;
                    _context.Set<T>().Update(entity);
                    await _context.SaveChangesAsync();
                }
            }
        }





        public async Task<bool> Exists(Guid id)
        {

            return await _context.Set<T>().AnyAsync(e => EF.Property<Guid>(e, "EmployeeId") == id && !EF.Property<bool>(e, "IsDeleted"));

        }

    }
}
