using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using UsuariosApi.Data.Dto;
using UsuariosApi.Data.Resquest;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createUsuarioDto) 
        {
            Result resultado = _cadastroService.CadastroUsuario(createUsuarioDto);
            if(resultado.IsFailed)
            {
                return StatusCode(500);
            }
            return Ok(resultado);
        }
        [HttpGet("/ativa")]
        public IActionResult AtivaContaUsuario([FromQuery]AtivaContaRequest request)
        {
            Result resultado = _cadastroService.AtivaContaUsuario(request);
            if(resultado.IsFailed) 
            {
                return StatusCode(500);
            }
            return Ok(resultado);
        }
    }
}
