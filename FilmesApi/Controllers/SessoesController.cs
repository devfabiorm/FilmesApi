using AutoMapper;
using FilmesApi.Context;
using FilmesApi.Context.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessoesController : ControllerBase
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public SessoesController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto createSessaoDto)
        {
            var sessao = _mapper.Map<Sessao>(createSessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { sessao.CinemaId, sessao.FilmeId }, sessao);
        }

        [HttpGet("{cinemaId}/{filmeId}")]
        public IActionResult RecuperaSessaoPorId(int cinemaId, int filmeId) 
        {
            var sessao = _context.Sessoes.FirstOrDefault(s => s.CinemaId == cinemaId && s.FilmeId == filmeId);

            if(sessao == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ReadSessaoDto>(sessao));
        }

        [HttpGet]
        public IEnumerable<ReadSessaoDto> RecuperaSessoes()
        {
            return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.ToList());
        }
    }
}
