using System.Security.Cryptography;
using System.Text;

namespace CadastroUsuario.Application.Utils
{
    public class Hash
    {
        public static string GerarSenhaComHash(HashAlgorithm hashAlgorithm, string senha)
        {
            var encryptedHash = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(ObterSalt(senha)));

            var teste = new StringBuilder();
            foreach (var item in encryptedHash)
            {
                teste.Append(item.ToString("x2"));
            }

            return teste.ToString();
        }

        private static string ObterSalt(string senha)
        {
            if(senha.Length > 5)
            {
                return Environment.GetEnvironmentVariable("SaltPassword1") + senha;
            }
            else if (senha.Length > 10)
            {
                return Environment.GetEnvironmentVariable("SaltPassword2") + senha;
            }
            else
            {
                return Environment.GetEnvironmentVariable("SaltPassword3") + senha;
            }
        }
    }
}
