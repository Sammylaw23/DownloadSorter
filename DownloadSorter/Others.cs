using System.Configuration;
using System.IO;

namespace DownloadSorter
{
    internal class Others
    {
        public static void MoveUnknown(string sourcePath)
        {
            string destinationPath = ConfigurationManager.AppSettings["OthersPath"];

            string fileName = Path.GetFileName(sourcePath);
            destinationPath = Path.Combine(destinationPath, fileName);
            destinationPath = destinationPath + fileName;
            File.Move(sourcePath, destinationPath);
        }
    }
}