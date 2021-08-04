using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCatalog.API.Domain.Entities;

namespace GameCatalog.API.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : Base
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(Guid id);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> Get(int page, int amount);
        Task<bool> Exists(Guid id);
    }
}