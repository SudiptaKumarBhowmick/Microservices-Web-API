using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Products.Microservice.DBSettings;
using Products.Microservice.Models;
using Products.Microservice.Repositories.IRepositories;

namespace Products.Microservice.Repositories.ConcreteRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _collection;

        public ProductRepository(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<Product>(settings.Value.CollectionName);
        }

        public async Task<List<Product>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<Product?> GetByIdAsync(string id) =>
            await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Product product) =>
            await _collection.InsertOneAsync(product);

        public async Task UpdateAsync(string id, Product product) =>
            await _collection.ReplaceOneAsync(p => p.Id == id, product);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(p => p.Id == id);
    }
}
