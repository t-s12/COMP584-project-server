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

namespace _584_bb_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController(BaseballContext context, IHostEnvironment environment) : ControllerBase
    {
        string _pitcherPathName = Path.Combine(environment.ContentRootPath, "Data/pitcher_stats.csv");
        string _hitterPathName = Path.Combine(environment.ContentRootPath, "Data/hitter_stats.csv");

        [HttpPost("Pitchers")]
        public async Task<ActionResult> ImportPitchersAsync()
        {
            Dictionary<string, Team> teams = await context.Teams//.AsNoTracking()
            .ToDictionaryAsync(t => t.Name);

            CsvConfiguration config = new(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null
            };
            int cityCount = 0;
            using (StreamReader reader = new(_pitcherPathName))
            using (CsvReader csv = new(reader, config))
            {
                IEnumerable<PitcherDto>? records = csv.GetRecords<PitcherDto>();
                foreach (PitcherDto record in records)
                {
                    if (!teams.TryGetValue(record.TeamName, out Team? value))
                    {
                        Console.WriteLine($"No team found for {record.Name}");
                        return NotFound(record);
                    }

                    Pitcher pitcher = new()
                    {
                        Name = record.Name,
                        Wins = record.Wins,
                        Losses = record.Losses,
                        ERA = record.ERA,
                        Games_Played = record.Games_Played,
                        Games_Started = record.Games_Started,
                        Quality_Starts = record.Quality_Starts,
                        Complete_Games = record.Complete_Games,
                        Shutouts = record.Shutouts,
                        Saves = record.Saves,
                        Holds = record.Holds,
                        Blown_Saves = record.Blown_Saves,
                        Innings_Pitched = record.Innings_Pitched,
                        Total_Batters_Faced = record.Total_Batters_Faced,
                        Hits = record.Hits,
                        Runs = record.Runs,
                        Earned_Runs = record.Earned_Runs,
                        Home_Runs = record.Home_Runs,
                        Walks = record.Walks,
                        Intentional_Walks = record.Intentional_Walks,
                        HBP = record.HBP,
                        Wild_Pitches = record.Wild_Pitches,
                        Balks = record.Balks,
                        Strikeouts = record.Strikeouts,
                        TeamId = value.Id,
                    };
                    context.Pitchers.Add(pitcher);
                    cityCount++;
                }
                await context.SaveChangesAsync();
            }
            return new JsonResult(cityCount);
        }

        [HttpPost("Hitters")]
        public async Task<ActionResult> ImportHittersAsync()
        {
            Dictionary<string, Team> teams = await context.Teams//.AsNoTracking()
            .ToDictionaryAsync(t => t.Name);

            CsvConfiguration config = new(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null
            };
            int cityCount = 0;
            using (StreamReader reader = new(_hitterPathName))
            using (CsvReader csv = new(reader, config))
            {
                IEnumerable<HitterDto>? records = csv.GetRecords<HitterDto>();
                foreach (HitterDto record in records)
                {
                    if (!teams.TryGetValue(record.TeamName, out Team? value))
                    {
                        Console.WriteLine($"No team found for {record.Name}");
                        return NotFound(record);
                    }

                    Position_Player hitter = new()
                    {
                        Name = record.Name,
                        Games_Played = record.Games_Played,
                        At_Bats = record.At_Bats,
                        Plate_Appearances = record.Plate_Appearances,
                        Hits = record.Hits,
                        Singles = record.Singles,
                        Doubles = record.Doubles,
                        Triples = record.Triples,
                        Home_Runs = record.Home_Runs,
                        Runs_Scored = record.Runs_Scored,
                        RBI = record.RBI,
                        Walks = record.Walks,
                        Intentional_Walks = record.Intentional_Walks,
                        Strikeouts = record.Strikeouts,
                        HBP = record.HBP,
                        Sac_Fly = record.Sac_Fly,
                        Sac_Hit = record.Sac_Hit,
                        GDP = record.GDP,
                        Stolen_Bases = record.Stolen_Bases,
                        Caught_Stealing = record.Caught_Stealing,
                        Batting_Average = record.Batting_Average,
                        TeamId = value.Id,
                    };
                    context.Position_Players.Add(hitter);
                    cityCount++;
                }
                await context.SaveChangesAsync();
            }
            return new JsonResult(cityCount);
        }
    }
}
