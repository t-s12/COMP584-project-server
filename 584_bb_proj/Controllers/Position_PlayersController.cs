using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projModel;

namespace _584_bb_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Position_PlayersController : ControllerBase
    {
        private readonly BaseballContext _context;

        public Position_PlayersController(BaseballContext context)
        {
            _context = context;
        }

        // GET: api/Position_Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position_Player>>> GetPosition_Players()
        {
            return await _context.Position_Players.ToListAsync();
        }

        // GET: api/Position_Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Position_Player>> GetPosition_Player(int id)
        {
            var position_Player = await _context.Position_Players.FindAsync(id);

            if (position_Player == null)
            {
                return NotFound();
            }

            return position_Player;
        }

        // PUT: api/Position_Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosition_Player(int id, Position_Player position_Player)
        {
            if (id != position_Player.Id)
            {
                return BadRequest();
            }

            _context.Entry(position_Player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Position_PlayerExists(id))
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

        // POST: api/Position_Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Position_Player>> PostPosition_Player(Position_Player position_Player)
        {
            _context.Position_Players.Add(position_Player);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosition_Player", new { id = position_Player.Id }, position_Player);
        }

        // DELETE: api/Position_Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition_Player(int id)
        {
            var position_Player = await _context.Position_Players.FindAsync(id);
            if (position_Player == null)
            {
                return NotFound();
            }

            _context.Position_Players.Remove(position_Player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Position_PlayerExists(int id)
        {
            return _context.Position_Players.Any(e => e.Id == id);
        }
    }
}
