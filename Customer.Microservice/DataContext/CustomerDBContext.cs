using Microsoft.EntityFrameworkCore;
using Customers.Microservice.Models;
using System;

namespace Customers.Microservice.DataContext
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options): base(options) { }

        public DbSet<Models.Customer> Customers => Set<Models.Customer>();
    }
}
