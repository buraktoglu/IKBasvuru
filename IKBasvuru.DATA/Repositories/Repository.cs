using IKBasvuru.COMMON.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IKBasvuru.DATA.Repositories
{
    public class Repository<TEntity, Tcontext> : IRepository<TEntity>
       where TEntity : class, IEntity, new()
       where Tcontext : DbContext, new()
    {
        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var db = new Tcontext())
            {
                return db.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var db = new Tcontext())
            {
                return await db.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var db = new Tcontext())
            {
                return await db.Set<TEntity>().FirstOrDefaultAsync(filter);
            }
        }

        public async Task<TEntity> GetLastAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var db = new Tcontext())
            {
                return await db.Set<TEntity>().LastOrDefaultAsync(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var db = new Tcontext())
            {
                return filter == null
                ? db.Set<TEntity>().ToList()
                : db.Set<TEntity>().Where(filter).ToList();
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var db = new Tcontext())
            {
                return filter == null
                ? await db.Set<TEntity>().ToListAsync()
                : await db.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public void Add(TEntity entity)
        {
            using (var context = new Tcontext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Added;
                var value = context.SaveChanges();
            }
        }

        public async Task AddAsync(TEntity entity)
        {
            using (var context = new Tcontext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Added;
                var value = await context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> MasterAddAsync(TEntity entity)
        {
            using (var context = new Tcontext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Added;
                var value = await context.SaveChangesAsync();
                return entity;
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new Tcontext())
            {
                var updated = context.Entry(entity);
                updated.State = EntityState.Modified;
                var value = context.SaveChanges();
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using (var context = new Tcontext())
            {
                var updated = context.Entry(entity);
                updated.State = EntityState.Modified;
                var value = await context.SaveChangesAsync();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new Tcontext())
            {
                var deleted = context.Entry(entity);
                deleted.State = EntityState.Deleted;
                var value = context.SaveChanges();
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (var context = new Tcontext())
            {
                var deleted = context.Entry(entity);
                deleted.State = EntityState.Deleted;
                var value = await context.SaveChangesAsync();
            }
        }

        public void SoftDelete(TEntity entity)
        {
            using (var context = new Tcontext())
            {
                entity.GetType().GetProperty("IsActive").SetValue(entity, false);
                Update(entity);
                var value = context.SaveChanges();
            }
        }

        public async Task SoftDeleteAsync(TEntity entity)
        {
            using (var context = new Tcontext())
            {
                entity.GetType().GetProperty("IsActive").SetValue(entity, false);
                await UpdateAsync(entity);
                var value = await context.SaveChangesAsync();
            }
        }
    }
}
