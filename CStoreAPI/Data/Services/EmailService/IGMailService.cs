namespace CStoreAPI.Data.Services.EmailService
{
    public interface IGMailService
    {
        public void SendEmail(string To, string Subject, string Body);
    }
}
