using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace projModel;

public class BaseballContext : DbContext
{
    public BaseballContext(DbContextOptions<BaseballContext> options) : base(options) { }

    public DbSet<Division> Divisions { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Division to Teams relationship
        //modelBuilder.Entity<Team>()
        //    .HasOne(t => t.Division)
        //    .WithMany(d => d.Teams)
        //    .HasForeignKey(t => t.DivisionId);

        //// Team to Players relationship
        //modelBuilder.Entity<Player>()
        //    .HasOne(p => p.Team)
        //    .WithMany(t => t.Players)
        //    .HasForeignKey(p => p.TeamId);
    }
}

