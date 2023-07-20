using FilmesApi.Context;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        
        private readonly FilmeContext _context;

        public FilmesController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            
            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperarFilme), new { id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> ListarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return _context.Filmes.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null) return NotFound();
            return Ok(filme);
        }
    }
}
