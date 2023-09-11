using MicroService_AsyncTasks.DBContexts;
using MicroService_AsyncTasks.Models;
using Microsoft.EntityFrameworkCore;


namespace MicroService_AsyncTasks.Repository
{
    public class ProductRepository : IProductRepository 
    {
        private  readonly IProductContext _DbContext;

        public ProductRepository(IProductContext DbContext)
        {
            _DbContext = DbContext;  
        }

        public async Task<List<Product>> GetProducts()
        {
           return  _DbContext.Products.ToList();            
        }


        public async Task<Product> GetProductsByID(int ProductId)
        {
            var Product = await _DbContext.Products.Where(product => product.Id == ProductId).FirstOrDefaultAsync();
            return Product;
        }
        public async Task<string> UpdateProduct(Product Product)
        {
            _DbContext.Products.Update(Product);
            await _DbContext.SaveChanges();
            return " Data updated Sucessfully";
        }
        public async Task<string> DeleteProduct(int ProductId)
        {
            var product = _DbContext.Products.Find(ProductId);
            _DbContext.Products.Remove(product);
            await _DbContext.SaveChanges();
            return " Deleted Sucessfully";

        }
        public async Task<string> InsertProduct(Product Product)
        {
            _DbContext.Products.Add(Product);
            await _DbContext.SaveChanges();
            return "Product Inserted Sucessfully";
        }


    }
}
