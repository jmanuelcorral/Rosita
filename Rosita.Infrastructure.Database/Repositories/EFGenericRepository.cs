using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rosita.XCutting.Maybe;

namespace Rosita.Infrastructure.Database.Repositories
{
    public class EFGenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
      where TEntity : BaseDao<TKey>
      where TKey : IEquatable<TKey>
    {
        public EFGenericRepository(DbContext context)
        {
            Context = context;
            Set = context.Set<TEntity>();
        }

        protected DbContext Context { get; }

        protected DbSet<TEntity> Set { get; }

        public virtual async Task<IList<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? page = null,
            int? pageSize = null)
        {
            IQueryable<TEntity> query = Set;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            return await query.ToListAsync();
        }


        public virtual async Task<Maybe<TEntity>> GetById(TKey id, List<Expression<Func<TEntity, object>>> includes = null)
        {
            IQueryable<TEntity> query = Set;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            var result = await query.FirstOrDefaultAsync(t => t.Id.Equals(id));
            return result.ToMaybe();
        }

        public async Task<Maybe<TEntity>> GetSingle(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes = null)
        {
            IQueryable<TEntity> query = Set;
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (filter != null)
            {
                var rtv = await query.SingleOrDefaultAsync(filter);
                return rtv.ToMaybe();
            }
            else
            {
                var rtv = await query.FirstOrDefaultAsync();
                return rtv.ToMaybe();
            }
        }

        public virtual void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public virtual async Task Remove(TKey id)
        {
            var entityToDelete = await Set.FirstOrDefaultAsync(t => t.Id.Equals(id));
            Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            Set.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Remove(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                Set.Attach(entityToDelete);
            }

            Set.Remove(entityToDelete);
        }

    }
}