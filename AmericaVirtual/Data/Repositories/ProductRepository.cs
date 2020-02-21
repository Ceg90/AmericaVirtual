using AmericaVirtual.DataAccess;
using AmericaVirtual.Model.Entities;
using AmericaVirtual.Model.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AmericaVirtual.Data.Repositories
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
                { "@Title", entity.Title},
                { "@Description", entity.Description},
                { "@Price", entity.Price},
                { "@Images", entity.Images}
            };

            return param;
        }

        public override Dictionary<string, object> GetUpdateParams(Product entity)
        {
            var param = new Dictionary<string, object>()
            {
                { "@ProductId", entity.ProductId},
                { "@Title", entity.Title},
                { "@Description", entity.Description},
                { "@Price", entity.Price},
                { "@Images", entity.Images}
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
                { "@SortOrder", (int)sortOrder }
            };

            return DbContext.GetData("Product_GetPaginatedProducts", parameters, Mapper);
        }
    }
}
