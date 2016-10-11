using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Rosita.XCutting.Maybe;

namespace Rosita.Infrastructure.Database.Repositories
{
    public interface IGenericRepository<TEntity, TKey>
        where TEntity : BaseDao<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<IList<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? page = null,
            int? pageSize = null);

        Task<Maybe<TEntity>> GetById(TKey id, List<Expression<Func<TEntity, object>>> includes = null);

        Task<Maybe<TEntity>> GetSingle(Expression<Func<TEntity, bool>> filter, List<Expression<Func<TEntity, object>>> includes = null);

        void Add(TEntity entity);

        Task Remove(TKey id);

        void Update(TEntity entityToUpdate);

        void Remove(TEntity entityToDelete);
    }
}