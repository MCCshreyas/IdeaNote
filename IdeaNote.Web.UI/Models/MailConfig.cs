using System.Net;
using System.Net.Mail;

namespace IdeaNote.Web.UI.Models
{
    public static class MailConfig
    {
        private static readonly string MailAddress = @"ideanoteofficial@gmail.com";
        private static readonly string MailPassword = "9970209265";
        private static readonly string MailSubject = "IdeaNote account confirmation mail";

        private static SmtpClient SetUpMailServer()
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(MailAddress, MailPassword),
                EnableSsl = true
            };
            return smtp;
        }

        public static void SendMail(User user)
        {
            var mail = new MailMessage();

            mail.To.Add(user.email);

            mail.From = new MailAddress(MailAddress);

            mail.Subject = MailSubject;

            mail.Body = $@"Thank you so much <b>{user.name}</b> for creating account at IdeaNote." +
                        @"<br/><a href=""http://ideanote.somee.com/user/login"">Click here </a> to note your first idea at IdeaNote";

            mail.IsBodyHtml = true;

            var smtp = SetUpMailServer();

            smtp.Send(mail);
        }
    }
}