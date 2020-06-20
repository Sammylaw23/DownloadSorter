using System;
using System.Configuration;
using System.IO;

namespace DownloadSorter
{
    internal class Others
    {
        public static void MoveUnknown(string sourcePath)
        {
            string fileName = string.Empty;
            try
            {
                string destinationPath = ConfigurationManager.AppSettings["OthersPath"];

                 fileName = Path.GetFileName(sourcePath);
                destinationPath = Path.Combine(destinationPath, fileName);
                File.Move(sourcePath, destinationPath);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(fileName);
                //return;
            }
        }
    }
}