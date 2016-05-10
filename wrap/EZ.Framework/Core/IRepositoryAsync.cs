using System.Collections.Generic;
using System.Threading.Tasks;

namespace EZ.Framework.Core
{
    public interface IRepositoryAsync<TEntity, in TKeyType>
        where TEntity : IEntity
        where TKeyType : struct
    {
        Task<TEntity> GetByKeyAsync(TKeyType key);

        Task<IEnumerable<TEntity>> GetAll();

        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TKeyType key);
    }
}