namespace GameStore.Api.Dtos;

public record GameDto(
    int Id, 
    string Name, 
    string Genre, 
    decimal Price,
    string ReleaseDate); // DateOnly is not supported by the API