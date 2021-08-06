using GameCatalog.API.Data.Context;
using GameCatalog.API.Domain.Entities;
using GameCatalog.API.Domain.Interfaces.Repositories;

namespace GameCatalog.API.Data.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(AppDbContext context) : base(context)
        {
        }
    }
}