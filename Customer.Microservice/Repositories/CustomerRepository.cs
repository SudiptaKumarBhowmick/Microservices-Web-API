using Customers.Microservice.DataContext;
using Microsoft.EntityFrameworkCore;
using System;

namespace Customers.Microservice.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDBContext _context;

        public CustomerRepository(CustomerDBContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Customer>> GetAllAsync() =>
            await _context.Customers.ToListAsync();

        public async Task<Models.Customer?> GetByIdAsync(int id) =>
            await _context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));

        public async Task<Models.Customer> CreateAsync(Models.Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task UpdateAsync(Models.Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await GetByIdAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
