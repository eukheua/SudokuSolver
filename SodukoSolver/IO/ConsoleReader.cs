using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.IO
{
    /// <summary>
    /// Class ConsoleReader is in charge of reading data related to sudoku grid from console.
    /// </summary>
    public class ConsoleReader : Ireadable
    {
        public ConsoleReader()
        {
            /// <summary>
            /// This constructor is in charge of creating a ConsoleReader object.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
        }
        public string Read()
        {
            /// <summary>
            /// This function reads input from user via console.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// The data.
            /// </returns>
            string? input = Console.ReadLine();
            return input != null ? input : "";
        }
    }
}
