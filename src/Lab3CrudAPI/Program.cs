using Lab3CrudAPI.Data;
using Lab3CrudAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=lab3.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

//GAMES CRUD

app.MapGet("/games", async (AppDbContext db) =>
{
    var games = await db.Games.ToListAsync();

    return Results.Ok(games);
});

app.MapGet("/games/{id}", async (int id, AppDbContext db) =>
{
    var game = await db.Games.FindAsync(id);

    if (game is null)
        return Results.NotFound();

    return Results.Ok(game);
});

app.MapPost("/games", async (Game game, AppDbContext db) =>
{
    db.Games.Add(game);
    await db.SaveChangesAsync();

    return Results.Created($"/games/{game.Id}", game);
});

app.MapPut("/games/{id}", async (int id, Game updatedGame, AppDbContext db) =>
{
    var game = await db.Games.FindAsync(id);

    if (game is null)
        return Results.NotFound();

    game.Title = updatedGame.Title;
    game.Genre = updatedGame.Genre;
    game.ReleaseYear = updatedGame.ReleaseYear;

    await db.SaveChangesAsync();

    return Results.Ok(game);
});

app.MapDelete("/games/{id}", async (int id, AppDbContext db) =>
{
    var game = await db.Games.FindAsync(id);

    if (game is null)
        return Results.NotFound();

    db.Games.Remove(game);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

//DEVELOPERS CRUD

app.MapGet("/developers", async (AppDbContext db) =>
{
    var developers = await db.Developers.ToListAsync();

    return Results.Ok(developers);
});

app.MapGet("/developers/{id}", async (int id, AppDbContext db) =>
{
    var developer = await db.Developers.FindAsync(id);

    if (developer is null)
        return Results.NotFound();

    return Results.Ok(developer);
});

app.MapPost("/developers", async (Developer developer, AppDbContext db) =>
{
    db.Developers.Add(developer);
    await db.SaveChangesAsync();

    return Results.Created($"/developers/{developer.Id}", developer);
});

app.MapPut("/developers/{id}", async (int id, Developer updatedDeveloper, AppDbContext db) =>
{
    var developer = await db.Developers.FindAsync(id);

    if (developer is null)
        return Results.NotFound();

    developer.Name = updatedDeveloper.Name;
    developer.Country = updatedDeveloper.Country;
    developer.FoundedYear = updatedDeveloper.FoundedYear;

    await db.SaveChangesAsync();

    return Results.Ok(developer);
});

app.MapDelete("/developers/{id}", async (int id, AppDbContext db) =>
{
    var developer = await db.Developers.FindAsync(id);

    if (developer is null)
        return Results.NotFound();

    db.Developers.Remove(developer);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

//pLATFORMS CRUD

app.MapGet("/platforms", async (AppDbContext db) =>
{
    var platforms = await db.Platforms.ToListAsync();

    return Results.Ok(platforms);
});

app.MapGet("/platforms/{id}", async (int id, AppDbContext db) =>
{
    var platform = await db.Platforms.FindAsync(id);

    if (platform is null)
        return Results.NotFound();

    return Results.Ok(platform);
});

app.MapPost("/platforms", async (Platform platform, AppDbContext db) =>
{
    db.Platforms.Add(platform);
    await db.SaveChangesAsync();

    return Results.Created($"/platforms/{platform.Id}", platform);
});

app.MapPut("/platforms/{id}", async (int id, Platform updatedPlatform, AppDbContext db) =>
{
    var platform = await db.Platforms.FindAsync(id);

    if (platform is null)
        return Results.NotFound();

    platform.Name = updatedPlatform.Name;
    platform.Manufacturer = updatedPlatform.Manufacturer;
    platform.ReleaseYear = updatedPlatform.ReleaseYear;

    await db.SaveChangesAsync();

    return Results.Ok(platform);
});

app.MapDelete("/platforms/{id}", async (int id, AppDbContext db) =>
{
    var platform = await db.Platforms.FindAsync(id);

    if (platform is null)
        return Results.NotFound();

    db.Platforms.Remove(platform);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();
