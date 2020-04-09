using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace DownloadSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<Heartbeat>(s =>
                {
                    s.ConstructUsing(heartbeat => new Heartbeat());
                    s.WhenStarted(heartbeat => heartbeat.Start());

                    MoveFiles moveFiles = new MoveFiles();
                    moveFiles.CheckFiles();

                    s.WhenStopped(heartbeat => heartbeat.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("DownloadSorter");
                x.SetDisplayName("DownloadSorter Service");
                x.SetDescription("This is a service built by Samuel Lawal that sorts where thing downloaded to Downloads " +
                    "folder into folders for Video,audio,pdf at set times daily");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
