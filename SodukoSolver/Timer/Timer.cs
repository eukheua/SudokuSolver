using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver
{
    internal class Timer
    {
        private DateTime startTime;
        private TimeSpan timePassed;
        public Timer()
        {
            startTime = new DateTime();
        }
        public void start()
        {
            startTime = DateTime.Now;
        }
        public void stop()
        {
            timePassed = DateTime.Now- startTime;
        }
        public double getTimePassed()
        {
            return timePassed.TotalMilliseconds;
        }
    }
}
