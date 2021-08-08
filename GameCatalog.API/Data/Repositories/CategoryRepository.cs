using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCatalog.API.Data.Context;
using GameCatalog.API.Domain.Entities;
using GameCatalog.API.Domain.Interfaces.Repositories;

namespace GameCatalog.API.Data.Repositories
{
    class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Game>> GetGamesByCategory(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}