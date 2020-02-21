using AmericaVirtual.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace AmericaVirtual.Data
{
    public interface ISqlDataAccess
    {
        DbConnection CreateSqlConnection();

        IDataReader ExecuteDataReader(string storedProcedureName, Dictionary<string, object> parameters);

        object ExecuteScalar(string storedProcedureName, Dictionary<string, object> parameters);

        void ExecuteScalarRange<TEntity>(string storedProcedureName, IEnumerable<TEntity> entities, IRepository<TEntity> repository) where TEntity : BaseEntity;

        IEnumerable<TEntity> GetData<TEntity>(string storedProcedure, Dictionary<string, object> parameters, IMapper<TEntity> mapper) where TEntity : BaseEntity;

        TEntity GetSingleItem<TEntity>(string storedProcedure, Dictionary<string, object> parameters, IMapper<TEntity> mapper) where TEntity : BaseEntity;
    }
}
