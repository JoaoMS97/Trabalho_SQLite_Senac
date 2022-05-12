namespace CadastroUsuario.Domain.Entities
{
    public class UsuarioEntity : EntityBase
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public UsuarioEntity(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
