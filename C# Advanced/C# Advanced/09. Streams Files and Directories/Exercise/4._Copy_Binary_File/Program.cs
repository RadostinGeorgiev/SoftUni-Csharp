using System.IO;
using System.Threading.Tasks;

namespace _4._Copy_Binary_File
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const int bufferSize = 4096;

            var path = Path.Combine("data", "copyMe.png");
            using FileStream fsr = new FileStream(path, FileMode.Open);
            path = Path.Combine("data", "copy.png");
            using FileStream fsw = new FileStream(path, FileMode.Create);

            byte[] buffer = new byte[bufferSize];
            while (fsr.CanRead)
            {
                var bytes = await fsr.ReadAsync(buffer, 0, bufferSize);

                if (bytes == 0)
                {
                    break;
                }

                await fsw.WriteAsync(buffer, 0, bufferSize);
            }
        }
    }
}