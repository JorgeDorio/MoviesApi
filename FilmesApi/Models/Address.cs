using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models;

public class Address
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Street { get; set; }

    [Required]
    public int Number { get; set; }

    [Required]
    public virtual Cinema Cinema { get; set; }
}
