using GameStoreApi.Dtos;
using GameStoreApi.Entities;
using GameStoreApi.Repositories;

namespace GameStoreApi.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games").WithParameterValidation();


        group.MapGet("/", (IGamesRepository repository) => repository.GetAll().Select(game => game.AsDto()));

        group.MapGet("/{id}", (IGamesRepository repository, int id) =>
        {
            Game? game = repository.Get(id);
            return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();
        })
        .WithName(GetGameEndpointName);

        group.MapPost("/", (IGamesRepository repository, CreateGameDto gameDto) =>
        {
            Game game = new()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate,
                ImageUri = gameDto.ImageUri
            };
            repository.Create(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", (IGamesRepository repository, int id, UpdateGameDto updatedGame) =>
        {
            Game? existingGame = repository.Get(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            repository.Update(existingGame);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (IGamesRepository repository, int id) =>
        {
            Game? game = repository.Get(id);
            if (game is not null)
            {
                repository.Delete(game);
            }
            return Results.NoContent();
        });

        return group;
    }
}
