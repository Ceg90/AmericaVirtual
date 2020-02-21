using Api.Core.Model.Data;
using Api.Core.Model.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Api.Core.Model.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetPaginatedProduct(int currentPage, int pageSize, string sortBy, SortOrder sortOrder);
    }
}
