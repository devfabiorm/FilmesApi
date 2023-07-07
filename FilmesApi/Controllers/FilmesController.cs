using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private static List<Filme> Filmes = new List<Filme>();

        [HttpPost]
        public void AdicionarFilme([FromBody] Filme filme)
        {
            Filmes.Add(filme);
        }
    }
}
