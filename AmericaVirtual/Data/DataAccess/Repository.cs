using AmericaVirtual.Model;
using AmericaVirtual.Data;
using System;
using System.Collections.Generic;

namespace AmericaVirtual.DataAccess
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public ISqlDataAccess DbContext { get; set; }
        public IMapper<TEntity> Mapper { get; set; }

        public Repository(ISqlDataAccess dbContext, IMapper<TEntity> mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        protected string EntityName => typeof(TEntity).Name;

        public virtual string StoredProcedureInsertName => $"{EntityName}_Insert";
        public virtual string StoredProcedureUpdateName => $"{EntityName}_Update";
        public virtual string StoredProcedureDeleteName => $"{EntityName}_Delete";
        public virtual string StoredProcedureGetByIdName => $"{EntityName}_GetById";

        public virtual object Add(TEntity entity)
        {
            return DbContext.ExecuteScalar(StoredProcedureInsertName, GetInsertParams(entity));
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            DbContext.ExecuteScalarRange(StoredProcedureInsertName, entities, this);
        }

        public virtual TEntity GetById(long id)
        {
            var param = new Dictionary<string, object>()
            {
                { "@Id", id}
            };

            return DbContext.GetSingleItem(StoredProcedureGetByIdName, param, Mapper);
        }

        public virtual void Remove(long id)
        {
            var param = new Dictionary<string, object>()
            {
                { "@Id", id}
            };

            DbContext.ExecuteScalar(StoredProcedureDeleteName, param);
        }

        public virtual void Update(TEntity entity)
        {
            DbContext.ExecuteScalar(StoredProcedureUpdateName, GetUpdateParams(entity));
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            DbContext.ExecuteScalarRange(StoredProcedureUpdateName, entities, this);
        }

        public virtual Dictionary<string, object> GetParamForRange(string storedProcedureName, TEntity entity)
        {
            if(storedProcedureName.Equals(StoredProcedureInsertName))
            {
                return GetInsertParams(entity);
            }
            else if (storedProcedureName.Equals(StoredProcedureUpdateName))
            {
                return GetUpdateParams(entity);
            }
            else
            {
                throw new ArgumentException("Stored Procedure no encontrado");
            }
        }

        public abstract Dictionary<string, object> GetInsertParams(TEntity entity);
        public abstract Dictionary<string, object> GetUpdateParams(TEntity entity);
    }
}
