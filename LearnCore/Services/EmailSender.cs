using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace LearnCore.Services 
{
    public class EmailSender : IEmailSender
    {
        // inheritance from base class the interface i needed 
        // using Microsoft.AspNetCore.Identity.UI.Services;
        // immplement interface 

        //1 way 

        //public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        //{
        //    // Your email sending logic here
        //    // Example using SmtpClient (Gmail settings):
        //    string fromMail = "sabryabdalla9@gmail.com";
        //    string password = "Aa20103695"; // Generate this from your Gmail account

        //    var smtpClient = new SmtpClient("smtp.gmail.com")
        //    {
        //        Port = 587,
        //        Credentials = new NetworkCredential(fromMail, password),
        //        EnableSsl = true,
        //    };

        //    var mailMessage = new MailMessage(fromMail, email, subject, htmlMessage)
        //    {
        //        IsBodyHtml = true,
        //    };

        //    await smtpClient.SendMailAsync(mailMessage);
        //}


        // ------------------------------------------------- 

        public EmailSender()
        {
            
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fMail = "sabryabdalla9@gmail.com";
            var fPassword = "Aa20103695";

            var theMsg = new MailMessage();
            theMsg.From = new MailAddress(fMail);
            theMsg.Subject = subject;
            theMsg.To.Add(email);
            theMsg.Body = $"<html><body>{htmlMessage}</body></html>";
            theMsg.IsBodyHtml = true;

            var smtpClint = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fMail, fPassword),
                EnableSsl = true,
                
            };

            await smtpClint.SendMailAsync(theMsg);
        }
    }
}
    
    

