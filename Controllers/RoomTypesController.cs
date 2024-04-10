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
    public class RoomTypesController : ControllerBase
    {
        private readonly KurcachDiplomContext _context;

        public RoomTypesController(KurcachDiplomContext context)
        {
            _context = context;
        }

        // GET: api/RoomTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomType>>> GetRoomTypes()
        {
          if (_context.RoomTypes == null)
          {
              return NotFound();
          }
            return await _context.RoomTypes.ToListAsync();
        }

        // GET: api/RoomTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomType>> GetRoomType(int? id)
        {
          if (_context.RoomTypes == null)
          {
              return NotFound();
          }
            var roomType = await _context.RoomTypes.FindAsync(id);

            if (roomType == null)
            {
                return NotFound();
            }

            return roomType;
        }

        // PUT: api/RoomTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomType(int? id, RoomType roomType)
        {
            if (id != roomType.IdRoomType)
            {
                return BadRequest();
            }

            _context.Entry(roomType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomTypeExists(id))
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

        // POST: api/RoomTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomType>> PostRoomType(RoomType roomType)
        {
          if (_context.RoomTypes == null)
          {
              return Problem("Entity set 'KurcachDiplomContext.RoomTypes'  is null.");
          }
            _context.RoomTypes.Add(roomType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomType", new { id = roomType.IdRoomType }, roomType);
        }

        // DELETE: api/RoomTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomType(int? id)
        {
            if (_context.RoomTypes == null)
            {
                return NotFound();
            }
            var roomType = await _context.RoomTypes.FindAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }

            _context.RoomTypes.Remove(roomType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomTypeExists(int? id)
        {
            return (_context.RoomTypes?.Any(e => e.IdRoomType == id)).GetValueOrDefault();
        }
		// GET: api/RoomTypes/Search?name=...
		[HttpGet("Search")]
		public async Task<ActionResult<IEnumerable<RoomType>>> SearchRoomTypes(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				return BadRequest();
			}

			var roomTypes = await _context.RoomTypes.Where(rt => rt.NameRoomType.Contains(name)).ToListAsync();

			return roomTypes;
		}

		// GET: api/RoomTypes/Sort?sortBy=price&sortOrder=asc
		[HttpGet("Sort")]
		public async Task<ActionResult<IEnumerable<RoomType>>> SortRoomTypes(string sortBy)
		{
			IQueryable<RoomType> query = _context.RoomTypes;

			// Сортировка
			if (!string.IsNullOrWhiteSpace(sortBy))
			{
				switch (sortBy.ToLower())
				{
					case "price":
						query = query.OrderBy(rt => rt.PriceRoomType);
						break;
						// Добавьте другие поля, по которым можно сортировать, при необходимости
				}
			}

			return await query.ToListAsync();
		}

		// GET: api/RoomTypes/SortDescending?sortBy=price
		[HttpGet("SortDescending")]
		public async Task<ActionResult<IEnumerable<RoomType>>> SortRoomTypesDescending(string sortBy)
		{
			IQueryable<RoomType> query = _context.RoomTypes;

			// Сортировка по убыванию
			if (!string.IsNullOrWhiteSpace(sortBy))
			{
				switch (sortBy.ToLower())
				{
					case "price":
						query = query.OrderByDescending(rt => rt.PriceRoomType);
						break;
						// Добавьте другие поля, по которым можно сортировать по убыванию, при необходимости
				}
			}

			return await query.ToListAsync();
		}

	}
}
