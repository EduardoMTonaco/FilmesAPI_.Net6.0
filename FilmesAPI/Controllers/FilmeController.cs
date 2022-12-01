using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.FilmeDto;
using FilmesAPI.Data.Dtos.SessaoDto;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;
        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            ReadFilmeDto filme = _filmeService.AdicionaFilme(filmeDto);
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin, regular", Policy = "IdadeMinima")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            ReadFilmeDto filmeDto = _filmeService.RecuperaFilmesPorId(id);
            if (filmeDto != null)
            {
                return Ok(filmeDto);
            }
            return NotFound(filmeDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result filme = _filmeService.AtualizaFilme(id, filmeDto);
            if (filme.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Result filme = _filmeService.DeletaFilme(id);
            if (filme.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDto> readFilmesDto = _filmeService.RecuperaFilmes(classificacaoEtaria);
            if (readFilmesDto != null)
            {
                return Ok(readFilmesDto);
            }
            return NotFound();
        }
    }
}
