using SampleDTO.DTO.Requests;
using SampleDTO.DTO.Responses;
using SampleDTO.Entities;

namespace SampleDTO.Extenstions
{
    public static class ProductDtoExtensions
    {
        public static ProductResponse ToDto(this Product product)
        {
            return new ProductResponse(product.Id, product.Name, product.Description, product.Price, product.Quantity);
        }

        public static Product ToEntity(this CreateProductRequest productRequest)
        {
            return new Product
            {
                Name = productRequest.Name,
                Description = productRequest.Description,
                Price = productRequest.Price,
                Quantity = productRequest.Quantity,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static Product ToEntity(this UpdateProductRequest productRequest, Product existingProduct)
        {
            existingProduct.Name = productRequest.Name;
            existingProduct.Description = productRequest.Description;
            existingProduct.Price = productRequest.Price;
            existingProduct.Quantity = productRequest.Quantity;
            return existingProduct;
        }

    }
}
