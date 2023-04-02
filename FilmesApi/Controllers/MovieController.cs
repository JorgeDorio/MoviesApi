using AutoMapper;
using MoviesApi.Data;
using MoviesApi.Data.Dtos;
using MoviesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private MovieContext _movieContext;
    private IMapper _mapper;

    public MovieController(MovieContext movieContext, IMapper mapper)
    {
        _movieContext = movieContext;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        _movieContext.Add(movie);
        _movieContext.SaveChanges();
        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<ReadMovieDto> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var moviesDto = _mapper.Map<IEnumerable<ReadMovieDto>>(_movieContext.Movies.Skip(skip).Take(take));

        return moviesDto;
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _movieContext.Movies.FirstOrDefault((movie) => movie.Id == id);
        if (movie == null) return NotFound();

        var movieDto = _mapper.Map<ReadMovieDto>(movie);

        return Ok(movieDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
    {
        var movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound();
        _mapper.Map(movieDto, movie);
        _movieContext.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateMovieByField(int id, JsonPatchDocument<UpdateMovieDto> patch)
    {
        var movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound();

        var _movie = _mapper.Map<UpdateMovieDto>(movie);

        patch.ApplyTo(_movie, ModelState);

        if (!TryValidateModel(_movie))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(_movie, movie);
        _movieContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound();

        _movieContext.Remove(movie);
        _movieContext.SaveChanges();

        return NoContent();
    }
}
