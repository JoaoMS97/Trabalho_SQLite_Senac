using CadastroUsuario.Application.Dto;

namespace CadastroUsuario.Application.Interfaces
{
    public interface IUsuarioService
    {
        void Inserir(string login, string senha);

        Task<UsuarioDto> GetById(Guid id);
    }
}
