using Microsoft.EntityFrameworkCore;

namespace minimalApi.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication application)
    {
        using var scope = application.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await dbContext.Database.MigrateAsync();
    }
}
