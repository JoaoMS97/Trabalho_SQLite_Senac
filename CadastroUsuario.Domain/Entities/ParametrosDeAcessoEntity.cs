namespace CadastroUsuario.Domain.Entities
{
    public class ParametrosDeAcessoEntity : EntityBase
    {
        public string? Email { get; set; }

        public string? Password { get; set; }

        public Guid? Token { get; set; }

        public ParametrosDeAcessoEntity(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public ParametrosDeAcessoEntity(Guid token)
        {
            Token = token;
        }

    }
}
