using Customers.Microservice.Repositories;

namespace Customers.Microservice.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<List<Models.Customer>> GetAllAsync() => _customerRepository.GetAllAsync();
        public Task<Models.Customer?> GetByIdAsync(int id) => _customerRepository.GetByIdAsync(id);
        public Task CreateAsync(Models.Customer customer) => _customerRepository.CreateAsync(customer);
        public Task UpdateAsync(Models.Customer customer) => _customerRepository.UpdateAsync(customer);
        public Task DeleteAsync(int id) => _customerRepository.DeleteAsync(id);
    }
}
