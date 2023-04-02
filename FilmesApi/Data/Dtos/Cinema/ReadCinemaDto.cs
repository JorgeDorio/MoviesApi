using MoviesApi.Data.Dtos.Address;

namespace MoviesApi.Data.Dtos.Cinema;

public class ReadCinemaDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ReadAddressDto Address { get; set; }

    public DateTime GetedAt { get; set; } = DateTime.Now;
}
