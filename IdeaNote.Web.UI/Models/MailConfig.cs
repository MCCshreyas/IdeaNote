using System.Net.Mail;

namespace IdeaNote.Web.UI.Models
{
    public static class MailConfig
    {
        static string MailAddress = @"ideanoteofficial@gmail.com";
        static string MailPassword = "9970209265";
        static string MailSubject = "IdeaNote account confirmation mail";

        static SmtpClient SetUpMailServer()
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(MailAddress, MailPassword),
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

            mail.Body = $@"Thank you for much <b>{user.name}</b> for creating account at IdeaNote." +
                        @"<br/><a href=""http://ideanote.somee.com/user/login"">Click here </a> to note your first idea at IdeaNote";

            mail.IsBodyHtml = true;

            SmtpClient smtp = SetUpMailServer();

            smtp.Send(mail);
        }
    }
}