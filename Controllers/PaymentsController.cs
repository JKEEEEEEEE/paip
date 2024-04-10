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
    public class PaymentsController : ControllerBase
    {
        private readonly KurcachDiplomContext _context;

        public PaymentsController(KurcachDiplomContext context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
          if (_context.Payments == null)
          {
              return NotFound();
          }
            return await _context.Payments.ToListAsync();
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int? id)
        {
          if (_context.Payments == null)
          {
              return NotFound();
          }
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int? id, Payment payment)
        {
            if (id != payment.IdPayments)
            {
                return BadRequest();
            }

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
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

        // POST: api/Payments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
          if (_context.Payments == null)
          {
              return Problem("Entity set 'KurcachDiplomContext.Payments'  is null.");
          }
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayment", new { id = payment.IdPayments }, payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int? id)
        {
            if (_context.Payments == null)
            {
                return NotFound();
            }
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentExists(int? id)
        {
            return (_context.Payments?.Any(e => e.IdPayments == id)).GetValueOrDefault();
        }
		// GET: api/Payments/Search?date=...
		[HttpGet("Search")]
		public async Task<ActionResult<IEnumerable<Payment>>> SearchPayments(DateTime? date)
		{
			if (date == null)
			{
				return BadRequest();
			}

			var payments = await _context.Payments.Where(p => p.DatePayments == date).ToListAsync();

			return payments;
		}

		// GET: api/Payments/Sort?sortBy=price&sortOrder=asc
		[HttpGet("Sort")]
		public async Task<ActionResult<IEnumerable<Payment>>> SortPayments(string sortBy)
		{
			IQueryable<Payment> query = _context.Payments;

			// Сортировка
			if (!string.IsNullOrWhiteSpace(sortBy))
			{
				switch (sortBy.ToLower())
				{
					case "price":
						query =  query.OrderBy(p => p.PricePayments);
						break;
						// Добавьте другие поля, по которым можно сортировать, при необходимости
				}
			}

			return await query.ToListAsync();
		}

		// GET: api/Payments/SortDescending?sortBy=price
		[HttpGet("SortDescending")]
		public async Task<ActionResult<IEnumerable<Payment>>> SortPaymentsDescending(string sortBy)
		{
			IQueryable<Payment> query = _context.Payments;

			// Сортировка по убыванию
			if (!string.IsNullOrWhiteSpace(sortBy))
			{
				switch (sortBy.ToLower())
				{
					case "price":
						query = query.OrderByDescending(p => p.PricePayments);
						break;
						// Добавьте другие поля, по которым можно сортировать по убыванию, при необходимости
				}
			}

			return await query.ToListAsync();
		}

	}
}
