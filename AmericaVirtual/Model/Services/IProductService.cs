using AmericaVirtual.Model.DTOs;
using System.Data.SqlClient;

namespace AmericaVirtual.Model.Services
{
    public interface IProductService : IBaseService
    {
        long AddProduct(ProductDto product);

        PageResult<ProductDto> GetPaginatedProducts(int currentPage, int pageSize, string sortBy, SortOrder sortOrder);

        ProductDto GetProductById(long productId);

        void RemoveProduct(long productId);

        void UpdateProduct(ProductDto product);
    }
}
