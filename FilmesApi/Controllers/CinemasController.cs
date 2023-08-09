using AutoMapper;
using FilmesApi.Context;
using FilmesApi.Context.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemasController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly FilmeContext _context;

    public CinemasController(IMapper mapper, FilmeContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaCinemaPorId), new { id = cinema.Id }, cinemaDto);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> RecuperaCinemas()
    {
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaCinemaPorId(int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        
        if(cinema != null)
        {
            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(cinemaDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if(cinema == null)
        {
            return NotFound();
        }

        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaCinema(int id)
    {
        Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if (cinema == null)
        {
            return NotFound();
        }

        _context.Cinemas.Remove(cinema);
        _context.SaveChanges();

        return NoContent();
    }
}
