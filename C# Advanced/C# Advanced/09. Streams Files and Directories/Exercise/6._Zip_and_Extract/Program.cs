using System;
using System.IO;
using System.IO.Compression;

namespace _6._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathSource = Path.Combine("data");
            string pathZip = Path.Combine("result");
            Directory.CreateDirectory(pathZip);
            pathZip = Path.Combine("result", "archive.zip");

            if (File.Exists(pathZip))
            {
                File.Delete(pathZip);
            }

            ZipFile.CreateFromDirectory(pathSource, pathZip);

            string pathNewDestination = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ZipFile.ExtractToDirectory(pathZip, pathNewDestination);
        }
    }
}