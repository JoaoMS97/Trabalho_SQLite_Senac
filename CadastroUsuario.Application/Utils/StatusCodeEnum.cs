using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuario.Application.Utils
{
    public class StatusCodeEnum
    {
        public enum Retorno
        {
            Sucesso = 200,
            BadRequest = 400,
            NotFound = 404
        }
    }
}
