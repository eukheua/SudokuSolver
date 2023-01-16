using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.IO
{
    /// <summary>
    /// Class Writer is in charge of writing sudoku grids related information.
    /// </summary>
     public class Writer : Iwriteable
    {
        /// <attributes>
        /// writer - a generic writer object (could be FileWriter or ConsoleWriter).
        /// </attributes>
        private readonly Iwriteable writer;
        public Writer(Iwriteable writer)
        {
            /// <summary>
            /// This constructor creates a Writer object.
            /// </summary>
            /// <param>
            /// writer - generic writer object.
            /// </param>
            /// <returns>
            /// Nothing
            /// </returns>
            this.writer = writer;
        }
        public void Write(string data)
        {
            /// <summary>
            /// This function writes output according to the input format he chose.
            /// </summary>
            /// <param>
            /// data - data to write.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            writer.Write(data);
        }
        public void ShowGridInFormat(Grid grid)
        {
            /// <summary>
            /// This function prints the grid in a nice format.
            /// </summary>
            /// <param>
            /// grid - grid object to print.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            Console.WriteLine(grid.PrintInFormat());
        }
        public void WriteEnterGridMessage()
        {
            /// <summary>
            /// This function prints the enter grid messages generically.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            writer.WriteEnterGridMessage();
        }
    }
}
