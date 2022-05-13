using System.Security.Cryptography;
using System.Text;

namespace CadastroUsuario.Application.Utils
{
    public class Hash
    {
        public static string GerarSenhaComHash(HashAlgorithm hashAlgorithm, string senha)
        {
            var encryptedHash = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(senha));

            var teste = new StringBuilder();
            foreach (var item in encryptedHash)
            {
                teste.Append(item.ToString("x2"));
            }

            return teste.ToString();
        }
    }
}
