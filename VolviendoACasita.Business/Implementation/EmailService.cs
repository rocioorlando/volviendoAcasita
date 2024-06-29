using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Business.Interfaces;

namespace VolviendoACasita.Business.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void SendEmail(string to, string subject, string body)
        {
            try
            {
                var smtpClient = new SmtpClient(configuration["EmailSettings:SmtpServer"])
                {
                    Port = int.Parse(configuration["EmailSettings:Port"]),
                    Credentials = new NetworkCredential(configuration["EmailSettings:Username"], configuration["EmailSettings:Password"]),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(configuration["EmailSettings:From"]),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(to);

                smtpClient.Send(mailMessage);
            }
            catch (SmtpException smtpEx)
            {
                // Obtener más detalles del error SMTP
                throw new Exception($"SMTP Error: {smtpEx.StatusCode}, {smtpEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to send email: {ex.Message}");
            }
        }
    }
}
