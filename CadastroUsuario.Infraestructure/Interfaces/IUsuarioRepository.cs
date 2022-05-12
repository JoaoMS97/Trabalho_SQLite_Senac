using CadastroUsuario.Domain.Entities;

namespace CadastroUsuario.Infraestructure.Interfaces
{
    public interface IUsuarioRepository : IRepositoryAsync<UsuarioEntity>
    {
    }
}
