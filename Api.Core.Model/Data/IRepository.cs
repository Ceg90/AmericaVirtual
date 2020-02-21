using System.Collections.Generic;

namespace Api.Core.Model.Data
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        object Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entity);

        TEntity GetById(long id);

        Dictionary<string, object> GetParamForRange(string storedProcedureName, TEntity entity);

        void Remove(long id);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);
    }
}
