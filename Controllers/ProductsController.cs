using System.Collections.Generic;
using System.Threading.Tasks;
using HelloWebApi.Models;
using HelloWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private IProductsRepository _repo;
        public ProductsController(IProductsRepository repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _repo.GetProducts();
            return Ok(products);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _repo.GetProduct(id);
            return Ok(product);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Product product)
        {
            await _repo.Insert(product);
            return CreatedAtAction("Get", new{id = product.ProductId}, product);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Product product)
        {
            await _repo.Update(product);
            return Ok(product);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.Delete(id);
            return NoContent();
        }
    }
}
