namespace CStoreAPI.Data.Services.FileWorkService
{
    public interface IFileWork
    {
        public string ReadFile(string FileName);
        public string WriteFile(string FileBase64, string FileName);
    }
}
