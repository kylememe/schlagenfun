
var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
var DbPath = System.IO.Path.Join(path, "players.db");

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PlayersContext>(opt => opt.UseSqlite($"Data Source={DbPath}"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

if(app.Environment.IsDevelopment()){
    using (var serviceScope = app.Services.CreateScope())
    {
        var seeder = new PlayersSeeder(serviceScope.ServiceProvider.GetService<PlayersContext>());
        seeder.SeedForDev();
    }
}

app.MapGet("/", () => "Hello World from Players API!");

app.MapGet("/players", async (PlayersContext db) =>
    await db.Players.ToListAsync());

app.MapGet("/players/{id}", async (int id, PlayersContext db) =>
    await db.Players.FindAsync(id)
        is Player player
            ? Results.Ok(player)
            : Results.NotFound());

app.MapPost("/players", async (Player player, PlayersContext db) =>
{
    db.Players.Add(player);
    await db.SaveChangesAsync();

    return Results.Created($"/players/{player.Id}", player);
});

app.MapPut("/players/{id}", async (int id, Player inputPlayer, PlayersContext db) =>
{
    var player = await db.Players.FindAsync(id);

    if (player is null) return Results.NotFound();

    player.FirstName = inputPlayer.FirstName;
    player.LastName = inputPlayer.LastName;
    player.Age = inputPlayer.Age;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/players/{id}", async (int id, PlayersContext db) =>
{
    if (await db.Players.FindAsync(id) is Player player)
    {
        db.Players.Remove(player);
        await db.SaveChangesAsync();
        return Results.Ok(player);
    }

    return Results.NotFound();
});


app.Run();