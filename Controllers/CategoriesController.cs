using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatikaSurvivor.Context;
using PatikaSurvivor.Entities;

namespace PatikaSurvivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CategoriesController(SurvivorDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {

            var categories = _context.Categories.ToList();

            return Ok(categories);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category= _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category is null) 
                return NotFound();  

            return Ok(category);    
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryEntity category)
        {
            if(category == null)
                return BadRequest();

            _context.Categories.Add(category);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new {id = category.Id}, category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CategoryEntity updatedCategory)
        {
            var category=_context.Categories.FirstOrDefault(x => x.Id == id);

            if(category is null)
                return NotFound();

            category.Name = updatedCategory.Name;

            _context.SaveChanges();

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category=_context.Categories.FirstOrDefault(x=>x.Id == id); 

            if(category is null)
                return NotFound();

            category.IsDeleted = true;

            _context.SaveChanges();

            return Ok(category);

           
        }
    }
}
