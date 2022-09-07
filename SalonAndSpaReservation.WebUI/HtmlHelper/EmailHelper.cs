using SalonAndSpaReservation.WebUI.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SalonAndSpaReservation.WebUI.HtmlHelper
{
    public class EmailHelper
    {
        public async Task<bool> SendEmailAsync(EmailPayload payload)
        {
            var port = payload.SmptPort;
            var senderEmail = payload.SenderEmail;
            var senderPassword = payload.SenderPassword;
            var smtpHost = payload.SmtpHost;

            MailMessage message = new MailMessage(payload.SenderEmail, payload.ReceiverEmail);

            message.Subject = payload.Subject;
            message.Body = payload.Mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient(payload.SmtpHost, payload.SmptPort);
            NetworkCredential basicCredential1 = new NetworkCredential(payload.SenderEmail, payload.SenderPassword);

            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            try
            {
                client.Send(message);
                client.Dispose();

                return true;
            }

            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
            
        }
    }
}