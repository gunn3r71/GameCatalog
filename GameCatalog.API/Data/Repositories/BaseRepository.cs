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
        private DbSet<T> _entity;

        protected BaseRepository(AppDbContext context)
        {
            Context = context;
            _entity = context.Set<T>();
        }

        public virtual async Task Add(T entity)
        {
            try
            {
                _entity.Add(entity);
                await SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public virtual async Task Update(T entity)
        {
            try
            {
                _entity.Update(entity);
                await SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public virtual async Task Delete(Guid id)
        {
            try
            {
                _entity.Remove(new T{Id = id});
                await SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public virtual async Task<IList<T>> Get(int page, int amount)
        {
            return await _entity.AsNoTracking().Skip((page - 1) * amount).Take(amount).ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            try
            {
                var entity = await _entity.FindAsync(id);
                
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
                return _entity.AsNoTracking().FirstOrDefault(filter) != null;
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