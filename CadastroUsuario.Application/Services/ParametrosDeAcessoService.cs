using CadastroUsuario.Application.Dto;
using CadastroUsuario.Application.Interfaces;
using CadastroUsuario.Application.Utils;
using CadastroUsuario.Domain.Entities;
using CadastroUsuario.Infraestructure.Interfaces;

namespace CadastroUsuario.Application.Services
{
    public class ParametrosDeAcessoService : IParametrosDeAcessoService
    {
        private readonly IParametrosDeAcessoRepository _usuarioRepository;

        public ParametrosDeAcessoService(IParametrosDeAcessoRepository repository)
        {
            _usuarioRepository = repository;
        }

        public async Task<RetornoDto> RealizarLogin(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                return new RetornoDto("Informe o email e a senha para logar no site", (int)StatusCodeEnum.Retorno.BadRequest);
            }

            var result = await _usuarioRepository.GetByEmail(email);

            if (result == null)
            {
                return new RetornoDto("Login ou senha inválidos!", (int)StatusCodeEnum.Retorno.NotFound);
            }

            if (Utilitarios.RetornarHash(senha) != result.Password)
            {
                return new RetornoDto("Login ou senha inválidos!", (int)StatusCodeEnum.Retorno.BadRequest);
            }

            return new RetornoDto("Logado com Sucesso!", (int)StatusCodeEnum.Retorno.Sucesso);
        }

        public async Task<RetornoDto> AlterarSenha(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return new RetornoDto("Informe o login para logar no site", (int)StatusCodeEnum.Retorno.BadRequest);
            }

            var result = await _usuarioRepository.GetByEmail(email);

            if (result == null)
            {
                return new RetornoDto("Login inválido!", (int)StatusCodeEnum.Retorno.NotFound);
            }

            Guid token = Guid.NewGuid();
            SQliteDirect.Update("UsuarioEntity", result, ".Token");

            return new RetornoDto(EnviaEmail.EnviarEmail(result, token), (int)StatusCodeEnum.Retorno.Sucesso);
        }

        public RetornoDto Inserir(string email, string senha)
        {
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                return new RetornoDto(String.Format("Os campos '{0}' e '{1}' não podem ser nulos.", "login", "senha"), (int)StatusCodeEnum.Retorno.NotFound);
            }

            if (!Utilitarios.VerificarEmail(email))
            {
                return new RetornoDto("O email informado é invalido! por favor, informe um email válido.", (int)StatusCodeEnum.Retorno.NotFound);
            }

            _usuarioRepository.Insert(new ParametrosDeAcessoEntity(email, Utilitarios.RetornarHash(senha)));

            return new RetornoDto("Sucesso", (int)StatusCodeEnum.Retorno.Sucesso);
        }

        public async Task<RetornoDto> GetById(Guid id)
        {
            if (id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                return new RetornoDto(String.Format("O campo '{0}' não pode ser nulo.", "Id"), (int)StatusCodeEnum.Retorno.BadRequest);
            }

            var result = await _usuarioRepository.GetById(id);

            if (result == null)
            {
                return new RetornoDto("ID não encontrado!", (int)StatusCodeEnum.Retorno.NotFound);
            }

            return new RetornoDto("Sucesso", (int)StatusCodeEnum.Retorno.Sucesso, result);
        }

        public async Task<RetornoDto> VerificarToken(Guid token)
        {
            if (token == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                return new RetornoDto("o Campo 'Token' não pode ser nulo.", (int)StatusCodeEnum.Retorno.BadRequest);
            }

            var result = await _usuarioRepository.GetByToken(token);

            if (result == null)
            {
                return new RetornoDto("O token informado é inválido!", (int)StatusCodeEnum.Retorno.NotFound);
            }

            return new RetornoDto("Sucesso", (int)StatusCodeEnum.Retorno.Sucesso, result);
        }
    }
}
