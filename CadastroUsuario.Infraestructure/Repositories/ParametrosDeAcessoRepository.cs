using CadastroUsuario.Domain.Entities;
using CadastroUsuario.Infraestructure.Context;
using CadastroUsuario.Infraestructure.Interfaces;

namespace CadastroUsuario.Infraestructure.RepositoryBase
{
    public class ParametrosDeAcessoRepository : RepositoryBase<ParametrosDeAcessoEntity>, IParametrosDeAcessoRepository
    {
        public ParametrosDeAcessoRepository(ParametrosDeAcessoContext context) : base(context)
        {
        }
    }
}
