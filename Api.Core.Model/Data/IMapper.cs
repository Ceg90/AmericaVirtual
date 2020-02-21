using System.Data;

namespace Api.Core.Model.Data
{
    public interface IMapper<TEntity> where TEntity : BaseEntity
    {
        TEntity Map(IDataReader dataReader);
    }
}
