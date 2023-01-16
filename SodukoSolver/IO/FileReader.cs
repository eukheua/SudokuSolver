using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.IO
{
    /// <summary>
    /// Class FileReader is in charge of reading from file information related to sudoku grid.
    /// </summary>
    public class FileReader : Ireadable
    {
        /// <attributes>
        /// filePath - path of file to read sudoku grid from.
        /// </attributes>
        private string filePath;
        public FileReader(string filePath)
        {
            /// <summary>
            /// This constructor is in charge of creating a FileReader object.
            /// </summary>
            /// <param>
            /// filePath - path of file to read sudoku grid from. 
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            this.filePath = filePath;
        }

        public string Read()
        {
            /// <summary>
            /// This function is in charge of reading sudoku grid from file.
            /// if user requests to exit it does.
            /// </summary>
            /// <param>
            /// 
            /// </param>
            /// <returns>
            /// the sudoku grid in string format.
            /// </returns>
            string text = File.ReadAllText(filePath);
            string? input = Console.ReadLine();
            if (input == "exit")
            {
                return input;
            }
            return text;
        }
        public string GetFilePath()
        {
            /// <summary>
            /// This function returns the input file path.
            /// </summary>
            /// <param>
            /// 
            /// </param>
            /// <returns>
            /// the input file path.
            /// </returns>
            return filePath;
        }
    }
}
