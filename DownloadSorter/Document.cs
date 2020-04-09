using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadSorter
{
    public class Document
    {
        public static void MoveDocument(string sourcePath)
        {
            string destinationPath = ConfigurationManager.AppSettings["DocumentPath"];

            string fileName = Path.GetFileName(sourcePath);
            destinationPath = Path.Combine(destinationPath, fileName);
            File.Move(sourcePath, destinationPath);
        }
    }
}
