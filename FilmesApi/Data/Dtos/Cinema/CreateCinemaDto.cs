using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos.Cinema;

public class CreateCinemaDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public int AddressId { get; set; }
}
