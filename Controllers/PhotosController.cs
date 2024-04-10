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
    public class PhotosController : ControllerBase
    {
        private readonly KurcachDiplomContext _context;

        public PhotosController(KurcachDiplomContext context)
        {
            _context = context;
        }

        // GET: api/Photos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Photo>>> GetPhotos()
        {
          if (_context.Photos == null)
          {
              return NotFound();
          }
            return await _context.Photos.ToListAsync();
        }

        // GET: api/Photos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Photo>> GetPhoto(int? id)
        {
          if (_context.Photos == null)
          {
              return NotFound();
          }
            var photo = await _context.Photos.FindAsync(id);

            if (photo == null)
            {
                return NotFound();
            }

            return photo;
        }

        // PUT: api/Photos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoto(int? id, Photo photo)
        {
            if (id != photo.IdPhoto)
            {
                return BadRequest();
            }

            _context.Entry(photo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoExists(id))
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

        // POST: api/Photos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Photo>> PostPhoto(Photo photo)
        {
          if (_context.Photos == null)
          {
              return Problem("Entity set 'KurcachDiplomContext.Photos'  is null.");
          }
            _context.Photos.Add(photo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhoto", new { id = photo.IdPhoto }, photo);
        }

        // DELETE: api/Photos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(int? id)
        {
            if (_context.Photos == null)
            {
                return NotFound();
            }
            var photo = await _context.Photos.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }

            _context.Photos.Remove(photo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotoExists(int? id)
        {
            return (_context.Photos?.Any(e => e.IdPhoto == id)).GetValueOrDefault();
        }
		// GET: api/Photos/Search?name=...
		[HttpGet("Search")]
		public async Task<ActionResult<IEnumerable<Photo>>> SearchPhotos(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				return BadRequest();
			}

			var photos = await _context.Photos.Where(p => p.NamePhoto.Contains(name)).ToListAsync();

			return photos;
		}

		// GET: api/Photos/Sort?sortBy=name&sortOrder=asc
		[HttpGet("Sort")]
		public async Task<ActionResult<IEnumerable<Photo>>> SortPhotos(string sortBy)
		{
			IQueryable<Photo> query = _context.Photos;

			// Сортировка
			if (!string.IsNullOrWhiteSpace(sortBy) )
			{
				switch (sortBy.ToLower())
				{
					case "name":
						query = query.OrderBy(p => p.NamePhoto);
						break;
						// Добавьте другие поля, по которым можно сортировать, при необходимости
				}
			}

			return await query.ToListAsync();
		}

		// GET: api/Photos/SortDescending?sortBy=name
		[HttpGet("SortDescending")]
		public async Task<ActionResult<IEnumerable<Photo>>> SortPhotosDescending(string sortBy)
		{
			IQueryable<Photo> query = _context.Photos;

			// Сортировка по убыванию
			if (!string.IsNullOrWhiteSpace(sortBy))
			{
				switch (sortBy.ToLower())
				{
					case "name":
						query = query.OrderByDescending(p => p.NamePhoto);
						break;
						// Добавьте другие поля, по которым можно сортировать по убыванию, при необходимости
				}
			}

			return await query.ToListAsync();
		}

	}
}
