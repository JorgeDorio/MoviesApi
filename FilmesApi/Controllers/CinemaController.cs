using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data;
using MoviesApi.Data.Dtos.Cinema;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private IMapper _mapper;
    private MovieContext _cinemaContext;

    public CinemaController(IMapper mapper, MovieContext cinemaContext)
    {
        _mapper = mapper;
        _cinemaContext = cinemaContext;
    }

    [HttpPost]
    public IActionResult AddCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _cinemaContext.Add(cinema);
        _cinemaContext.SaveChanges();
        return Ok(cinema);
        // return CreatedAtAction(nameof());
    }
}
