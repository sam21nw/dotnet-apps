using minimalApi.Dtos;

namespace minimalApi.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndPointName = "GetGame";

    private static readonly List<GameDto> games = [
            new (1, "Street", "Sports", 69.7M, new DateOnly(2011, 6, 21)),
            new (2, "Final Fantasy", "Sports", 32.7M, new DateOnly(2022, 4, 08)),
            new (3, "FIFA", "Sports", 21.5M, new DateOnly(2011, 9, 30)),
            new (4, "Need for Speed", "Sports", 56.2M, new DateOnly(2008, 6, 11))
            ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/v1/games").WithParameterValidation();

        group.MapGet("/", () => games);
        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
        }).WithName(GetGameEndPointName);

        group.MapPost("/", (CreateGameDto newGame) =>
        {
            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );
            games.Add(game);
            return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

        return group;
    }
}
