using MicroService_AsyncTasks.Models;
using MicroService_AsyncTasks.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroService_AsyncTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productsRepository;

        public ProductController(IProductRepository repository)
        {
            _productsRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productsRepository.GetProducts();
            return new OkObjectResult(products);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task <IActionResult> Get(int id)
        {
            var product = await _productsRepository.GetProductsByID(id);
            return new OkObjectResult(product);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
          
                await _productsRepository.InsertProduct(product);               
                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            if (product != null)
            {
                    await _productsRepository.UpdateProduct(product);
            }
            return new OkResult();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productsRepository.DeleteProduct(id);
            return new OkResult();
        }


    }
}
