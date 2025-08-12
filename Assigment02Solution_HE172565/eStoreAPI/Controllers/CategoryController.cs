using BusinessObject.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _repository.GetById(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            _repository.Add(category);
            return CreatedAtAction(nameof(Get), new { id = category.CategoryId }, category);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            if (id != category.CategoryId) return BadRequest();
            _repository.Update(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }

}
