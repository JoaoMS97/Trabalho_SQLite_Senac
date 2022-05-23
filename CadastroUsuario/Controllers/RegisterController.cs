using CadastroUsuario.Application.Interfaces;
using CadastroUsuario.Application.Utils;
using CadastroUsuario.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IParametrosDeAcessoService _usuarioService;

        public RegisterController(IParametrosDeAcessoService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost()]
        public IActionResult Post([FromBody] InputParametrosDeAcessoDto usuarioDto)
        {
            var retorno = _usuarioService.Inserir(usuarioDto.Email, usuarioDto.Password);

            if (retorno.StatusCode.Equals((int)StatusCodeEnum.Retorno.Sucesso))
            {
                return Ok(retorno.Mensagem);
            }

            return BadRequest(retorno.Mensagem); 
        }

        [HttpGet()]
        public async Task<IActionResult> GetById(Guid? id)
        {
            var retorno = await _usuarioService.GetById(id.GetValueOrDefault());

            if (retorno.StatusCode.Equals((int)StatusCodeEnum.Retorno.Sucesso))
            {
                return Ok(retorno.Objeto);
            }

            return BadRequest(retorno.Mensagem);
        }
    }
}