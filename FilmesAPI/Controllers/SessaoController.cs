using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.SessaoDto;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _sessaoService.AdicionaSessao(dto);
            return CreatedAtAction(nameof(RecuperaSessoePorId), new { Id = sessao.Id }, sessao);
        }
        [HttpGet]
        public IEnumerable<Sessao> RecuperaSessoes()
        {
            return _sessaoService.RecuperaSessoes();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoePorId(int id)
        {
            ReadSessaoDto sessao = _sessaoService.RecuperaSessaoPorId(id);
            if(sessao != null)
            {
                return Ok(sessao);
            }
            return NotFound();
        }
    }
}
