using Microservices_Customer.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices_Customer.DbContexts
{
    public interface ICustomerContex
    {
        DbSet<CustomerDetails> Details { get; set; }
        Task<int> SaveChanges();
    }
}
