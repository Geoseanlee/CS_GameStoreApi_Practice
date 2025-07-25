namespace GameStore.Api.Dtos;

public record UpdateGameDto(
    string Name,
    string Genre,
    decimal Price,
    string ReleaseDate
);
