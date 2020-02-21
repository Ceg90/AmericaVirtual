using Api.Core.Model.Entities;
using System.ComponentModel.DataAnnotations;

namespace Api.Core.Model.DTOs
{
    public class ProductDto : BaseDto
    {
        public int MyProperty { get; set; }

        public ProductDto()
        {
        }

        public ProductDto(Product entity)
        {
            ProductId = entity.ProductId;
            Title = entity.Title;
            Description = entity.Description;
            Price = entity.Price;
            Images = entity.Images;
        }

        [Required]
        public long ProductId { get; set; }

        [Required]
        [StringLength(15)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Images { get; set; }
    }
}
