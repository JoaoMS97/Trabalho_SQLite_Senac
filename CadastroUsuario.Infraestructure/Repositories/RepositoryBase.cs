using CadastroUsuario.Domain.Entities;
using CadastroUsuario.Infraestructure.Context;
using CadastroUsuario.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Infraestructure.RepositoryBase
{
    public class RepositoryBase<T> : IRepositoryAsync<T> where T : EntityBase
    {
        private readonly CadastroUsuarioContext _cadastroUsuarioContext;

        public RepositoryBase(CadastroUsuarioContext cadastroUsuarioContext)
        {
            _cadastroUsuarioContext = cadastroUsuarioContext;
        }

        public async Task Insert(T entity)
        {
            await _cadastroUsuarioContext.Set<T>().AddAsync(entity);
            await _cadastroUsuarioContext.SaveChangesAsync();
        }

        public async Task<T> GetByGuid(Guid id)
        {
            return await _cadastroUsuarioContext.Set<T>().FirstAsync(x => x.Id == id);
        }

        public async Task<T> GetByLogin(string login, string senha)
        {
            return await _cadastroUsuarioContext.Set<T>().FirstAsync(x => x.Login == login);
        }
    }
}
