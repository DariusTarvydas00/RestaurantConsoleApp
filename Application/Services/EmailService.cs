using System.Net;
using System.Net.Mail;

namespace ApplicationLayer.Services;

public class EmailService
{
    public void SendEmail(string recipientEmail, string subject, string body)
    {
        using (var client = new SmtpClient("smtp.example.com"))
        {
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("your_email@example.com", "your_password");
            client.EnableSsl = true;
            client.Port = 587;

            var message = new MailMessage("your_email@example.com", recipientEmail, subject, body);
            client.Send(message);
        }
    }
}