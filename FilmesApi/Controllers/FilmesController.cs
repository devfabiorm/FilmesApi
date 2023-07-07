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
        public void AdicionarFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            Filmes.Add(filme);
        }

        [HttpGet]
        public IEnumerable<Filme> ListarFilmes()
        {
            return Filmes;
        }

        [HttpGet("{id}")]
        public Filme? RecuperarFilme(int id)
        {
            return Filmes.FirstOrDefault(filme => filme.Id == id);
        }
    }
}
