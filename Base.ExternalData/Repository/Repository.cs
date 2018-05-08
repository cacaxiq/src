using Base.ExternalData.Context;
using Base.Shared.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Base.ExternalData.Extensions;

namespace Base.ExternalData.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BaseContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(BaseContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsyn()
        {

            return await DbSet.ToListAsync();
        }

        public virtual TEntity Get(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual async Task<TEntity> GetAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual void Add(TEntity t)
        {
            DbSet.Add(t);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> match)
        {
            return DbSet.SingleOrDefault(match);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            return await DbSet.SingleOrDefaultAsync(match);
        }

        public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
        {
            return DbSet.Where(match).ToList();
        }

        public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            return await DbSet.Where(match).ToListAsync();
        }

        public virtual void Delete(object key)
        {
            var entry = DbSet.Find(key);

            DbSet.Remove(entry);
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void Update(TEntity t)
        {
            DbSet.Update(t);
        }

        public virtual async Task<TEntity> UpdateAsyn(TEntity t, object key)
        {
            if (t == null)
                return null;
            TEntity exist = await DbSet.FindAsync(key);
            if (exist != null)
            {
                Db.Entry(exist).CurrentValues.SetValues(t);
            }
            return exist;
        }

        public int Count()
        {
            return DbSet.Count();
        }

        public async Task<int> CountAsync()
        {
            return await DbSet.CountAsync();
        }

        public virtual void Save()
        {


        }

        public async virtual Task<int> SaveAsync()
        {
            return await Db.SaveChangesAsync();
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = DbSet.Where(predicate);
            return query;
        }

        public virtual async Task<ICollection<TEntity>> FindByAsyn(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {

            IQueryable<TEntity> queryable = GetAll();
            foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<TEntity, object>(includeProperty);
            }

            return queryable;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
