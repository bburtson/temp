using System;
using System.Globalization;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace USTVA.Services
{
    public class AdminAlert
    {
        public async Task SendEmailAsync(string name, string address, string subject, string body)
        {
            var serverEmail = new MailboxAddress(DateTime.Now.ToString(CultureInfo.InvariantCulture), "no-reply@burtson.com");

            var message = new MimeMessage();

            message.From.Add(serverEmail);

            message.To.Add(new MailboxAddress(name, address));

            message.Subject = subject;

            message.Body = new TextPart("html")
            {
                Text = $"<h3>Details</h3> {body}"
            };


            using (var client = new SmtpClient())
            {
                client.LocalDomain = "burtson.com";
               
                client.Connect("smtp-relay.gmail.com", 587);
     
                
                await client.SendAsync(message).ConfigureAwait(false);

                client.Disconnect(true);
            }
        }
    }
}
