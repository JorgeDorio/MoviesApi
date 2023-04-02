using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Data.Dtos.Address;

public class CreateAddressDto
{
    [Required]
    public string Street { get; set; }

    [Required]
    public int Number { get; set; }
}
