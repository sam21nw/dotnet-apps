using minimalApi.Data;
using minimalApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.MapGet("/", () => Results.Json(new { message = "Hello World" }));

app.MapGamesEndpoints();

await app.MigrateDbAsync();

app.Run();
