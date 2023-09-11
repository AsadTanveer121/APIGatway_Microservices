using Microsoft.EntityFrameworkCore;
using Microservices_Customer.Models;

namespace Microservices_Customer.DbContexts
{
    public class CustomerContext: DbContext , ICustomerContex
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        }
   
        public DbSet<CustomerDetails> Details { get; set; }

        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }


    }

}
