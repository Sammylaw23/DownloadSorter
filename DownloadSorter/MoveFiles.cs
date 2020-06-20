using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadSorter
{
    public class MoveFiles
    {
        public void CheckFiles()
        {
            //Use NLog
            string sourcePath = ConfigurationManager.AppSettings["SourcePath"];
            string picExt = ConfigurationManager.AppSettings["PictureExtensions"];
            string vidExt = ConfigurationManager.AppSettings["VideoExtensions"];
            string audioExt = ConfigurationManager.AppSettings["AudioExtensions"];
            string docExt = ConfigurationManager.AppSettings["DocumentExtensions"];
            string appExt = ConfigurationManager.AppSettings["ApplicationExtensions"];

            //Use EnumerateFiles later
            //@"c:\Maps\"

            string[] filePaths2 = Directory.GetFiles(sourcePath, "*");
            string[] filePaths = Directory.GetFiles(sourcePath);
            var filesInDownloads = Directory.EnumerateFiles(sourcePath).Where(file => !file.ToLower().Contains("desktop.ini"));


            int fileCount = filesInDownloads.Count();//Log this

            foreach (var file in filesInDownloads)
            {
                Console.WriteLine("Moving " + file);
                string fileExtention = Path.GetExtension(file);

                var is_pic = filePaths.Any(i => picExt.Contains(fileExtention));
                var is_video = filePaths.Any(i => vidExt.Contains(fileExtention));
                var is_audio = filePaths.Any(i => audioExt.Contains(fileExtention));
                var is_doc = filePaths.Any(i => docExt.Contains(fileExtention));
                var is_app = filePaths.Any(i => appExt.Contains(fileExtention));
                //Can you use switch here?
                if (is_pic)
                {
                    Picture.MovePicture(file);
                }
                else if (is_video)
                {
                    Video.MoveVideo(file);
                }
                else if (is_audio)
                {
                    Audio.MoveAudio(file);
                }
                else if (is_doc)
                {
                    Document.MoveDocument(file);
                }
                else if (is_app)
                {
                    Applications.MoveApplications(file);
                }
                else
                {
                    Others.MoveUnknown(file);
                }
            }


            Console.WriteLine("I am done");
            Console.ReadKey();
        }
    }
}
