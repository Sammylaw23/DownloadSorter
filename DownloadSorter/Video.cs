using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadSorter
{
    public class Video
    {
        public static void MoveVideo(string sourcePath)
        {
            string fileName = string.Empty;
            try
            {
                string destinationPath = ConfigurationManager.AppSettings["VideoPath"];

                 fileName = Path.GetFileName(sourcePath);
                string[] programmingVideos = { "PROGRAMMING", "C#", "NET" };
                if (programmingVideos.Any(fileName.ToUpperInvariant().Contains))
                {
                    destinationPath = Path.Combine(destinationPath, fileName);
                    File.Move(sourcePath, destinationPath);
                }
                else
                {
                    destinationPath = Path.Combine(destinationPath, fileName);
                    File.Move(sourcePath, destinationPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(fileName);
                           }
        }

    }
}
