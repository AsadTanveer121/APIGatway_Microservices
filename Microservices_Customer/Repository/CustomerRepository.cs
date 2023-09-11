using Microservices_Customer.Models;
using Microservices_Customer.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Microservices_Customer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ICustomerContex _CustomerContext;

        public CustomerRepository(ICustomerContex customerContext)
        {
            _CustomerContext = customerContext;
        }
 

        public async Task<List<CustomerDetails>> GetCustomers()
        {
           return  _CustomerContext.Details.ToList();
        }
        public async Task<CustomerDetails> GetCustomerById(int CustomerId)
        {
            var Customer = _CustomerContext.Details.Find(CustomerId);
            return Customer;
        }
        public async Task<string> DeleteCustomer(int CustomerId)
        {
            var Customer = _CustomerContext.Details.Find(CustomerId);
            _CustomerContext.Details.Remove(Customer);
            await _CustomerContext.SaveChanges();
            return "Customer Deleted sucessfully";
            
        }
        public async Task<string> InsertCustomer(CustomerDetails Customer)
        {
            _CustomerContext.Details.Add(Customer);
            await _CustomerContext.SaveChanges();
            return "Customer Inserted Sucessfully";
        }
        public async Task<string> UpdateCustomer(CustomerDetails Customer)
        {
            _CustomerContext.Details.Update(Customer);
            await _CustomerContext.SaveChanges();
            return "Customer Updated Sucessfully";
        }


    }
}
