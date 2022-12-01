using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.FilmeDto;
using FilmesAPI.Data.Dtos.GerenteDto;
using FilmesAPI.Data.Dtos.SessaoDto;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionaGerente (CreateGerenteDto dto)
        {
            Gerente gerente = _gerenteService.AdicionaGerente(dto);
            return CreatedAtAction(nameof(RecuperaGerentePorId), new {Id = gerente.Id}, gerente);
        }
        [HttpGet]
        public IEnumerable<Gerente> RecuperaGerentes()
        {
            return _gerenteService.RecuperaGerentes();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id) 
        {
            ReadGerenteDto gerenteDto = _gerenteService.RecuperaGerentePorId(id);
            if (gerenteDto != null)
            {
                return Ok(gerenteDto);
            }
            return NotFound();
        }

    }
}
