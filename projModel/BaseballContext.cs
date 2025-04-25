using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace projModel;

public partial class BaseballContext : IdentityDbContext
{
    public BaseballContext(DbContextOptions<BaseballContext> options) : base(options) { }

    public DbSet<Division> Divisions { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Pitcher> Pitchers { get; set; }
    public DbSet<Position_Player> Position_Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json");
        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<City>(entity =>
        //{

        //    entity.HasOne(d => d.Country).WithMany(p => p.Cities)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_City_Country");
        //});

        //modelBuilder.Entity<Country>(entity =>
        //{
        //    entity.Property(e => e.Iso2).IsFixedLength();
        //    entity.Property(e => e.Iso3).IsFixedLength();
        //});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

