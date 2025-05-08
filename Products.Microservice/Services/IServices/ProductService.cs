using Products.Microservice.Models;
using Products.Microservice.Repositories.IRepositories;

namespace Products.Microservice.Services.IServices
{
    public class ProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Product>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Product?> GetByIdAsync(string id) => _repo.GetByIdAsync(id);
        public Task CreateAsync(Product product) => _repo.CreateAsync(product);
        public Task UpdateAsync(string id, Product product) => _repo.UpdateAsync(id, product);
        public Task DeleteAsync(string id) => _repo.DeleteAsync(id);
    }
}
