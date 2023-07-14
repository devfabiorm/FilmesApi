using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private static List<Filme> Filmes = new List<Filme>();
        private static int id = 0;

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            Filmes.Add(filme);

            return CreatedAtAction(nameof(RecuperarFilme), new { id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> ListarFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            return Filmes.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilme(int id)
        {
            var filme = Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null) return NotFound();
            return Ok(filme);
        }
    }
}
