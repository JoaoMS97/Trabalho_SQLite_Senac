using CadastroUsuario.Application.Dto;

namespace CadastroUsuario.Application.Interfaces
{
    public interface IUsuarioService
    {
        RetornoDto Inserir(string login, string senha);

        Task<RetornoDto> GetById(Guid id);

        Task<RetornoDto> RealizarLogin(string login, string senha);
    }
}
