using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kursach_diplom_api.Models;

namespace kursach_diplom_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly KurcachDiplomContext _context;

        public ToursController(KurcachDiplomContext context)
        {
            _context = context;
        }

        // GET: api/Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> GetTours()
        {
          if (_context.Tours == null)
          {
              return NotFound();
          }
            return await _context.Tours.ToListAsync();
        }

        // GET: api/Tours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tour>> GetTour(int? id)
        {
          if (_context.Tours == null)
          {
              return NotFound();
          }
            var tour = await _context.Tours.FindAsync(id);

            if (tour == null)
            {
                return NotFound();
            }

            return tour;
        }

        // PUT: api/Tours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour(int? id, Tour tour)
        {
            if (id != tour.IdTours)
            {
                return BadRequest();
            }

            _context.Entry(tour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tour>> PostTour(Tour tour)
        {
          if (_context.Tours == null)
          {
              return Problem("Entity set 'KurcachDiplomContext.Tours'  is null.");
          }
            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTour", new { id = tour.IdTours }, tour);
        }

        // DELETE: api/Tours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(int? id)
        {
            if (_context.Tours == null)
            {
                return NotFound();
            }
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }

            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TourExists(int? id)
        {
            return (_context.Tours?.Any(e => e.IdTours == id)).GetValueOrDefault();
        }


		[HttpGet("SearchByTourType")]
		public async Task<ActionResult<IEnumerable<Tour>>> SearchByTourType(string tourType)
		{
			var tours = await _context.Tours.Where(t => t.TypeTours == tourType).ToListAsync();
			if (tours == null || !tours.Any())
			{
				return NotFound();
			}
			return tours;
		}

		[HttpGet("SearchByCountryId")]
		public async Task<ActionResult<IEnumerable<Tour>>> SearchByCountryId(int countryId)
		{
			var tours = await _context.Tours.Where(t => t.CountryId == countryId).ToListAsync();
			if (tours == null || !tours.Any())
			{
				return NotFound();
			}
			return tours;
		}

		[HttpGet("SearchByCityId")]
		public async Task<ActionResult<IEnumerable<Tour>>> SearchByCityId(int cityId)
		{
			var city = await _context.Cities.FindAsync(cityId);

			if (city == null)
			{
				return NotFound();
			}

			var country = await _context.Countries.FirstOrDefaultAsync(c => c.CityId == cityId);

			if (country == null)
			{
				return NotFound();
			}

			var tours = await _context.Tours
									.Where(t => t.CountryId == country.IdCountry)
									.ToListAsync();

			if (tours == null || !tours.Any())
			{
				return NotFound();
			}

			return tours;
		}





	}
}