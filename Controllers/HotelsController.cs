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
    public class HotelsController : ControllerBase
    {
        private readonly KurcachDiplomContext _context;

        public HotelsController(KurcachDiplomContext context)
        {
            _context = context;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
          if (_context.Hotels == null)
          {
              return NotFound();
          }
            return await _context.Hotels.ToListAsync();
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int? id)
        {
          if (_context.Hotels == null)
          {
              return NotFound();
          }
            var hotel = await _context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int? id, Hotel hotel)
        {
            if (id != hotel.IdHotel)
            {
                return BadRequest();
            }

            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
          if (_context.Hotels == null)
          {
              return Problem("Entity set 'KurcachDiplomContext.Hotels'  is null.");
          }
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotel", new { id = hotel.IdHotel }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int? id)
        {
            if (_context.Hotels == null)
            {
                return NotFound();
            }
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelExists(int? id)
        {
            return (_context.Hotels?.Any(e => e.IdHotel == id)).GetValueOrDefault();
        }
		// GET: api/Hotels/Search?name=...
		[HttpGet("Search")]
		public async Task<ActionResult<IEnumerable<Hotel>>> SearchHotels(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				return BadRequest();
			}

			var hotels = await _context.Hotels.Where(h => h.NameHotel.Contains(name)).ToListAsync();

			return hotels;
		}

		// GET: api/Hotels/Sort?sortBy=name&sortOrder=asc
		[HttpGet("Sort")]
		public async Task<ActionResult<IEnumerable<Hotel>>> SortHotels(string sortBy)
		{
			IQueryable<Hotel> query = _context.Hotels;

			// Сортировка
			if (!string.IsNullOrWhiteSpace(sortBy))
			{
				switch (sortBy.ToLower())
				{
					case "name":
						query = query.OrderBy(h => h.NameHotel);
						break;
						// Добавьте другие поля, по которым можно сортировать, при необходимости
				}
			}

			return await query.ToListAsync();
		}

		// GET: api/Hotels/SortDescending?sortBy=name
		[HttpGet("SortDescending")]
		public async Task<ActionResult<IEnumerable<Hotel>>> SortHotelsDescending(string sortBy)
		{
			IQueryable<Hotel> query = _context.Hotels;

			// Сортировка по убыванию
			if (!string.IsNullOrWhiteSpace(sortBy))
			{
				switch (sortBy.ToLower())
				{
					case "name":
						query = query.OrderByDescending(h => h.NameHotel);
						break;
						// Добавьте другие поля, по которым можно сортировать по убыванию, при необходимости
				}
			}

			return await query.ToListAsync();
		}

	}
}
