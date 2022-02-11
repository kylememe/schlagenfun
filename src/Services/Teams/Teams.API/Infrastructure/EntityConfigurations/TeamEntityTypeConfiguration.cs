namespace Schlagenfun.Services.Teams.Infrastructure.EntityConfigurations;

class TeamEntityTypeConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Team");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .UseHiLo("team_hilo")
            .IsRequired();

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.Logo)
            .HasMaxLength(300);
    }
}
