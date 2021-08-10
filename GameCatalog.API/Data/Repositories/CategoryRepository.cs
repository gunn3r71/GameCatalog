using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCatalog.API.Data.Context;
using GameCatalog.API.Domain.Entities;
using GameCatalog.API.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameCatalog.API.Data.Repositories
{
    class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Game>> GetGamesByCategory(Guid id)
        {
            try
            {
                var category = await Context.Categories.SingleOrDefaultAsync(x => x.Id == id);
                if (category == null) return null;

                var games = await Context.Games.Where(x => x.CategoryId == id).ToListAsync();

                return games;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}