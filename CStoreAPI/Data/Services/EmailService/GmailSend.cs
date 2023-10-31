using System.Net.Mail;
using System.Net;

namespace CStoreAPI.Data.Services.EmailService
{
    public class GmailSend : IGMailService
    {
        public void SendEmail(string To, int StatusCode, int OrderId)
        {
            string Subject = "";
            string Body = "";

            string st2sub = "Your Order has been Accepted!";
            string st2body = $"Hello customer!\nYour order {OrderId} has been accepted!" +
                             "\nWe are currently getting it ready to ship right to you!" +
                             "\nWe will send you an email when it will be sended!" +
                             "\n\nIf you have any question, feel free to reply to this Email with your question.";

            string st3sub = "Your Order has been Completed!";
            string st3body = $"Hello customer!\nYour order {OrderId} has been completed!" +
                             "\nYour goods are on the way to you." +
                             "\nWe still dont implement trackcode feature, but it's WIP" + //TO:DO add trackcode as column in order table and send to email
                             "\n\nIf you have any question, feel free to reply to this Email with your question.";

            string st4sub = "Your Order has been Canceled.";
            string st4body = $"Hello customer!\nYour order {OrderId} has been cancelled." +
                             "\nYour order has been cancelled due to the reason:``!" + //TO:DO create on front feature to send reason to cancelling, also add cancelReason to table
                             "\n\nIf you have any question, feel free to reply to this Email with your question.";

            IConfiguration secrets = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            try
            {
                switch (StatusCode)
                {
                    case 2:
                        Subject = st2sub;
                        Body = st2body;
                        break;
                    case 3:
                        Subject = st3sub;
                        Body = st3body;
                        break;
                    case 4:
                        Subject = st4sub;
                        Body = st4body;
                        break;
                    default:
                        throw new InvalidOperationException("Status code is out of range");
                }
            }
            catch (Exception)
            {

            }

            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true
            };
            //Here we're putting our adress and AppPass that stored in "secrets.json"
            smtpClient.Credentials = new NetworkCredential("allo49etati@gmail.com", secrets["AppPass"]);
            //Generating message
            var message = new MailMessage(new MailAddress("allo49etati@gmail.com", "CStore"), new MailAddress(To, "Client"))
            {
                Body = Body,
                Subject = Subject
            };
            smtpClient.Send(message);
        }
    }
}
