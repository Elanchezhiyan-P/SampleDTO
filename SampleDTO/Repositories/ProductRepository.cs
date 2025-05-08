using SampleDTO.Entities;

namespace SampleDTO.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products =
        [
            new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 10.0m, Quantity = 100, CreatedAt = DateTime.UtcNow },
            new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 20.0m, Quantity = 200, CreatedAt = DateTime.UtcNow },
            new Product { Id = 3, Name = "Product 3", Description = "Description 3", Price = 30.0m, Quantity = 300, CreatedAt = DateTime.UtcNow }
        ];
        public Task<List<Product>> GetAll()
        {
            return Task.FromResult(_products);
        }

        public Task<Product?> GetProductByIdAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }

        public Task CreateProductAsync(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task UpdateProductAsync(int id, Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
                existingProduct.CreatedAt = product.CreatedAt;
            }
            return Task.CompletedTask;
        }

        public Task DeleteProductAsync(int id)
        {
            var productToRemove = _products.FirstOrDefault(p => p.Id == id);
            if (productToRemove != null)
            {
                _products.Remove(productToRemove);
            }
            return Task.CompletedTask;
        }
    }
}
