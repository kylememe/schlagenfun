
namespace Schlagenfun.Services.Teams.Infrastructure;

public class TeamsContext : DbContext
{
    public TeamsContext(DbContextOptions<TeamsContext> options) : base(options)
    {
    }

    public DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TeamEntityTypeConfiguration());
    }
}