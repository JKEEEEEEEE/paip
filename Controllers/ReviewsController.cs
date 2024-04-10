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
    public class ReviewsController : ControllerBase
    {
        private readonly KurcachDiplomContext _context;

        public ReviewsController(KurcachDiplomContext context)
        {
            _context = context;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
          if (_context.Reviews == null)
          {
              return NotFound();
          }
            return await _context.Reviews.ToListAsync();
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int? id)
        {
          if (_context.Reviews == null)
          {
              return NotFound();
          }
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // PUT: api/Reviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int? id, Review review)
        {
            if (id != review.IdReviews)
            {
                return BadRequest();
            }

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/Reviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
          if (_context.Reviews == null)
          {
              return Problem("Entity set 'KurcachDiplomContext.Reviews'  is null.");
          }
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = review.IdReviews }, review);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int? id)
        {
            if (_context.Reviews == null)
            {
                return NotFound();
            }
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReviewExists(int? id)
        {
            return (_context.Reviews?.Any(e => e.IdReviews == id)).GetValueOrDefault();
        }
		// GET: api/Reviews/Search?evaluation=...
		[HttpGet("Search")]
		public async Task<ActionResult<IEnumerable<Review>>> SearchReviews(int evaluation)
		{
			var reviews = await _context.Reviews.Where(r => r.EvaluationReviews == evaluation).ToListAsync();

			return reviews;
		}

		// GET: api/Reviews/Sort?sortBy=evaluation&sortOrder=asc
		[HttpGet("Sort")]
		public async Task<ActionResult<IEnumerable<Review>>> SortReviews(string sortBy)
		{
			IQueryable<Review> query = _context.Reviews;

			// Сортировка
			if (!string.IsNullOrWhiteSpace(sortBy))
			{
				switch (sortBy.ToLower())
				{
					case "evaluation":
						query = query.OrderBy(r => r.EvaluationReviews);
						break;
						// Добавьте другие поля, по которым можно сортировать, при необходимости
				}
			}

			return await query.ToListAsync();
		}

		// GET: api/Reviews/SortDescending?sortBy=evaluation
		[HttpGet("SortDescending")]
		public async Task<ActionResult<IEnumerable<Review>>> SortReviewsDescending(string sortBy)
		{
			IQueryable<Review> query = _context.Reviews;

			// Сортировка по убыванию
			if (!string.IsNullOrWhiteSpace(sortBy))
			{
				switch (sortBy.ToLower())
				{
					case "evaluation":
						query = query.OrderByDescending(r => r.EvaluationReviews);
						break;
						// Добавьте другие поля, по которым можно сортировать по убыванию, при необходимости
				}
			}

			return await query.ToListAsync();
		}

	}
}
