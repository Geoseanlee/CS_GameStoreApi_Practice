using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record UpdateGameDto(
    [Required][StringLength(50)]string Name,
    [Required][StringLength(50)]string Genre,
    [Required][Range(0, 200)]decimal Price,
    [Required]string ReleaseDate
);
