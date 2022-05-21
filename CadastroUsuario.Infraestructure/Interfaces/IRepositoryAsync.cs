namespace CadastroUsuario.Infraestructure.Interfaces
{
    public interface IRepositoryAsync<T>
    {
        Task Insert(T entity);

        Task<T> GetById(Guid id);

        Task<T> GetByLogin(string login);

        Task<T> GetByToken(Guid id);

    }
}
