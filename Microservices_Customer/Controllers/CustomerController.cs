using Microservices_Customer.Models;
using Microservices_Customer.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservices_Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _CustomerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _CustomerRepository = customerRepository;
        }   

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Customer = await _CustomerRepository.GetCustomers();
            return Ok(Customer);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Customer = await _CustomerRepository.GetCustomerById(id);
            return Ok(Customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerDetails New_Customer)
        {
            var Customer = await _CustomerRepository.InsertCustomer(New_Customer);
            return Ok(Customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerDetails New_Customer)
        {
            if(New_Customer != null)
            {
                await _CustomerRepository.UpdateCustomer(New_Customer);
            }
            return Ok();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Customer = await _CustomerRepository.DeleteCustomer(id);
            return Ok(Customer);

        }
    }
}
