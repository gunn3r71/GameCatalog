using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameCatalog.API.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> : IDisposable
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(Guid id);
        Task<IList<T>> Get(int page, int amount);
        Task<T> GetById(Guid id);
        bool Exists(Func<T, bool> filter);
        Task<int> SaveChanges();
    }
}