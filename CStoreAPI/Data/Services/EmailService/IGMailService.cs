namespace CStoreAPI.Data.Services.EmailService
{
    public interface IGMailService
    {
        public void SendEmail(string To, int StatusCode, int OrderID);
    }
}
