using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCatalog.API.Domain.Entities;
using GameCatalog.API.Domain.Interfaces.Services;

namespace GameCatalog.API.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        public async Task Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> Get(int page, int amount)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}