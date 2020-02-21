using System;
using System.Data;
using Api.Core.Model;
using Api.Core.Model.Data;
using Api.Core.Extensions;

namespace Api.Data.DataAccess
{
    public class Mapper<TEntity> : IMapper<TEntity> where TEntity : BaseEntity
    {
        public TEntity Map(IDataReader dataReader)
        {
            if(dataReader == null)
            {
                throw new ArgumentNullException("La consulta no contiene datos");
            }

            var instance = Activator.CreateInstance<TEntity>();
            foreach(var property in typeof(TEntity).GetProperties())
            {
                if(dataReader.Contains(property.Name) && !dataReader.IsDBNull(property.Name))
                {
                    property.SetValue(instance, dataReader.GetValuesAsSpecificType(property.Name, property.PropertyType));
                }
            }

            return instance;
        }
    }
}
