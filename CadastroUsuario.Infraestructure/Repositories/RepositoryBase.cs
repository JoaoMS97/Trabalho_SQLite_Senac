using CadastroUsuario.Domain.Entities;
using CadastroUsuario.Infraestructure.Context;
using CadastroUsuario.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Infraestructure.RepositoryBase
{
    public class RepositoryBase<T> : IRepositoryAsync<T> where T : ParametrosDeAcessoEntity
    {
        private readonly ParametrosDeAcessoContext _cadastroUsuarioContext;

        public RepositoryBase(ParametrosDeAcessoContext cadastroUsuarioContext)
        {
            _cadastroUsuarioContext = cadastroUsuarioContext;
        }

        public async Task Insert(T entity)
        {
            await _cadastroUsuarioContext.Set<T>().AddAsync(entity);
            await _cadastroUsuarioContext.SaveChangesAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _cadastroUsuarioContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetByEmail(string email)
        {
            return await _cadastroUsuarioContext.Set<T>().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<T> GetByToken(Guid token)
        {
            return await _cadastroUsuarioContext.Set<T>().FirstOrDefaultAsync(x => x.Token == token);
        }
    }
}
