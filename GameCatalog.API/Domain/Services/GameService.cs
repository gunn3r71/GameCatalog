using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCatalog.API.Domain.Entities;
using GameCatalog.API.Domain.Exceptions;
using GameCatalog.API.Domain.Exceptions.Games;
using GameCatalog.API.Domain.Interfaces.Repositories;
using GameCatalog.API.Domain.Interfaces.Services;

namespace GameCatalog.API.Domain.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task Add(Game entity)
        {
            try
            {
                var exists = Exists(e => e.Title == entity.Title && e.Developer == entity.Developer);
                if (exists)
                    throw new GameExistsException();

                await _gameRepository.Add(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Update(Game entity)
        {
            try
            {
                var game = await _gameRepository.GetById(entity.Id);

                if (game == null)
                    throw new GameNotExistsException();

                game.Developer = entity.Developer;
                game.Price = entity.Price;
                game.Title = entity.Title;

                await _gameRepository.Update(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task UpdatePrice(Guid id, double price)
        {
            try
            {
                var game = await _gameRepository.GetById(id);
                if (game == null)
                    throw new GameNotExistsException();

                game.Price = price;

                await _gameRepository.Update(game);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task UpdateTitle(Guid id, string title)
        {
            try
            {
                var game = await _gameRepository.GetById(id);
                if (game == null)
                    throw new GameNotExistsException();

                game.Title = title;

                await _gameRepository.Update(game);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<Game>> GetGamesByCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Game>> GetGamesByDeveloper(Guid developerId)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var gameExists = Exists(x => x.Id == id);
                if (!gameExists)
                    throw new GameNotExistsException();

                await _gameRepository.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Game> GetById(Guid id)
        {
            try
            {
                var game = await _gameRepository.GetById(id);

                if (game == null)
                    throw new GameNotExistsException();

                return game;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<Game>> Get(int page, int amount)
        {
            try
            {
                var gameList = await _gameRepository.Get(page, amount);

                return gameList.OrderBy(x => x.Title);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private bool Exists(Func<Game, bool> predicate)
        {
            try
            {
                var game =  _gameRepository.Exists(predicate);
                return game;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose() => _gameRepository?.Dispose();
    }
}