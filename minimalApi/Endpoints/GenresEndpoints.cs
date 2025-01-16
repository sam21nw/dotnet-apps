using Microsoft.EntityFrameworkCore;

using minimalApi.Data;
using minimalApi.Mapping;

namespace minimalApi.Endpoints;

public static class GenresEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
        RouteGroupBuilder group = app.MapGroup("/api/v1/genres");

        group.MapGet("/", async (GameStoreContext dbContext) =>
        {
            await dbContext.Genres
                .Select(genre => genre.ToDto())
                .AsNoTracking()
                .ToListAsync();
        });
        return group;
    }
}
