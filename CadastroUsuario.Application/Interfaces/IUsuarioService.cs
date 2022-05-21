using CadastroUsuario.Application.Dto;

namespace CadastroUsuario.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<RetornoDto> RealizarLogin(string login, string senha);

        Task<RetornoDto> AlterarSenha(string login);

        RetornoDto Inserir(string login, string senha, string email);

        Task<RetornoDto> GetById(Guid id);

        Task<RetornoDto> VerificarToken(Guid token);

    }
}
