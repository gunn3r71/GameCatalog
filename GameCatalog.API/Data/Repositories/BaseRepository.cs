using GameCatalog.API.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCatalog.API.Data.Context;
using GameCatalog.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameCatalog.API.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Base, new()
    {
        protected readonly AppDbContext Context;
        private DbSet<T> Entity { get; set; }

        protected BaseRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task Add(T entity)
        {
            try
            {
                Entity.Add(entity);
                await SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Update(T entity)
        {
            try
            {
                Entity.Update(entity);
                await SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public async Task Delete(Guid id)
        {
            try
            {
                var entity = await Entity.FindAsync(id);
                Entity.Remove(entity);

                await SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IList<T>> Get(int page, int amount)
        {
            return await Entity.AsNoTracking().Skip((page - 1) * amount).Take(amount).ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            try
            {
                var entity = await Entity.FindAsync(id);
                
                if (entity == null)
                    return null;

                return entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool Exists(Func<T, bool> filter)
        {
            try
            {
                return Entity.AsNoTracking().FirstOrDefault(filter) != null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}