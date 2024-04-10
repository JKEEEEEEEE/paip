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
    public class ProgsController : ControllerBase
    {
        private readonly KurcachDiplomContext _context;

        public ProgsController(KurcachDiplomContext context)
        {
            _context = context;
        }

        // GET: api/Progs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prog>>> GetPrograms()
        {
          if (_context.Progrs == null)
          {
              return NotFound();
          }
            return await _context.Progrs.ToListAsync();
        }

        // GET: api/Progs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prog>> GetProg(int? id)
        {
          if (_context.Progrs == null)
          {
              return NotFound();
          }
            var prog = await _context.Progrs.FindAsync(id);

            if (prog == null)
            {
                return NotFound();
            }

            return prog;
        }

        // PUT: api/Progs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProg(int? id, Prog prog)
        {
            if (id != prog.IdProg)
            {
                return BadRequest();
            }

            _context.Entry(prog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgExists(id))
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

        // POST: api/Progs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prog>> PostProg(Prog prog)
        {
          if (_context.Progrs == null)
          {
              return Problem("Entity set 'KurcachDiplomContext.Programs'  is null.");
          }
            _context.Progrs.Add(prog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProg", new { id = prog.IdProg }, prog);
        }

        // DELETE: api/Progs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProg(int? id)
        {
            if (_context.Progrs == null)
            {
                return NotFound();
            }
            var prog = await _context.Progrs.FindAsync(id);
            if (prog == null)
            {
                return NotFound();
            }

            _context.Progrs.Remove(prog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgExists(int? id)
        {
            return (_context.Progrs?.Any(e => e.IdProg == id)).GetValueOrDefault();
        }
    }
}
