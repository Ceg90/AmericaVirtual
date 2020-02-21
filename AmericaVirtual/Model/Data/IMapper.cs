using AmericaVirtual.Model;
using System.Data;

namespace AmericaVirtual.Data
{
    public interface IMapper<TEntity> where TEntity : BaseEntity
    {
        TEntity Map(IDataReader dataReader);
    }
}
