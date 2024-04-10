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
	public class TouristRoutesController : ControllerBase
	{
		private readonly KurcachDiplomContext _context;

		public TouristRoutesController(KurcachDiplomContext context)
		{
			_context = context;
		}

		// GET: api/TouristRoutes
		[HttpGet]
		public async Task<ActionResult<IEnumerable<TouristRoute>>> GetTouristRoutes()
		{
			if (_context.TouristRoutes == null)
			{
				return NotFound();
			}
			return await _context.TouristRoutes.ToListAsync();
		}

		// GET: api/TouristRoutes/5
		[HttpGet("{id}")]
		public async Task<ActionResult<TouristRoute>> GetTouristRoute(int? id)
		{
			if (_context.TouristRoutes == null)
			{
				return NotFound();
			}
			var touristRoute = await _context.TouristRoutes.FindAsync(id);

			if (touristRoute == null)
			{
				return NotFound();
			}

			return touristRoute;
		}

		// PUT: api/TouristRoutes/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutTouristRoute(int? id, TouristRoute touristRoute)
		{
			if (id != touristRoute.IdTouristRoutes)
			{
				return BadRequest();
			}

			_context.Entry(touristRoute).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!TouristRouteExists(id))
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

		// POST: api/TouristRoutes
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<TouristRoute>> PostTouristRoute(TouristRoute touristRoute)
		{
			if (_context.TouristRoutes == null)
			{
				return Problem("Entity set 'KurcachDiplomContext.TouristRoutes'  is null.");
			}
			_context.TouristRoutes.Add(touristRoute);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetTouristRoute", new { id = touristRoute.IdTouristRoutes }, touristRoute);
		}

		// DELETE: api/TouristRoutes/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTouristRoute(int? id)
		{
			if (_context.TouristRoutes == null)
			{
				return NotFound();
			}
			var touristRoute = await _context.TouristRoutes.FindAsync(id);
			if (touristRoute == null)
			{
				return NotFound();
			}

			_context.TouristRoutes.Remove(touristRoute);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool TouristRouteExists(int? id)
		{
			return (_context.TouristRoutes?.Any(e => e.IdTouristRoutes == id)).GetValueOrDefault();
		}
		// GET: api/TouristRoutes/Search?name=...
		[HttpGet("Search")]
		public async Task<ActionResult<IEnumerable<TouristRoute>>> SearchTouristRoutes(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				return BadRequest();
			}

			var touristRoutes = await _context.TouristRoutes.Where(tr => tr.NameTouristRoutes.Contains(name)).ToListAsync();

			return touristRoutes;
		}

		// GET: api/TouristRoutes/Sort?sortBy=price&sortOrder=asc
		[HttpGet("Sort")]
		public async Task<ActionResult<IEnumerable<TouristRoute>>> SortTouristRoutes(string sortBy)
		{
			IQueryable<TouristRoute> query = _context.TouristRoutes;

			// Сортировка
			if (!string.IsNullOrWhiteSpace(sortBy) )
			{
				switch (sortBy.ToLower())
				{
					case "price":
						query = query.OrderBy(tr => tr.NameTouristRoutes);
						break;
						// Добавьте другие поля, по которым можно сортировать, при необходимости
				}
			}

			return await query.ToListAsync();
		}

		// GET: api/TouristRoutes/SortDescending?sortBy=price
		[HttpGet("SortDescending")]
		public async Task<ActionResult<IEnumerable<TouristRoute>>> SortTouristRoutesDescending(string sortBy)
		{
			IQueryable<TouristRoute> query = _context.TouristRoutes;

			// Сортировка по убыванию
			if (!string.IsNullOrWhiteSpace(sortBy))
			{
				switch (sortBy.ToLower())
				{
					case "price":
						query = query.OrderByDescending(tr => tr.NameTouristRoutes);
						break;
						// Добавьте другие поля, по которым можно сортировать по убыванию, при необходимости
				}
			}

			return await query.ToListAsync();
		}

	}
}
