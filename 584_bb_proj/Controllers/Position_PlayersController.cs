using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _584_bb_proj.Dto;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
        [Authorize]                // require login if you want to lock this down
        public async Task<IActionResult> PutPosition_Player(int id, [FromBody] HitterUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hitter = await _context.Position_Players.FindAsync(id);
            if (hitter == null)
                return NotFound();

            // map every DTO field onto the entity:
            hitter.Name = dto.Name;
            hitter.Games_Played = dto.Games_Played;
            hitter.At_Bats = dto.At_Bats;
            hitter.Plate_Appearances = dto.Plate_Appearances;
            hitter.Hits = dto.Hits;
            hitter.Singles = dto.Singles;
            hitter.Doubles = dto.Doubles;
            hitter.Triples = dto.Triples;
            hitter.Home_Runs = dto.Home_Runs;
            hitter.Runs_Scored = dto.Runs_Scored;
            hitter.RBI = dto.RBI;
            hitter.Walks = dto.Walks;
            hitter.Intentional_Walks = dto.Intentional_Walks;
            hitter.Strikeouts = dto.Strikeouts;
            hitter.HBP = dto.HBP;
            hitter.Sac_Fly = dto.Sac_Fly;
            hitter.Sac_Hit = dto.Sac_Hit;
            hitter.GDP = dto.GDP;
            hitter.Stolen_Bases = dto.Stolen_Bases;
            hitter.Caught_Stealing = dto.Caught_Stealing;
            hitter.Batting_Average = dto.Batting_Average;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // if someone else deleted it in the meantime
                if (!_context.Position_Players.Any(e => e.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();  // 204: updated successfully
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
