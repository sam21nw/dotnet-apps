using System.ComponentModel.DataAnnotations;

namespace minimalApi.Dtos;

public record class GameSummaryDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
    );

public record class GameDetailsDto(
    int Id,
    string Name,
    int GenreId,
    decimal Price,
    DateOnly ReleaseDate
    );

public record class CreateGameDto(
    [Required][StringLength(20)] string Name,
    // [Required][StringLength(10)] string Genre,
    int GenreId,
    [Required][Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
    );

public record class UpdateGameDto(
    [Required][StringLength(20)] string Name,
    // [Required][StringLength(10)] string Genre,
    int GenreId,
    [Required][Range(1, 100)] decimal Price,
    DateOnly ReleaseDate
    );
