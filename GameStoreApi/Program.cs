using GameStoreApi.Entities;

const string GetGameEndpointName = "GetGame";
List<Game> games =
[
    new(){
        Id = 1,
        Name = "Fighter II",
        Genre = "Fighting",
        Price=19.99m,
        ReleaseDate=new DateTime(1991, 3, 7),
        ImageUri="https://placehold.co/100"},
    new(){
        Id = 2,
        Name = "Minecraft",
        Genre = "Family",
        Price=59.78m,
        ReleaseDate=new DateTime(2001, 9, 21),
        ImageUri="https://placehold.co/100"},
];

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// var group = app.MapGroup("/games");

app.MapGet("/", () => "Hello World!");

app.MapGet("/games", () => games);

app.MapGet("/games/{id}", (int id) =>
{
    Game? game = games.Find(game => game.Id == id);
    if (game is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(game);
})
.WithName(GetGameEndpointName);

app.MapPost("/games", (Game game) =>
{
    game.Id = games.Max(game => game.Id) + 1;
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});

app.MapPut("/games/{id}", (int id, Game updatedGame) =>
{
    Game? existingGame = games.Find(game => game.Id == id);
    if (existingGame is null)
    {
        return Results.NotFound();
    }
    existingGame.Name = updatedGame.Name;
    existingGame.Genre = updatedGame.Genre;
    existingGame.Price = updatedGame.Price;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;
    existingGame.ImageUri = updatedGame.ImageUri;

    return Results.NoContent();
});

app.MapDelete("/games/{id}", (int id) =>
{
    Game? game = games.Find(game => game.Id == id);
    if (game is not null)
    {
        games.Remove(game);
    }
    return Results.NoContent();
});

app.Run();
