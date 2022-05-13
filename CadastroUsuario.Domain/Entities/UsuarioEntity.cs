namespace CadastroUsuario.Domain.Entities
{
    public class UsuarioEntity : EntityBase
    {
        public UsuarioEntity(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
