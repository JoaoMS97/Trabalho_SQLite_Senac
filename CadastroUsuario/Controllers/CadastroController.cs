using Microsoft.AspNetCore.Mvc;

namespace CadastroUsuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok()
;
        }
    }
}