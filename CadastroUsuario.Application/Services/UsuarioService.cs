using CadastroUsuario.Application.Dto;
using CadastroUsuario.Application.Interfaces;
using CadastroUsuario.Domain.Entities;
using CadastroUsuario.Infraestructure.Interfaces;

namespace CadastroUsuario.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _usuarioRepository = repository;
        }

        public void Inserir(string login, string senha)
        {
            _usuarioRepository.Insert(new UsuarioEntity(login, senha));
        }

        public async Task<UsuarioDto> GetById(Guid id)
        {
            var result = await _usuarioRepository.GetByGuid(id);

            return new UsuarioDto(result.Id, result.Login, result.Password);
        }
    }
}
