using System;
using System.Net.Mail;
using System.IO;
using System.Web.Hosting;
namespace BIIC_Contest.Helpers
{
    public class GmailHelper
    {
        public static void sendEmail(string toEmail, string subject, string fullname, string phone, string password)
        {
            try
            {
                string templatePath = HostingEnvironment.MapPath("~/assets/template/email-template.html");
                string emailBody = File.ReadAllText(templatePath)
                    .Replace("@Model.Fullname", fullname)
                    .Replace("@Model.Email", toEmail)
                    .Replace("@Model.Phone", phone)
                    .Replace("@Model.Password", password);



                var mail = new MailMessage();
                mail.To.Add(toEmail);
                mail.From = new MailAddress("anvohoang98@gmail.com", "BIIC Contest");
                mail.Subject = subject;
                mail.Body = emailBody;
                mail.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    smtp.Send(mail);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}