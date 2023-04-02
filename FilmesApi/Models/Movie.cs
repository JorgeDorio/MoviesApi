using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models;

public class Movie
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [Required]
    [MaxLength(100)]
    public string Description { get; set; }

    [Required]
    [Range(70, 600)]
    public int Duration { get; set; }
}
