using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos.Cinema;

public class UpdateCinemaDto
{
    [Required]
    public string Name { get; set; }
}
