using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatikaSurvivor.Context;
using PatikaSurvivor.Entities;
using System.Runtime.Serialization;

namespace PatikaSurvivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorsController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CompetitorsController(SurvivorDbContext context)
        {
            _context = context;
        }

        //Tüm yarışmacıları getirme
        [HttpGet]
        public IActionResult GetAll()
        {
            var competitors = _context.Competitors.ToList();
            return Ok(competitors);
        }


        //id'ye göre yarışmacı getirme
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var competitorById = _context.Competitors.FirstOrDefault(x => x.Id == id);

            if (competitorById is null)
                return NotFound();

            return Ok(competitorById);
        }

        [HttpGet("categories/{categoryId}")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            var competitors = _context.Competitors.Include(x => x.Category)
                                                  .Where(x => x.CategoryId == categoryId)
                                                  .ToList();

            if (!competitors.Any())
                return NotFound();

            return Ok(competitors);
        }

        [HttpPost]
        public IActionResult Add(CompetitorEntity competitor)
        {
            _context.Competitors.Add(competitor);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = competitor.Id }, competitor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CompetitorEntity updatedCompetitor)
        {
            var competitor = _context.Competitors.FirstOrDefault(x => x.Id == id);

            if (competitor is null)
                return NotFound();

            competitor.FirstName = updatedCompetitor.FirstName;
            competitor.LastName = updatedCompetitor.LastName;
            competitor.CategoryId = updatedCompetitor.CategoryId;
            competitor.ModifiedDate = updatedCompetitor.ModifiedDate;

            _context.SaveChanges();

            return Ok(competitor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var competitor = _context.Competitors.FirstOrDefault(x => x.Id == id);
            if (competitor is null)
                return NotFound();

            competitor.IsDeleted = true;
            _context.SaveChanges();

            return Ok(competitor);
        }

    }
}
