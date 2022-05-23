using CadastroUsuario.Application.Dto;

namespace CadastroUsuario.Application.Interfaces
{
    public interface IParametrosDeAcessoService
    {
        Task<RetornoDto> RealizarLogin(string email, string senha);

        Task<RetornoDto> AlterarSenha(string email);

        RetornoDto Inserir(string email, string senha);

        Task<RetornoDto> GetById(Guid id);

        Task<RetornoDto> VerificarToken(Guid token);

    }
}
