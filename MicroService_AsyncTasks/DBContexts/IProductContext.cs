using MicroService_AsyncTasks.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroService_AsyncTasks.DBContexts
{
    public interface IProductContext
    {
        DbSet<Product> Products { get; set; }
        Task<int> SaveChanges();
    }
}
