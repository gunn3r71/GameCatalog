using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCatalog.API.Domain.Entities;
using GameCatalog.API.Domain.Interfaces.Services;

namespace GameCatalog.API.Domain.Services
{
    public class DeveloperService : IDeveloperService
    {
        public async Task Add(Developer entity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}