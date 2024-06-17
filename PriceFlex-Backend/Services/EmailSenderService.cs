using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;
namespace PriceFlex_Backend.Services
{
    public class EmailSenderService : IEmailSender
    {
        private readonly IConfiguration Configuration;
        public EmailSenderService(IConfiguration configuration
            )
        { Configuration = configuration; }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Configuration["SMTP:Email"], Configuration["SMTP:Password"])
            };

            return client.SendMailAsync(new MailMessage(from: Configuration["SMTP:Email"], to: email, "Password reset", "test"));
        }
    }
}