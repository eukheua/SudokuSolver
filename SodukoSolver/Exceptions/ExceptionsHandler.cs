using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.Exceptions
{
    /// <summary>
    /// Class ExceptionsHandler is in charge of functions related to exceptions.
    /// </summary>
    internal static class ExceptionsHandler
    {
        public static void PrintExceptions(Exception ex)
        {
            /// <summary>
            /// This function prints exception in format.
            /// </summary>
            /// <param>
            /// ex - the exception.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(ex.GetType().Name + "\n" + ex.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
