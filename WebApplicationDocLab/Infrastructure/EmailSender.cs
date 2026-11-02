using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace WebApplicationDocLab.Infrastructure
{
    // Reads SMTP settings from Web.config (appSettings: SmtpHost, SmtpPort, SmtpFromEmail,
    // SmtpPassword) instead of hardcoding credentials in source.
    public static class EmailSender
    {
        public static string FromAddress => ConfigurationManager.AppSettings["SmtpFromEmail"];

        public static SmtpClient CreateClient()
        {
            var host = ConfigurationManager.AppSettings["SmtpHost"];
            var port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"] ?? "587");
            var fromEmail = ConfigurationManager.AppSettings["SmtpFromEmail"];
            var password = ConfigurationManager.AppSettings["SmtpPassword"];

            return new SmtpClient(host)
            {
                Port = port,
                Credentials = new NetworkCredential(fromEmail, password),
                EnableSsl = true,
            };
        }
    }
}
