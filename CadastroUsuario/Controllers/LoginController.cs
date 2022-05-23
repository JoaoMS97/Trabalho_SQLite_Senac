using CadastroUsuario.Application.Interfaces;
using CadastroUsuario.Application.Utils;
using CadastroUsuario.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IParametrosDeAcessoService _LoginService;

        public LoginController(IParametrosDeAcessoService loginService)
        {
            _LoginService = loginService;
        }

        [HttpGet("Logar")]
        public async Task <IActionResult> Logar(string? email, string? senha)
        {
            var retorno = await _LoginService.RealizarLogin(email, senha);

            if (retorno.StatusCode.Equals((int)StatusCodeEnum.Retorno.Sucesso))
            {
                return Ok(retorno.Mensagem);
            }

            if (retorno.StatusCode.Equals((int)StatusCodeEnum.Retorno.BadRequest))
            {
                return BadRequest(retorno.Mensagem);
            }

            return NotFound(retorno.Mensagem);
        }

        [HttpGet("AlterarSenha")]
        public async Task<IActionResult> AlterarSenha(string? email)
        {
            var retorno = await _LoginService.AlterarSenha(email);

            if (retorno.StatusCode.Equals((int)StatusCodeEnum.Retorno.Sucesso))
            {
                return Ok(retorno.Mensagem);
            }

            if (retorno.StatusCode.Equals((int)StatusCodeEnum.Retorno.BadRequest))
            {
                return BadRequest(retorno.Mensagem);
            }

            return NotFound(retorno.Mensagem);
        }

        [HttpPost("ValidarToken")]
        public async Task<IActionResult> ValidarToken(Guid token)
        {
            var retorno = await _LoginService.VerificarToken(token);

            if (retorno.StatusCode.Equals((int)StatusCodeEnum.Retorno.Sucesso))
            {
                return Ok(retorno.Mensagem);
            }

            return NotFound(retorno.Mensagem);
        }
    }
}
