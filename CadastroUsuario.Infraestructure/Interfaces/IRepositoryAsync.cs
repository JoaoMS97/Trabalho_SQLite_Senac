namespace CadastroUsuario.Infraestructure.Interfaces
{
    public interface IRepositoryAsync<T>
    {
        Task Insert(T entity);

        Task<T> GetByGuid(Guid id);

        Task<T> GetByLogin(string login);
    }
}
