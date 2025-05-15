using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace projModel;

public partial class BaseballContext : IdentityDbContext<BaseballTeamsUser>
{
    public BaseballContext(DbContextOptions<BaseballContext> options)
        : base(options)
    {
    }

    public DbSet<Division> Divisions { get; set; } = null!;
    public DbSet<Team> Teams { get; set; } = null!;
    public DbSet<Pitcher> Pitchers { get; set; } = null!;
    public DbSet<Position_Player> Position_Players { get; set; } = null!;

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }
}
