using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Odonto.App.Services;

namespace Odonto.App.Extensions
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirme sua Conta",
                $"Por favor, confirme sua conta acessando o seguinte endereço: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
