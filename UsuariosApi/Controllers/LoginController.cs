using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Resquest;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class LoginController : ControllerBase
    {
        private LoginService _loginservice;

        public LoginController(LoginService loginservice)
        {
            _loginservice = loginservice;
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest request)
        {
            Result resultado = _loginservice.LogaUsuario(request);
            if(resultado.IsFailed)
            {
                return Unauthorized(resultado.Errors);
            }
            return Ok(resultado);
        }
        [HttpPost("/solicita-reset")]
        public IActionResult SolicitaReseteSenhaUsuario(SolicitaResetRequest request)
        {
            Result resultdo = _loginservice.SolicitaResetSenhaUsuario(request);
            if(resultdo.IsFailed) 
            {
                return Unauthorized(resultdo.Errors);
            }
            return Ok(resultdo);
        }

        [HttpPost("/efetua-reset")]
        public IActionResult ReseteSenhaUsuario(EfetuaResetRequest request)
        {
            Result resultdo = _loginservice.ResetaSenhaUsuario(request);
            if (resultdo.IsFailed)
            {
                return Unauthorized(resultdo.Errors);
            }
            return Ok(resultdo);
        }
    }
}
