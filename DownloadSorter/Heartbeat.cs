using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DownloadSorter
{
    class Heartbeat
    {
        private readonly Timer _timer;

        public Heartbeat()
        {
            _timer = new Timer(1000) { AutoReset = true };

            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {

        }

        public void Start()
        {
            _timer.AutoReset = false;
            _timer.Enabled = true;

            _timer.Start();

          
        }

        public void Stop()
        {
            _timer.Stop();
        }

    }
}
