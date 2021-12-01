using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nomina_empleado.Models;

namespace Nomina_empleado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        private readonly Employee_ITLA_DBContext _context;

        public VacationsController(Employee_ITLA_DBContext context)
        {
            _context = context;
        }

        // GET: api/Vacations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacations>>> GetVacations()
        {
            return await _context.Vacations.ToListAsync();
        }

        // GET: api/Vacations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacations>> GetVacations(int id)
        {
            var vacations = await _context.Vacations.FindAsync(id);

            if (vacations == null)
            {
                return NotFound();
            }

            return vacations;
        }

        // PUT: api/Vacations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacations(int id, Vacations vacations)
        {
            if (id != vacations.IdVacations)
            {
                return BadRequest();
            }

            _context.Entry(vacations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacationsExists(id))
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

        // POST: api/Vacations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vacations>> PostVacations(Vacations vacations)
        {
            _context.Vacations.Add(vacations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacations", new { id = vacations.IdVacations }, vacations);
        }

        // DELETE: api/Vacations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vacations>> DeleteVacations(int id)
        {
            var vacations = await _context.Vacations.FindAsync(id);
            if (vacations == null)
            {
                return NotFound();
            }

            _context.Vacations.Remove(vacations);
            await _context.SaveChangesAsync();

            return vacations;
        }

        private bool VacationsExists(int id)
        {
            return _context.Vacations.Any(e => e.IdVacations == id);
        }
    }
}
