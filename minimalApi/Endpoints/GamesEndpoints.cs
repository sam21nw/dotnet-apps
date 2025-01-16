using Microsoft.EntityFrameworkCore;

using minimalApi.Data;
using minimalApi.Dtos;
using minimalApi.Entities;
using minimalApi.Mapping;

namespace minimalApi.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndPointName = "GetGame";
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/v1/games").WithParameterValidation();

        group.MapGet("/", async (GameStoreContext dbContext) =>
        await dbContext.Games
            .Include(game => game.Genre)
            .Select(game => game.ToGameSummaryDto())
            .AsNoTracking()
            .ToListAsync());

        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            Game? game = await dbContext.Games.FindAsync(id);
            return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
        }).WithName(GetGameEndPointName);

        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            Game game = newGame.ToEntity();
            // game.Genre = dbContext.Genres.Find(newGame.GenreId);

            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();
            return Results.CreatedAtRoute(
                GetGameEndPointName,
                new { id = game.Id },
                game.ToGameDetailsDto());
        });

        group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
        {
            var existingGame = await dbContext.Games.FindAsync(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingGame).CurrentValues.SetValues(updatedGame.ToEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            await dbContext.Games
            .Where(game => game.Id == id)
            .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
