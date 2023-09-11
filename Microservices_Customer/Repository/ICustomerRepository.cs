using Microservices_Customer.Models; 

namespace Microservices_Customer.Repository

{
    public interface ICustomerRepository
    {
        Task<List<CustomerDetails>> GetCustomers();
        Task<CustomerDetails> GetCustomerById(int CustomerId);
        Task<string> DeleteCustomer(int CustomerId);
        Task<string> InsertCustomer(CustomerDetails Customer);
        Task<string> UpdateCustomer(CustomerDetails Customer);        

    }
}
