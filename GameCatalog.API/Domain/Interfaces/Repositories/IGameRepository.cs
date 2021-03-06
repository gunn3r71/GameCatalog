using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCatalog.API.Domain.Entities;

namespace GameCatalog.API.Domain.Interfaces.Repositories
{
    public interface IGameRepository : IBaseRepository<Game>
    {
    }
}