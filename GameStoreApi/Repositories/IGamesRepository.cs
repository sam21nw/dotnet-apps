using GameStoreApi.Dtos;
using GameStoreApi.Entities;

namespace GameStoreApi.Repositories;

public interface IGamesRepository
{
    IEnumerable<Game> GetAll();
    Game? Get(int id);
    void Create(Game game);
    void Update(Game updatedGame);
    void Delete(Game game);
}
