using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int AddressId { get; set; }

    [Required]
    public virtual Address Address { get; set; }
}
