using MicroService_AsyncTasks.Models;

namespace MicroService_AsyncTasks.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductsByID(int ProductId);
        Task<string> DeleteProduct(int ProductId);
        Task<string> UpdateProduct(Product Product);      
        Task<string> InsertProduct(Product Product);

    }
}
