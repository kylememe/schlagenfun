
namespace Schlagenfun.Services.Players.Infrastructure;

public class Player
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }    
}

public class PlayersContext : DbContext
{
    public DbSet<Player> Players { get; set; }

    public PlayersContext(DbContextOptions<PlayersContext> options) : base(options)
    {        
    }   

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Player>()
            .ToTable("Player")
            .HasKey(e => e.Id);

        builder.Entity<Player>()
            .Property(e => e.Id)
                .ValueGeneratedOnAdd()           
                .IsRequired();

        builder.Entity<Player>()
            .Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(200);

        builder.Entity<Player>()
            .Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(200);
    }
}