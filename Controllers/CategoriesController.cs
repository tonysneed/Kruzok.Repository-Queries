using System.Collections.Generic;
using System.Threading.Tasks;
using HelloWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWebApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private ICategoriesRepository _repo;
        public CategoriesController(ICategoriesRepository repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _repo.GetCategories();
            return Ok(categories);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _repo.GetCategory(id);
            return Ok(category);
        }
    }
}
