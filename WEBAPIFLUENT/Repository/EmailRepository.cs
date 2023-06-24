using System.Net;
using System.Net.Mail;

namespace WEBAPIFLUENT.Repository
{

    public class EmailRepository
    {
        public static  bool sendMail(string body)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("N170470@rguktn.ac.in", "Vickyvamsikrishna84"),
                    EnableSsl = true,
                    UseDefaultCredentials = false
                };
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("N170470@rguktn.ac.in"),
                    Subject = "Reset Password",
                    Body = body,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add("vamsiikrishna.dev@gmail.com");

                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex) { return false; }
        }
    }
}
