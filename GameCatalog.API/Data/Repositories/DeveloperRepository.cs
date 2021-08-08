using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCatalog.API.Data.Context;
using GameCatalog.API.Domain.Entities;
using GameCatalog.API.Domain.Interfaces.Repositories;

namespace GameCatalog.API.Data.Repositories
{
    public class DeveloperRepository : BaseRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Game>> GetGamesByDeveloper(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}