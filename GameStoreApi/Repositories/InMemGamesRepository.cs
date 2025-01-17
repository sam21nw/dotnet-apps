using GameStoreApi.Entities;

namespace GameStoreApi.Repositories;

public class InMemGamesRepository : IGamesRepository
{
    private readonly List<Game> games =
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

    public IEnumerable<Game> GetAll()
    {
        return games;
    }
    public Game? Get(int id)
    {
        return games.Find(game => game.Id == id);
    }
    public void Create(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }
    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;
    }
    public void Delete(Game game)
    {
        var index = games.FindIndex(game => game.Id == game.Id);
        games.RemoveAt(index);
    }
}
