using SampleDTO.Entities;

namespace SampleDTO.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product?> GetProductByIdAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(int id, Product product);
        Task DeleteProductAsync(int id);
    }
}
