using Api.Core.Extensions;
using Api.Core.Model;
using Api.Core.Model.Data;
using Api.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Api.Data.DataAccess
{
    public class SqlDataAccess : DbContext, ISqlDataAccess
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbConnection Connection { get; set; }

        public SqlDataAccess(DbContextOptions<SqlDataAccess> options)
            : base(options)
        {
        }

        public DbConnection CreateSqlConnection()
        {
            var connection = Database.GetDbConnection();
            connection.Open();
            return connection;
        }

        public IDataReader ExecuteDataReader(string storedProcedureName, Dictionary<string, object> parameters)
        {
            if(string.IsNullOrEmpty(storedProcedureName))
            {
                throw new ArgumentNullException("El nombre del stored procedure es incorrecto");
            }

            using (var command = GetSqlConnection().CreateCommand())
            {
                command.ConfigureCommand(storedProcedureName);
                AddDbParametersToDbCommand(command, parameters);
                return command.ExecuteReader();
            }
        }

        public object ExecuteScalar(string storedProcedureName, Dictionary<string, object> parameters)
        {
            if (string.IsNullOrEmpty(storedProcedureName))
            {
                throw new ArgumentNullException("El nombre del stored procedure es incorrecto");
            }

            using (var command = GetSqlConnection().CreateCommand())
            {
                command.ConfigureCommand(storedProcedureName);
                AddDbParametersToDbCommand(command, parameters);
                return command.ExecuteScalar();
            }
        }

        public void ExecuteScalarRange<TEntity>(string storedProcedureName, IEnumerable<TEntity> entities, IRepository<TEntity> repository) where TEntity : BaseEntity
        {
            if (entities == null || entities.Count() == 0)
            {
                return;
            }

            if (string.IsNullOrEmpty(storedProcedureName))
            {
                throw new ArgumentNullException("El nombre del stored procedure es incorrecto");
            }

            using (var command = GetSqlConnection().CreateCommand())
            {
                command.ConfigureCommand(storedProcedureName);

                foreach (var entity in entities)
                {
                    var parameters = repository.GetParamForRange(storedProcedureName, entity);
                    AddDbParametersToDbCommand(command, parameters);
                    command.ExecuteScalar();
                }
            }
        }

        public IEnumerable<TEntity> GetData<TEntity>(string storedProcedure, Dictionary<string, object> parameters, IMapper<TEntity> mapper) where TEntity : BaseEntity
        {
            var list = new List<TEntity>();
            using (var command = GetSqlConnection().CreateCommand())
            {
                command.ConfigureCommand(storedProcedure);
                AddDbParametersToDbCommand(command, parameters);

                using (var reader = command.ExecuteReader())
                {
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            list.Add(mapper.Map(reader));
                        }
                    }
                }
            }
            return list;
        }

        public TEntity GetSingleItem<TEntity>(string storedProcedure, Dictionary<string, object> parameters, IMapper<TEntity> mapper) where TEntity : BaseEntity
        {
            using (var reader = ExecuteDataReader(storedProcedure, parameters))
            {
                if(reader != null && reader.Read())
                {
                    return mapper.Map(reader);
                }
            }

            return default(TEntity);
        }

        private void AddDbParametersToDbCommand(DbCommand command, Dictionary<string, object> parameters)
        {
            if(parameters == null || !parameters.Any())
            {
                return;
            }

            command.Parameters.Clear();
            foreach(var dbParameters in parameters.Select(param => CreateDbParameter(command, param.Key, param.Value)))
            {
                command.Parameters.Add(dbParameters);
            }
        }

        private void CloseConnection()
        {
            
        }

        private DbParameter CreateDbParameter(DbCommand command, string parameterName, object parameterValue)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue == null ? parameter.Value = DBNull.Value : parameter.Value = parameterValue;

            return parameter;
        }

        private DbConnection GetSqlConnection()
        {
            if(Connection == null)
            {
                Connection = CreateSqlConnection();
            }

            if(Connection != null && Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }

            return Connection;
        }
    }
}
