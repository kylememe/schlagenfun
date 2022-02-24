
namespace Schlagenfun.Services.Teams.Infrastructure;

public class TeamsContext : DbContext
{
    public DbSet<Team> Teams { get; set; }

    public TeamsContext(DbContextOptions<TeamsContext> options) : base(options)
    {        
    }   

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TeamEntityTypeConfiguration());
    }
}