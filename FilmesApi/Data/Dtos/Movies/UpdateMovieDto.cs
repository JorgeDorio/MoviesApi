using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos.Movies;

public class UpdateMovieDto
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int Duration { get; set; }
}
