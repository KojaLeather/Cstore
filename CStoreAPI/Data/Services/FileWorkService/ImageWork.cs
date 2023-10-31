using static System.Net.WebRequestMethods;

namespace CStoreAPI.Data.Services.FileWorkService
{
    public class ImageWork : IFileWork
    {
        public string? FSP;
        public ImageWork()
        {
            //Getting absolute adress to filestorage from appsettings.json
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(
            "appsettings.json", optional: true, reloadOnChange: true);
            FSP = builder.Build().GetSection("Paths").GetSection("FileStoragePath").Value;
        }
        public string ReadFile(string ImageName)
        {
            
            string FilePath;
            //If there's no image in DB we're getting Error pic.
            if (ImageName == null) FilePath = FSP + "\\ErrorPictures\\Error.jpg";
            //attempt in semirelative path
            else FilePath = FSP + ImageName;
            using (FileStream fsSource = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fsSource.Length];
                int numBytesToRead = (int)fsSource.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);
                    if (n == 0) break;
                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                return Convert.ToBase64String(bytes, 0, bytes.Length);
            }
        }
        public string WriteFile(string ImageBase64, string ImageName)
        {
            string FilePath = "\\Images\\" + ImageName;

            //getting rid of data that isn't base64
            if (ImageBase64.Contains(','))
            {
                ImageBase64 = ImageBase64.Substring(ImageBase64.IndexOf(',') + 1);
            }
            byte[] ImageByte = Convert.FromBase64String(ImageBase64);
            using (FileStream CreateImage = new FileStream(FSP + FilePath, FileMode.Create, FileAccess.Write))
            {
                int numBytesToRead = ImageByte.Length;
                CreateImage.Write(ImageByte, 0, numBytesToRead);
            }
            return FilePath;
        }
    }
}
