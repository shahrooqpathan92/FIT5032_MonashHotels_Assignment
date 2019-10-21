using System;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace FIT5032_MonashHotels_Assignment.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@monashhotels.com", "FIT5032 Monash Hotels");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            //Attachment will be added to the email form the Utils folder
            var bytes = File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Utils/MonashEatsAttachment.txt"));
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment("MonashEatsAttachment.txt", file);
            
            var response = client.SendEmailAsync(msg);
        }

        public void Send_To_Many(List<EmailAddress> toEmails, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@monashhotels.com", "FIT5032 Monash Hotels");
            var tos = toEmails;
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var showAllRecipients = false;
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, plainTextContent, htmlContent, showAllRecipients);
            //Attachment will be added to the email form the Utils folder
            var bytes = File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Utils/MonashEatsAttachment.txt"));
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment("MonashEatsAttachment.txt", file);

            var response = client.SendEmailAsync(msg);
        }
    }
}