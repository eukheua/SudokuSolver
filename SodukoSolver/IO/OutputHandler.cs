using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.IO
{
    public class OutputHandler
    {
        /// <summary>
        /// Class OutputHandler is in charge of initializing the Writer object according to the grid reception formate chosen by the user.
        /// </summary>
        public static Writer ChooseWritingFormat(Reader reader)
        {
            /// <summary>
            /// This function initialize a Writer object according to the grid reception format.
            /// </summary>
            /// <param>
            /// reader - Reader object that informs what is the input format the user chose so we can infer what will be the writing format.
            /// </param>
            /// <returns>
            /// Writer object.
            /// </returns>
            bool isAnswerLegal = false;
            Iwriteable? tempWriter = null;
            Writer writer;

            if (typeof(FileReader).IsInstanceOfType(reader.getReader()))
            {
                Console.WriteLine("Do you want to receive the solved soduko back to the same file?");
                Console.WriteLine("If You do enter 'y'");
                Console.WriteLine("Else enter 'n'");
                FileReader fileReader = (FileReader)reader.getReader();
                string? sameFile = Console.ReadLine();

                while (!isAnswerLegal)
                {
                    if (sameFile == "y")
                    {
                        tempWriter = new FileWriter(fileReader.GetFilePath());
                        isAnswerLegal = true;
                    }
                    else if (sameFile == "n")
                    {
                        string fileName = ChoosingOutPutFileName();
                        tempWriter = new FileWriter(fileName);
                        isAnswerLegal = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("invalid answer!!!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Do you want to receive the solved soduko back to the same file?");
                        Console.WriteLine("If yes enter 'y'");
                        Console.WriteLine("If no enter 'n'");
                    }
                }
            }
            else
            {
                tempWriter = new ConsoleWriter();
            }
            writer = new Writer(tempWriter!);
            return writer;
        }
        public static string ChoosingOutPutFileName()
        {
            /// <summary>
            /// This function gets the output file path if user chose not to receive the solved grid in the same file.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// File path.
            /// </returns>
            string? filePath = "";
            bool validFile = false;
            Console.WriteLine("Pls Enter the path of the output file:");
            while (!validFile)
            {
                filePath = Console.ReadLine();
                if(filePath == null)
                {
                    filePath = "";
                }
                string[] splitPath = filePath!.Split("\\");
                if (!File.Exists(filePath))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Path doesn't exists!!!");
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
