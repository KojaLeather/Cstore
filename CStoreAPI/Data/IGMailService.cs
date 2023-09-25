namespace CStoreAPI.Data
{
    public interface IGMailService
    {
        public void SendEmail(string To, string Subject, string Body);
    }
}
