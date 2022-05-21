namespace CadastroUsuario.Domain.Entities
{
    public class UsuarioEntity : EntityBase
    {
        public string? Login { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }

        public Guid? Token { get; set; }

        public UsuarioEntity(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
        }

        public UsuarioEntity(Guid token)
        {
            Token = token;
        }

    }
}
