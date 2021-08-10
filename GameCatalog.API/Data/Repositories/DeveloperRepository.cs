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
    public class DeveloperRepository : BaseRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Game>> GetGamesByDeveloper(Guid id)
        {
            try
            {
                var developer = await Context.Developers.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
                if (developer == null) return null;

                var games = await Context.Games.Where(x => x.DeveloperId == id).ToListAsync();
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