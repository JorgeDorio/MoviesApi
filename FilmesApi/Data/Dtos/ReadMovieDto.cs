using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos;

public class ReadMovieDto
{

    public string Title { get; set; }

    public string Description { get; set; }

    public int Duration { get; set; }

    public DateTime GetedAt { get; set; } = DateTime.Now;
}
