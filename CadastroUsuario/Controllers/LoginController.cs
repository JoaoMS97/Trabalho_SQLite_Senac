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
        private readonly IUsuarioService _UsuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            _UsuarioService = usuarioService;
        }

        [HttpGet()]
        public async Task <IActionResult> Logar(string login, string senha)
        {
            var retorno = await _UsuarioService.RealizarLogin(login, senha);

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
    }
}
