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
    public class JobHistoriesController : ControllerBase
    {
        private readonly NOMINA_DBContext _context;

        public JobHistoriesController(NOMINA_DBContext context)
        {
            _context = context;
        }

        // GET: api/JobHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobHistory>>> GetJobHistories()
        {
            return await _context.JobHistories.ToListAsync();
        }

        // GET: api/JobHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobHistory>> GetJobHistory(int id)
        {
            var jobHistory = await _context.JobHistories.FindAsync(id);

            if (jobHistory == null)
            {
                return NotFound();
            }

            return jobHistory;
        }

        // PUT: api/JobHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobHistory(int id, JobHistory jobHistory)
        {
            if (id != jobHistory.IdJobHistory)
            {
                return BadRequest();
            }

            _context.Entry(jobHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobHistoryExists(id))
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

        // POST: api/JobHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobHistory>> PostJobHistory(JobHistory jobHistory)
        {
            _context.JobHistories.Add(jobHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobHistory", new { id = jobHistory.IdJobHistory }, jobHistory);
        }

        // DELETE: api/JobHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobHistory(int id)
        {
            var jobHistory = await _context.JobHistories.FindAsync(id);
            if (jobHistory == null)
            {
                return NotFound();
            }

            _context.JobHistories.Remove(jobHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobHistoryExists(int id)
        {
            return _context.JobHistories.Any(e => e.IdJobHistory == id);
        }
    }
}
