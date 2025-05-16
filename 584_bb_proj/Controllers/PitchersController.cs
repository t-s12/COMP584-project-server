using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _584_bb_proj.Dto;
using Humanizer;
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
        [Authorize]
        public async Task<IActionResult> PutPitcher(int id, [FromBody] PitcherUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = await _context.Pitchers.FindAsync(id);
            if (entity == null)
                return NotFound();

            // Manually map—or use AutoMapper—to apply the changes:
            entity.Name = dto.Name;
            entity.Wins = dto.Wins;
            entity.Losses = dto.Losses;
            entity.ERA = dto.ERA;
            entity.Games_Played = dto.Games_Played;
            entity.Games_Started = dto.Games_Started;
            entity.Quality_Starts = dto.Quality_Starts;
            entity.Complete_Games = dto.Complete_Games;
            entity.Shutouts = dto.Shutouts;
            entity.Saves = dto.Saves;
            entity.Holds = dto.Holds;
            entity.Blown_Saves = dto.Blown_Saves;
            entity.Innings_Pitched = dto.Innings_Pitched;
            entity.Total_Batters_Faced = dto.Total_Batters_Faced;
            entity.Hits = dto.Hits;
            entity.Runs = dto.Runs;
            entity.Earned_Runs = dto.Earned_Runs;
            entity.Home_Runs = dto.Home_Runs;
            entity.Walks = dto.Walks;
            entity.Intentional_Walks = dto.Intentional_Walks;
            entity.HBP = dto.HBP;
            entity.Wild_Pitches = dto.Wild_Pitches;
            entity.Balks = dto.Balks;
            entity.Strikeouts = dto.Strikeouts;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PitcherExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();  // 204 → updated
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
