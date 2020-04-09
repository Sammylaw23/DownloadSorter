using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadSorter
{
    public class Applications
    {
        public static void MoveApplications(string sourcePath)
        {
            string destinationPath = ConfigurationManager.AppSettings["ApplicationPath"];

            string fileName = Path.GetFileName(sourcePath);
            destinationPath = Path.Combine(destinationPath, fileName);
            File.Move(sourcePath, destinationPath);
        }
    }
}
