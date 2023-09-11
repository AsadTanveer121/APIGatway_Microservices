using Microsoft.EntityFrameworkCore;
using MicroService_AsyncTasks.Models;

namespace MicroService_AsyncTasks.DBContexts
{
    public class ProductContext: DbContext , IProductContext
    {

        public ProductContext(DbContextOptions<ProductContext> options) : base(options) 
        {

        }   

        public DbSet<Product> Products { get; set; }

        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }


    }
}
