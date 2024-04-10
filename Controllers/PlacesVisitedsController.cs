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
    public class PlacesVisitedsController : ControllerBase
    {
        private readonly KurcachDiplomContext _context;

        public PlacesVisitedsController(KurcachDiplomContext context)
        {
            _context = context;
        }

        // GET: api/PlacesVisiteds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlacesVisited>>> GetPlacesVisiteds()
        {
          if (_context.PlacesVisiteds == null)
          {
              return NotFound();
          }
            return await _context.PlacesVisiteds.ToListAsync();
        }

        // GET: api/PlacesVisiteds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlacesVisited>> GetPlacesVisited(int? id)
        {
          if (_context.PlacesVisiteds == null)
          {
              return NotFound();
          }
            var placesVisited = await _context.PlacesVisiteds.FindAsync(id);

            if (placesVisited == null)
            {
                return NotFound();
            }

            return placesVisited;
        }

        // PUT: api/PlacesVisiteds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlacesVisited(int? id, PlacesVisited placesVisited)
        {
            if (id != placesVisited.IdPlacesVisited)
            {
                return BadRequest();
            }

            _context.Entry(placesVisited).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlacesVisitedExists(id))
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

        // POST: api/PlacesVisiteds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlacesVisited>> PostPlacesVisited(PlacesVisited placesVisited)
        {
          if (_context.PlacesVisiteds == null)
          {
              return Problem("Entity set 'KurcachDiplomContext.PlacesVisiteds'  is null.");
          }
            _context.PlacesVisiteds.Add(placesVisited);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlacesVisited", new { id = placesVisited.IdPlacesVisited }, placesVisited);
        }

        // DELETE: api/PlacesVisiteds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlacesVisited(int? id)
        {
            if (_context.PlacesVisiteds == null)
            {
                return NotFound();
            }
            var placesVisited = await _context.PlacesVisiteds.FindAsync(id);
            if (placesVisited == null)
            {
                return NotFound();
            }

            _context.PlacesVisiteds.Remove(placesVisited);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlacesVisitedExists(int? id)
        {
            return (_context.PlacesVisiteds?.Any(e => e.IdPlacesVisited == id)).GetValueOrDefault();
        }
		// GET: api/PlacesVisiteds/Search?name=...
		[HttpGet("Search")]
		public async Task<ActionResult<IEnumerable<PlacesVisited>>> SearchPlacesVisited(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				return BadRequest();
			}

			var placesVisiteds = await _context.PlacesVisiteds.Where(pv => pv.NamePlacesVisited.Contains(name)).ToListAsync();

			return placesVisiteds;
		}

		// GET: api/PlacesVisiteds/Sort?sortBy=name&sortOrder=asc
		[HttpGet("Sort")]
		public async Task<ActionResult<IEnumerable<PlacesVisited>>> SortPlacesVisited(string sortBy)
		{
			IQueryable<PlacesVisited> query = _context.PlacesVisiteds;

			// Сортировка
			if (!string.IsNullOrWhiteSpace(sortBy))
			{
				switch (sortBy.ToLower())
				{
					case "name":
						query = query.OrderBy(pv => pv.NamePlacesVisited);
						break;
						// Добавьте другие поля, по которым можно сортировать, при необходимости
				}
			}

			return await query.ToListAsync();
		}

		// GET: api/PlacesVisiteds/SortDescending?sortBy=name
		[HttpGet("SortDescending")]
		public async Task<ActionResult<IEnumerable<PlacesVisited>>> SortPlacesVisitedDescending(string sortBy)
		{
			IQueryable<PlacesVisited> query = _context.PlacesVisiteds;

			// Сортировка по убыванию
			if (!string.IsNullOrWhiteSpace(sortBy))
			{
				switch (sortBy.ToLower())
				{
					case "name":
						query = query.OrderByDescending(pv => pv.NamePlacesVisited);
						break;
						// Добавьте другие поля, по которым можно сортировать по убыванию, при необходимости
				}
			}

			return await query.ToListAsync();
		}

	}
}
