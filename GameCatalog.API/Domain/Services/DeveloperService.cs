using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameCatalog.API.Domain.Entities;
using GameCatalog.API.Domain.Exceptions.Developers;
using GameCatalog.API.Domain.Interfaces.Repositories;
using GameCatalog.API.Domain.Interfaces.Services;

namespace GameCatalog.API.Domain.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperService(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public async Task Add(Developer entity)
        {
            try
            {
                if (Exists(entity.Name))
                    throw new DeveloperExistsException();

                await _developerRepository.Add(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Update(Developer entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Developer> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Developer>> Get(int page, int amount)
        {
            try
            {
                var developers = await _developerRepository.Get(page, amount);

                return developers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private bool Exists(string name)
        {
            try
            {
               return  _developerRepository.Exists(x => x.Name.ToLower().Equals(name.ToLower()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose() => _developerRepository?.Dispose();
    }
}