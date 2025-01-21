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

        DbSet<T> Table {  get; }
        Task CreateAsync(T entity);
        void DeleteAsync(T entity);
        void UpdateAsync(T entity);

        Task<ICollection<T>> GetAllAsync(params string[] includes);

        Task <T?> GetByIdAsync(int Id, params string[] includes);

        Task<int> SaveAsync();

    }
}
