using CStoreAPI.Data;

namespace CStoreAPI.Data
{
    public class ImageWork : IFileWork
    {
        public string ReadFile(string ImageName)
        {
            if (ImageName == null) ImageName = "D:\\Programming\\FirstPetProject\\FileStorage\\ErrorPictures\\Error.jpg";
            using (FileStream fsSource = new FileStream(ImageName, FileMode.Open, FileAccess.Read))
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
        public void WriteFile(string ImageBase64, string ImageName)
        {
            byte[] ImageByte = Convert.FromBase64String(ImageBase64);
            using (FileStream CreateImage = new FileStream(ImageName, FileMode.Create, FileAccess.Write))
            {
                int numBytesToRead = ImageByte.Length;
                CreateImage.Write(ImageByte, 0, numBytesToRead);
            }
        }
    }
}
