namespace CadastroUsuario.Domain.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        public string? Login { get; set; }

        public string? Password { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
        public EntityBase(string login, string password)
        {
            Login = login;
            Password = password;    
        }
    }
}
