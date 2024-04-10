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
	public class CountriesController : ControllerBase
	{
		private readonly KurcachDiplomContext _context;

		public CountriesController(KurcachDiplomContext context)
		{
			_context = context;
		}

		// GET: api/Countries
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
		{
			if (_context.Countries == null)
			{
				return NotFound();
			}
			return await _context.Countries.ToListAsync();
		}

		// GET: api/Countries/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Country>> GetCountry(int? id)
		{
			if (_context.Countries == null)
			{
				return NotFound();
			}
			var country = await _context.Countries.FindAsync(id);

			if (country == null)
			{
				return NotFound();
			}

			return country;
		}

		// PUT: api/Countries/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCountry(int? id, Country country)
		{
			if (id != country.IdCountry)
			{
				return BadRequest();
			}

			_context.Entry(country).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CountryExists(id))
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

		// POST: api/Countries
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Country>> PostCountry(Country country)
		{
			if (_context.Countries == null)
			{
				return Problem("Entity set 'KurcachDiplomContext.Countries'  is null.");
			}
			_context.Countries.Add(country);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetCountry", new { id = country.IdCountry }, country);
		}

		// DELETE: api/Countries/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCountry(int? id)
		{
			if (_context.Countries == null)
			{
				return NotFound();
			}
			var country = await _context.Countries.FindAsync(id);
			if (country == null)
			{
				return NotFound();
			}

			_context.Countries.Remove(country);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		// GET: api/Countries/Search?name=...
		[HttpGet("Search")]
		public async Task<ActionResult<IEnumerable<Country>>> SearchCountries(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				return BadRequest();
			}

			var countries = await _context.Countries.Where(c => c.NameCountry.Contains(name)).ToListAsync();

			return countries;
		}

		// GET: api/Countries/Sort?sortBy=name&sortOrder=asc
		[HttpGet("Sort")]
		public async Task<ActionResult<IEnumerable<Country>>> SortCountries(string sortBy, string sortOrder)
		{
			IQueryable<Country> query = _context.Countries;

			// Сортировка
			if (!string.IsNullOrWhiteSpace(sortBy))
			{
				switch (sortBy.ToLower())
				{
					case "name":
						query = query.OrderBy(c => c.NameCountry);
						break;
						// Добавьте другие поля, по которым можно сортировать, при необходимости
				}
			}

			return await query.ToListAsync();
		}

		// GET: api/Countries/SortDescending?sortBy=name
		[HttpGet("SortDescending")]
		public async Task<ActionResult<IEnumerable<Country>>> SortCountriesDescending(string sortBy)
		{
			IQueryable<Country> query = _context.Countries;

			// Сортировка по убыванию
			if (!string.IsNullOrWhiteSpace(sortBy))
			{
				switch (sortBy.ToLower())
				{
					case "name":
						query = query.OrderByDescending(c => c.NameCountry);
						break;
						// Добавьте другие поля, по которым можно сортировать по убыванию, при необходимости
				}
			}

			return await query.ToListAsync();
		}

		private bool CountryExists(int? id)
		{
			return (_context.Countries?.Any(e => e.IdCountry == id)).GetValueOrDefault();
		}
	}
}
