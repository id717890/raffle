using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Raffle.Api.Services
{
    public class AuthMessageSender : IEmailSender
    {
        public AuthMessageSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            //var apiKey = Environment.GetEnvironmentVariable(Options.SendGridUser);
            var client = new SendGridClient(Options.SendGridKey);
            var from = new EmailAddress("test@example.com", "Example User");
            //var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(email);
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, message);
            var response = await client.SendEmailAsync(msg);


            //// Plug in your email service here to send an email.
            //var myMessage = new SendGrid.SendGridMessage();
            //myMessage.AddTo(email);
            //myMessage.From = new System.Net.Mail.MailAddress("Joe@contoso.com", "Joe Smith");
            //myMessage.Subject = subject;
            //myMessage.Text = message;
            //myMessage.Html = message;
            //var credentials = new System.Net.NetworkCredential(
            //    Options.SendGridUser,
            //    Options.SendGridKey);
            //// Create a Web transport for sending email.
            //var transportWeb = new SendGrid.Web(credentials);
            //// Send the email.
            //if (transportWeb != null)
            //{
            //    return transportWeb.DeliverAsync(myMessage);
            //}
            //else
            //{
            //    return Task.FromResult(0);
            //}
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
