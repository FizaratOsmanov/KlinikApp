using CORE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Repositories.Abstractions
{
    public  interface IRepository<T> where T : BaseEntity, new()
    {
        DbSet<T> Table { get; }
        Task<ICollection<T>> GetAllAsync(params string[] includes);
        Task<T?> GetByIdAsync(int id, params string[] includes);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> SaveChangesAsync();
    }
}
