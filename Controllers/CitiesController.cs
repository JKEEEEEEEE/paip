using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kursach_diplom_api.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace kursach_diplom_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CitiesController : ControllerBase
	{
		private readonly KurcachDiplomContext _context;

		public CitiesController(KurcachDiplomContext context)
		{
			_context = context;
		}

		// Остальной код

		// GET: api/Cities
		[HttpGet]
		public async Task<ActionResult<IEnumerable<object>>> GetCities()
		{
			var cities = await _context.Cities
				.Join(
					_context.Hotels,
					city => city.HotelId,
					hotel => hotel.IdHotel, 
					(city, hotel) => new 
					{
						CityId = city.IdCity,
						CityName = city.NameCity, 
						HotelName = hotel.NameHotel,
					})
				.ToListAsync();

			return cities;
		}


		// GET: api/Cities/5
		[HttpGet("{id}")]
		public async Task<ActionResult<City>> GetCity(int? id)
		{
			if (_context.Cities == null)
			{
				return NotFound();
			}
			var city = await _context.Cities.FindAsync(id);

			if (city == null)
			{
				return NotFound();
			}

			return city;
		}

		// PUT: api/Cities/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCity(int? id, City city)
		{
			if (id != city.IdCity)
			{
				return BadRequest();
			}

			_context.Entry(city).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CityExists(id))
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

		// POST: api/Cities
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<City>> PostCity(City city)
		{
			if (_context.Cities == null)
			{
				return Problem("Entity set 'KurcachDiplomContext.Cities'  is null.");
			}
			_context.Cities.Add(city);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetCity", new { id = city.IdCity }, city);
		}

		// DELETE: api/Cities/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCity(int? id)
		{
			if (_context.Cities == null)
			{
				return NotFound();
			}
			var city = await _context.Cities.FindAsync(id);
			if (city == null)
			{
				return NotFound();
			}

			_context.Cities.Remove(city);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		// GET: api/Cities/Search?name=...
		[HttpGet("Search")]
		public async Task<ActionResult<IEnumerable<City>>> SearchCities(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				return BadRequest();
			}

			var cities = await _context.Cities.Where(c => c.NameCity.Contains(name)).ToListAsync();

			return cities;
		}

		// GET: api/Cities/Sort?sortBy=name&sortOrder=asc
		[HttpGet("Sort")]
		public async Task<ActionResult<IEnumerable<City>>> SortCities(string sortBy, string sortOrder)
		{
			IQueryable<City> query = _context.Cities;

			// Сортировка
			if (!string.IsNullOrWhiteSpace(sortBy))
			{
				switch (sortBy.ToLower())
				{
					case "name":
						query =  query.OrderBy(c => c.NameCity);
						break;
						// Добавьте другие поля, по которым можно сортировать, при необходимости
				}
			}

			return await query.ToListAsync();
		}

		// GET: api/Cities/SortDescending?sortBy=name
		[HttpGet("SortDescending")]
		public async Task<ActionResult<IEnumerable<City>>> SortCitiesDescending(string sortBy)
		{
			IQueryable<City> query = _context.Cities;

			// Сортировка по убыванию
			if (!string.IsNullOrWhiteSpace(sortBy))
			{
				switch (sortBy.ToLower())
				{
					case "name":
						query = query.OrderByDescending(c => c.NameCity);
						break;
						// Добавьте другие поля, по которым можно сортировать по убыванию, при необходимости
				}
			}

			return await query.ToListAsync();
		}

		private bool CityExists(int? id)
		{
			return (_context.Cities?.Any(e => e.IdCity == id)).GetValueOrDefault();
		}
	}
}
