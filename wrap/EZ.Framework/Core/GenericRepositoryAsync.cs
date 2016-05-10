using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EZ.Framework.Core
{
    public abstract class GenericRepositoryAsync<TEntity, TKeyType> : IRepositoryAsync<TEntity, TKeyType>
         where TEntity : class, IEntity
         where TKeyType : struct
    {
        protected readonly IUnitOfWork UnitOfWork;

        public GenericRepositoryAsync(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));

            UnitOfWork = unitOfWork;
        }

        public abstract Task<TEntity> GetByKeyAsync(TKeyType key);

        public abstract Task<IEnumerable<TEntity>> GetAll();

        public abstract Task InsertAsync(TEntity entity);

        public abstract Task UpdateAsync(TEntity entity);

        public abstract Task DeleteAsync(TKeyType key);

        //public virtual IEnumerable<TEntity> Get(
        //    Expression<Func<TEntity, bool>> filter = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //    string includeProperties = "")
        //{
        //    IQueryable<TEntity> query = dbSet;

        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    foreach (var includeProperty in includeProperties.Split
        //        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    if (orderBy != null)
        //    {
        //        return orderBy(query).ToList();
        //    }
        //    else
        //    {
        //        return query.ToList();
        //    }
        //}

    }
}
