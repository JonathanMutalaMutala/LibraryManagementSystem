using LibraryManagementSystem.Application.Contracts.Persistence;
using LibraryManagementSystem.Domain.Common;
using LibraryManagementSystem.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        protected readonly LibraryManagementSystemDbContext _context;

        public GenericRepository(LibraryManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
           await _context.AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
             var currentValue =  await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

            currentValue.IsActive = false;

            _context.Update(currentValue);
            await _context.SaveChangesAsync();

        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
           return await _context.Set<T>().AsNoTracking().Where(x => x.IsActive).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(b => b.Id == id && b.IsActive);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
