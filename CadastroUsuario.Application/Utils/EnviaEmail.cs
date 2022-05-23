using CadastroUsuario.Domain.Entities;
using System.Net;
using System.Net.Mail;

namespace CadastroUsuario.Application.Utils
{
    public class EnviaEmail
    {
        public static string EnviarEmail(ParametrosDeAcessoEntity result, Guid token)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(Environment.GetEnvironmentVariable("EmailDeDisparo"), Environment.GetEnvironmentVariable("Password"));
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(Environment.GetEnvironmentVariable("EmailDeDisparo"), "Yogurt");
            mail.CC.Add(new MailAddress(result.Email, "RECEBEDOR"));
            mail.Subject = "Token de acesso";
            mail.Body = $"Olá Usuário!<br/><br/> Seu token de acesso é: {token} <br/> Validade: 1 hora <br/><br/><n> OBS: Este email não é monitorado</n><br/><br/> Atenciosamente, <br/> Equipe Yogurt.";
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                return "Deu pau no envio de E-mail";
            }
            return "Email Enviado com Sucesso!";
        }
    }
}
