using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projModel;

namespace _584_bb_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PitchersController : ControllerBase
    {
        private readonly BaseballContext _context;

        public PitchersController(BaseballContext context)
        {
            _context = context;
        }

        // GET: api/Pitchers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pitcher>>> GetPitchers()
        {
            return await _context.Pitchers.ToListAsync();
        }

        // GET: api/Pitchers/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Pitcher>> GetPitcher(int id)
        {
            var pitcher = await _context.Pitchers.FindAsync(id);

            if (pitcher == null)
            {
                return NotFound();
            }

            return pitcher;
        }

        // PUT: api/Pitchers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPitcher(int id, Pitcher pitcher)
        {
            if (id != pitcher.Id)
            {
                return BadRequest();
            }

            _context.Entry(pitcher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PitcherExists(id))
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

        // POST: api/Pitchers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pitcher>> PostPitcher(Pitcher pitcher)
        {
            _context.Pitchers.Add(pitcher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPitcher", new { id = pitcher.Id }, pitcher);
        }

        // DELETE: api/Pitchers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePitcher(int id)
        {
            var pitcher = await _context.Pitchers.FindAsync(id);
            if (pitcher == null)
            {
                return NotFound();
            }

            _context.Pitchers.Remove(pitcher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PitcherExists(int id)
        {
            return _context.Pitchers.Any(e => e.Id == id);
        }
    }
}
