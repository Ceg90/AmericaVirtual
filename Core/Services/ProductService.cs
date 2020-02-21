using Api.Core.Model.Data;
using Api.Core.Model.DTOs;
using Api.Core.Model.Entities;
using Api.Core.Model.Services;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Api.Core.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public long AddProduct(ProductDto product)
        {
            if(product == null)
            {
                throw new ArgumentNullException();
            }

            var productEntity = MapDtoToEntity(product);

            return Convert.ToInt64(UnitOfWork.Product.Add(productEntity));
        }

        public PageResult<ProductDto> GetPaginatedProducts(int currentPage, int pageSize, string sortBy, SortOrder sortOrder)
        {
            var result = UnitOfWork.Product.GetPaginatedProduct(currentPage, pageSize, sortBy, sortOrder).ToList();

            if (result == null || result.Count == 0)
            {
                throw new ArgumentException();
            }

            return new PageResult<ProductDto>()
            {
                Items = result.Select(product => new ProductDto(product)).ToList(),
                TotalItems = result.Count()
            };
        }

        public ProductDto GetProductById(long productId)
        {
            if (productId == 0)
            {
                throw new ArgumentNullException();
            }

            var result = UnitOfWork.Product.GetById(productId);

            if (result == null)
            {
                throw new ArgumentException();
            }

            return new ProductDto(result);
        }

        public void RemoveProduct(long productId)
        {
            if (productId == 0)
            {
                throw new ArgumentNullException();
            }

            UnitOfWork.Product.Remove(productId);
        }

        public void UpdateProduct(ProductDto product)
        {
            if (product == null)
            {
                throw new ArgumentNullException();
            }

            var productEntity = MapDtoToEntity(product);

            UnitOfWork.Product.Update(productEntity);
        }

        private Product MapDtoToEntity(ProductDto dto)
        {
            return new Product()
            {
                ProductId = dto.ProductId,
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                Images = dto.Images
            };
        }
    }
}
