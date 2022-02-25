
namespace Schlagenfun.Services.Teams.Infrastructure;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Logo{ get; set; }    
}

public class TeamsContext : DbContext
{
    public DbSet<Team> Teams { get; set; }

    public TeamsContext(DbContextOptions<TeamsContext> options) : base(options)
    {        
    }   

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Team>()
            .ToTable("Team")
            .HasKey(e => e.Id);

        builder.Entity<Team>()
            .Property(e => e.Id)            
                .IsRequired();

        builder.Entity<Team>()
            .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

        builder.Entity<Team>()
            .Property(e => e.Logo)
                .HasMaxLength(300);
    }
}