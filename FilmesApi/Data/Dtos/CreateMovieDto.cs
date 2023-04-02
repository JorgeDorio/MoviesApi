using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class CreateMovieDto
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    [Required]
    [StringLength(100)]
    public string Description { get; set; }

    [Required]
    [Range(70, 600)]
    public int Duration { get; set; }
}
