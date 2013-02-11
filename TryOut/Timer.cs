using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TryOut
{
    

    class Timer
    {
        private Stopwatch stopwatch;

        public Timer()
        {
            stopwatch = new Stopwatch();
            stopwatch.Reset();
        }

        public void Start()
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Reset();
                stopwatch.Start();
            }
        }

        public void Stop()
        {
            stopwatch.Stop();
        }
        
        public long ElapsedMilliseconds
        {
            get { return stopwatch.ElapsedMilliseconds;}
        }

    }
}
