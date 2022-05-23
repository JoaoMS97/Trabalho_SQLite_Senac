namespace CadastroUsuario.Infraestructure.Interfaces
{
    public interface IRepositoryAsync<T>
    {
        Task Insert(T entity);

        Task<T> GetById(Guid id);

        Task<T> GetByEmail(string email);

        Task<T> GetByToken(Guid id);

    }
}
