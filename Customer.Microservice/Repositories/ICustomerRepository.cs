namespace Customers.Microservice.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Models.Customer>> GetAllAsync();
        Task<Models.Customer?> GetByIdAsync(int id);
        Task<Models.Customer> CreateAsync(Models.Customer customer);
        Task UpdateAsync(Models.Customer customer);
        Task DeleteAsync(int id);
    }
}
