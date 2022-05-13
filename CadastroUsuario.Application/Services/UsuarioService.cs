using CadastroUsuario.Application.Dto;
using CadastroUsuario.Application.Interfaces;
using CadastroUsuario.Application.Utils;
using CadastroUsuario.Domain.Entities;
using CadastroUsuario.Infraestructure.Interfaces;
using System.Security.Cryptography;

namespace CadastroUsuario.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _usuarioRepository = repository;
        }

        public RetornoDto Inserir(string login, string senha)
        {
            if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
            {
                return new RetornoDto(String.Format("Os campos '{0}' e '{1}' não podem ser nulos.", "login", "senha"), (int)StatusCodeEnum.Retorno.NotFound);
            }

            _usuarioRepository.Insert(new UsuarioEntity(login, RetornarHash(senha)));

            return new RetornoDto("Sucesso", (int)StatusCodeEnum.Retorno.Sucesso);
        }

        public async Task<RetornoDto> GetById(Guid id)
        {
            if (id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                return new RetornoDto(String.Format("O campo '{0}' não pode ser nulo.", "Id"), (int)StatusCodeEnum.Retorno.BadRequest);
            }

            var result = await _usuarioRepository.GetByGuid(id);

            if (result == null)
            {
                return new RetornoDto("ID não encontrado!", (int)StatusCodeEnum.Retorno.NotFound);
            }

            return new RetornoDto("Sucesso", (int)StatusCodeEnum.Retorno.Sucesso, result);
        }

        public async Task<RetornoDto> RealizarLogin(string login, string senha)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
            {
                return new RetornoDto("Informe o login e a senha para logar no site", (int)StatusCodeEnum.Retorno.BadRequest);
            }

            var result = await _usuarioRepository.GetByLogin(login);

            if(result == null)
            {
                return new RetornoDto("Login ou senha inválidos!", (int)StatusCodeEnum.Retorno.NotFound);
            }    

            if(RetornarHash(senha) != result.Password)
            {
                return new RetornoDto("Login ou senha inválidos!", (int)StatusCodeEnum.Retorno.BadRequest);
            }

            return new RetornoDto("Logado com Sucesso!", (int)StatusCodeEnum.Retorno.Sucesso);
        }

        private string RetornarHash(string senha)
        {
            string hash;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                hash = Hash.GerarSenhaComHash(sha256Hash, senha);
            }

            return hash;
        }
    }
}
