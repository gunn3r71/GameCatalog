using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCatalog.API.Domain.Entities;

namespace GameCatalog.API.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<IEnumerable<Game>> GetGamesByCategory(Guid id);
    }
}