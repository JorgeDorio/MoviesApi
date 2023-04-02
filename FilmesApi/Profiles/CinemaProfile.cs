using AutoMapper;
using MoviesApi.Data.Dtos.Cinema;
using MoviesApi.Models;

namespace MoviesApi.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
    }
}
