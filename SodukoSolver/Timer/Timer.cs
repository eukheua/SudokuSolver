using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver
{
    /// <summary>
    /// Class Timer is in charge of showing the runtime of the solution.
    /// </summary>
    internal class Timer
    {
        /// <attributes>
        /// startTime - beggining time.
        /// timePassed - time passed since beggining
        /// </attributes>
        private DateTime startTime;
        private TimeSpan timePassed;
        public Timer()
        {
            /// <summary>
            /// This constructor creates a Timer object.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            startTime = new DateTime();
        }
        public void start()
        {
            /// <summary>
            /// This functions sets the start time.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            startTime = DateTime.Now;
        }
        public void stop()
        {
            /// <summary>
            /// This functions sets the timePassed to the time period between the start and end of the solving process.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            timePassed = DateTime.Now- startTime;
        }
        public double getTimePassed()
        {
            /// <summary>
            /// This function returns the time took for solving in miliseconds.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            ///  the time took for solving in miliseconds.
            /// </returns>
            return timePassed.TotalMilliseconds;
        }
        public void showTimePassed()
        {
            /// <summary>
            /// This function prints the time took for solving in miliseconds.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            Console.WriteLine("Solving time: "+ timePassed.Milliseconds + " ms");
        }
    }
}
