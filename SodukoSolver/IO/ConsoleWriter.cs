using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.IO
{
    /// <summary>
    /// Class ConsoleWriter is in charge of writing to console information related to sudoku grid.
    /// </summary>
    internal class ConsoleWriter : Iwriteable
    {
        public ConsoleWriter()
        {
            /// <summary>
            /// This constructor is in charge of creating a ConsoleWriter object.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
        }
        public void Write(string data)
        {
            /// <summary>
            /// This function writes to console information related to the sudoku grid.
            /// </summary>
            /// <param>
            /// data - what to write.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            Console.WriteLine(data);
        }
        public void WriteEnterGridMessage()
        {
            /// <summary>
            /// This function writes the message to enter grid for console grid receiving format.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            Console.WriteLine("Pls enter your sudoku grid string: (to exit enter 'exit')");
        }
    }
}
