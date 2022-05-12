using CadastroUsuario.Domain.Entities;
using CadastroUsuario.Infraestructure.Context;
using CadastroUsuario.Infraestructure.Interfaces;

namespace CadastroUsuario.Infraestructure.RepositoryBase
{
    public class UsuarioRepository : RepositoryBase<UsuarioEntity>, IUsuarioRepository
    {
        public UsuarioRepository(CadastroUsuarioContext context) : base(context)
        {
        }
    }
}
