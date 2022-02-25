
var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
var DbPath = System.IO.Path.Join(path, "teams.db");

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TeamsContext>(opt => opt.UseSqlite($"Data Source={DbPath}"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

if(app.Environment.IsDevelopment()){
    using (var serviceScope = app.Services.CreateScope())
    {
        var seeder = new TeamsSeeder(serviceScope.ServiceProvider.GetService<TeamsContext>());
        seeder.SeedForDev();
    }
}

app.MapGet("/", () => "Hello World from Teams API!");

app.MapGet("/teams", async (TeamsContext db) =>
    await db.Teams.ToListAsync());

app.MapGet("/teams/{id}", async (int id, TeamsContext db) =>
    await db.Teams.FindAsync(id)
        is Team team
            ? Results.Ok(team)
            : Results.NotFound());

app.MapPost("/teams", async (Team team, TeamsContext db) =>
{
    db.Teams.Add(team);
    await db.SaveChangesAsync();

    return Results.Created($"/teams/{team.Id}", team);
});

app.MapPut("/teams/{id}", async (int id, Team inputTeam, TeamsContext db) =>
{
    var team = await db.Teams.FindAsync(id);

    if (team is null) return Results.NotFound();

    team.Name = inputTeam.Name;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/teams/{id}", async (int id, TeamsContext db) =>
{
    if (await db.Teams.FindAsync(id) is Team team)
    {
        db.Teams.Remove(team);
        await db.SaveChangesAsync();
        return Results.Ok(team);
    }

    return Results.NotFound();
});


app.Run();