using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data;
using MoviesApi.Data.Dtos.Address;
using MoviesApi.Data.Dtos.Movies;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public AddressController(MovieContext movieContext, IMapper mapper)
    {
        _context = movieContext;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddAddrress([FromBody] CreateAddressDto addressDto)
    {
        Address address = _mapper.Map<Address>(addressDto);
        _context.Add(address);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAddressById), new { id = address.Id }, address);
    }

    [HttpGet]
    public IEnumerable<ReadAddressDto> GetAddresses([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var addressDto = _mapper.Map<IEnumerable<ReadAddressDto>>(_context.Addresses.Skip(skip).Take(take));

        return addressDto;
    }

    [HttpGet("{id}")]
    public IActionResult GetAddressById(int id)
    {
        var address = _context.Addresses.FirstOrDefault((address) => address.Id == id);
        if (address == null) return NotFound();

        var addressDto = _mapper.Map<ReadAddressDto>(address);

        return Ok(addressDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDto adressDto)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address == null) return NotFound();
        _mapper.Map(adressDto, address);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateAddressByField(int id, JsonPatchDocument<UpdateAddressDto> patch)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address == null) return NotFound();

        var _address = _mapper.Map<UpdateAddressDto>(address);

        patch.ApplyTo(_address, ModelState);

        if (!TryValidateModel(_address))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(_address, address);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(int id)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if (address == null) return NotFound();

        _context.Remove(address);
        _context.SaveChanges();

        return NoContent();
    }
}
