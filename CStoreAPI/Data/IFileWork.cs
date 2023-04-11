namespace CStoreAPI.Data
{
    public interface IFileWork
    {
        public string ReadFile(string FileName);
        public void WriteFile(string FileBase64, string FileName);
    }
}
