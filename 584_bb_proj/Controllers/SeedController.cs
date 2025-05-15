using System;
using System.Diagnostics.Metrics;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projModel;
using _584_bb_proj.Data;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace _584_bb_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController(BaseballContext context, 
        IHostEnvironment environment,
        UserManager<BaseballTeamsUser> userManager) : ControllerBase
    {
        string _pitcherPathName = Path.Combine(environment.ContentRootPath, "Data/pitcher_stats.csv");
        string _hitterPathName = Path.Combine(environment.ContentRootPath, "Data/hitter_stats.csv");

        [HttpPost("Users")]
        public async Task ImportUsersAsync()
        {

            BaseballTeamsUser user = new()
            {
                UserName = "user",
                Email = "user@gmail.com",
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            IdentityResult x = await userManager.CreateAsync(user, "Passw0rd!");

            int y = await context.SaveChangesAsync();

        }

        [HttpPost("Pitchers")]
        public async Task<ActionResult> ImportPitchersAsync()
        {
            var divisions = await context.Divisions
                .ToDictionaryAsync(d => d.Name, StringComparer.OrdinalIgnoreCase);
            var teams = await context.Teams
                .ToDictionaryAsync(t => t.Name, StringComparer.OrdinalIgnoreCase);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null
            };

            int imported = 0;
            using var reader = new StreamReader(_pitcherPathName);
            using var csv = new CsvReader(reader, config);
            var records = csv.GetRecords<PitcherDto>();

            foreach (var record in records)
            {
                
                if (!divisions.TryGetValue(record.division, out var division))
                {
                    division = new Division { Name = record.division };
                    context.Divisions.Add(division);
                    divisions.Add(division.Name, division);
                }

                if (!teams.TryGetValue(record.team, out var team))
                {
                    team = new Team
                    {
                        Name = record.team,
                        Location = record.location,
                        Division = division
                    };
                    context.Teams.Add(team);
                    teams.Add(team.Name, team);
                }

                var pitcher = new Pitcher
                {
                    Name = record.name,
                    Wins = record.wins,
                    Losses = record.losses,
                    ERA = record.era,
                    Games_Played = record.games_played,
                    Games_Started = record.games_started,
                    Quality_Starts = record.quality_starts,
                    Complete_Games = record.complete_games,
                    Shutouts = record.shutouts,
                    Saves = record.saves,
                    Holds = record.holds,
                    Blown_Saves = record.blown_saves,
                    Innings_Pitched = record.innings_pitched,
                    Total_Batters_Faced = record.total_batters_faced,
                    Hits = record.hits,
                    Runs = record.runs,
                    Earned_Runs = record.earned_runs,
                    Home_Runs = record.home_runs,
                    Walks = record.walks,
                    Intentional_Walks = record.intentional_walks,
                    HBP = record.hbp,
                    Wild_Pitches = record.wild_pitches,
                    Balks = record.balks,
                    Strikeouts = record.strikeouts,
                    Team = team   
                };
                context.Pitchers.Add(pitcher);
                imported++;
            }

            await context.SaveChangesAsync();
            return Ok(imported);
        }

        [HttpPost("Hitters")]
        public async Task<ActionResult> ImportHittersAsync()
        {
            // 1) Load existing divisions and teams into dictionaries
            var divisions = await context.Divisions
                .ToDictionaryAsync(d => d.Name, StringComparer.OrdinalIgnoreCase);
            var teams = await context.Teams
                .ToDictionaryAsync(t => t.Name, StringComparer.OrdinalIgnoreCase);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null
            };

            int imported = 0;
            using var reader = new StreamReader(_hitterPathName);
            using var csv = new CsvReader(reader, config);
            var records = csv.GetRecords<HitterDto>();

            foreach (var record in records)
            {
                if (!divisions.TryGetValue(record.division, out var division))
                {
                    division = new Division { Name = record.division };
                    context.Divisions.Add(division);
                    divisions.Add(division.Name, division);
                }

                if (!teams.TryGetValue(record.team, out var team))
                {
                    team = new Team
                    {
                        Name = record.team,
                        Location = record.location,
                        Division = division
                    };
                    context.Teams.Add(team);
                    teams.Add(team.Name, team);
                }

                var hitter = new Position_Player
                {
                    Name = record.name,
                    Games_Played = record.games_played,
                    At_Bats = record.at_bats,
                    Plate_Appearances = record.plate_appearances,
                    Hits = record.hits,
                    Singles = record.singles,
                    Doubles = record.doubles,
                    Triples = record.triples,
                    Home_Runs = record.home_runs,
                    Runs_Scored = record.runs_scored,
                    RBI = record.rbi,
                    Walks = record.walks,
                    Intentional_Walks = record.intentional_walks,
                    Strikeouts = record.strikeouts,
                    HBP = record.hbp,
                    Sac_Fly = record.sac_fly,
                    Sac_Hit = record.sac_hit,
                    GDP = record.gdp,
                    Stolen_Bases = record.stolen_bases,
                    Caught_Stealing = record.caught_stealing,
                    Batting_Average = record.batting_average,
                    Team = team
                };
                context.Position_Players.Add(hitter);
                imported++;
            }

            await context.SaveChangesAsync();
            return Ok(imported);
        }

    }
}
