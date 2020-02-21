using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Api.Core.Model.Data;
using Api.Core.Model.Entities;
using Api.Core.Model.Repositories;
using Api.Data.DataAccess;

namespace Api.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ISqlDataAccess dbContext, IMapper<Product> mapper) : base(dbContext, mapper)
        {
        }

        public override Dictionary<string, object> GetInsertParams(Product entity)
        {
            var param = new Dictionary<string, object>()
            {

            };

            return param;
        }

        public override Dictionary<string, object> GetUpdateParams(Product entity)
        {
            var param = new Dictionary<string, object>()
            {

            };

            return param;
        }

        public IEnumerable<Product> GetPaginatedProduct(int currentPage, int pageSize, string sortBy, SortOrder sortOrder)
        {
            var parameters = new Dictionary<string, object>()
            {
                { "@Skip", (currentPage * pageSize) },
                { "@Take", pageSize },
                { "@SortBy", sortBy },
                { "@SortOrder", Convert.ToString(sortOrder) }
            };

            //param.Add("@SortOrder", Convert.ToString(sortOrder));

            return DbContext.GetData("Products_GetPaginatedProducts", parameters, Mapper);
        }
    }
}
