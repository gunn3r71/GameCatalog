using System;
using System.Threading.Tasks;
using GameCatalog.API.Domain.Entities;

namespace GameCatalog.API.Domain.Interfaces.Services
{
    public interface IGameService : IBaseService<Game>
    {
        Task UpdatePrice(Guid id, double price);
        Task UpdateTitle(Guid id, string title);
    }
}