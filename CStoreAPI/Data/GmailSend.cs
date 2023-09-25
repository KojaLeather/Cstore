using System.Net.Mail;
using System.Net;

namespace CStoreAPI.Data
{
    public class GmailSend : IGMailService
    {
        public void SendEmail(string To, string Subject, string Body)
        {
            IConfiguration secrets = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true
            };
            smtpClient.Credentials = new NetworkCredential("allo49etati@gmail.com", secrets["AppPass"]); //Use the new password, generated from google!
            var message = new System.Net.Mail.MailMessage(new System.Net.Mail.MailAddress("allo49etati@gmail.com", "CStore"), new System.Net.Mail.MailAddress(To, "Client"))
            {
                Body = Body,
                Subject = Subject
            };
            smtpClient.Send(message);
        }
    }
}
