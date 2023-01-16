using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.IO
{
    /// <summary>
    /// Class InputHandler is in charge of initializing the Reader object according to the grid reception formate chosen by the user.
    /// </summary>
    public static class InputHandler
    {
        public static Reader ChooseReadingFormat()
        {
            /// <summary>
            /// This function initialize a Reader object according to the grid reception format.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Reader object.
            /// </returns>
            bool isFormatLegal = false;
            Reader reader;
            Ireadable? tempReader = null;
            Console.WriteLine("Pls Enter the sudoku grid reading Format:");
            Console.WriteLine("For reading from console enter 1");
            Console.WriteLine("For reading from file enter 2");
            string? format = Console.ReadLine();
            while (!isFormatLegal)
            {
                if (format == "1")
                {
                    tempReader = new ConsoleReader();
                    isFormatLegal = true;
                }
                else if (format == "2")
                {
                    string fileName = ChoosingFileName();
                    tempReader = new FileReader(fileName);
                    isFormatLegal = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("invalid reading format!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Pls Enter the sudoku grid reading Format:");
                    Console.WriteLine("For reading from console enter 1");
                    Console.WriteLine("For reading from file enter 2");
                    format = Console.ReadLine();
                }
            }
            reader = new Reader(tempReader!);
            return reader;
        }
        public static string ChoosingFileName()
        {
            /// <summary>
            /// This function gets the input file path if user chose to enter grids by file.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// File path.
            /// </returns>
            Console.WriteLine("Pls Enter the path of the file:");
            string? filePath = "";
            bool validFile = false;
            while (!validFile)
            {
                filePath = Console.ReadLine();
                if (filePath == null)
                {
                    filePath = "";
                }
                string[] splitPath = filePath!.Split("\\");
                if (!File.Exists(filePath))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Path doesn't exists");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Pls existing file path:");
                }
                else if (!(splitPath[splitPath.Length - 1].Split(".")[1] == "txt"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("File must be a text file!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Pls Enter the name of a text file:");
                }
                else
                {
                    validFile = true;
                }
            }
            return filePath;
        }
    }
}
