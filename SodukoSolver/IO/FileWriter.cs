using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SodukoSolver.IO
{
    /// <summary>
    /// Class FileWriter is in charge of writing to file solved sudoku grid.
    /// </summary>
    internal class FileWriter : Iwriteable
    {
        /// <attributes>
        /// filePath - path of file to write sudoku grid to.
        /// </attributes>
        private string filePath;
        public FileWriter(string filePath)
        {
            /// <summary>
            /// This constructor creates a FileWriter object.
            /// </summary>
            /// <param>
            /// filePath - path of file to write sudoku to.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            this.filePath = filePath;
        }
        public void Write(string data)
        {
            /// <summary>
            /// This function is in charge of writing solved sudoku grid to output file.
            /// </summary>
            /// <param>
            /// data - data to write (solved sudoku grid).
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            File.WriteAllText(filePath, data);
        }
        public void WriteEnterGridMessage()
        {
            /// <summary>
            /// This function writes the message to enter grid for file grid receiving format.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            Console.WriteLine("Pls Enter your grid string in {0} save it and press enter (to exit enter 'exit')", filePath.Split('\\')[filePath.Split('\\').Length - 1]);
        }
    }
}
