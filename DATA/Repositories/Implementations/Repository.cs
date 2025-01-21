using CORE.Models;
using DATA.Contexts;
using DATA.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task CreateAsync(T entity)
        {
            entity.CreatedDate = DateTime.UtcNow.AddHours(4);
           await Table.AddAsync(entity);
        }

        public void DeleteAsync(T entity)
        {
            entity.DeletedDate = DateTime.UtcNow.AddHours(4);
        }

        public async Task<ICollection<T>> GetAllAsync(params string[] includes)
        {
            IQueryable<T> query = Table;

            if (includes.Length > 0)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public  async Task<T?> GetByIdAsync(int Id, params string[] includes)
        {
            IQueryable<T> query = Table;

            if (includes.Length > 0)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await Table.SingleOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync(); 
        }

        public void UpdateAsync(T entity)
        {
            entity.UpdatedDate = DateTime.UtcNow.AddHours(4);
            Table.Update(entity);
        }
    }
}
