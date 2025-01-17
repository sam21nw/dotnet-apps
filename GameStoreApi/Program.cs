using GameStoreApi.Endpoints;
using GameStoreApi.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>();

builder.Configuration.GetConnectionString("GameStoreContext");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGamesEndpoints();

app.Run();
