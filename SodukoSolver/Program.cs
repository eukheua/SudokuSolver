using SodukoSolver.DataStructures;
using SodukoSolver.Exceptions;
using SodukoSolver.IO;
using SodukoSolver.Parsers;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SodukoSolver 
{
    /// <summary>
    /// Class Program is the entry point to my application and in charge of combining all classes, functions and modules into a working program.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// This function is the entry point to my application and in charge of combining all classes, functions and modules into a working program.
            /// </summary>
            /// <param>
            /// args - in case i want to enter things from command line (not used)
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            Console.CancelKeyPress += new ConsoleCancelEventHandler(CancleTermination!);
            Reader? reader = null;
            Writer? writer = null;
            string input = "";
            bool running = true;
            ApplicationGeneralMessagesPrinter.PrintOpeningMessage();
            Console.WriteLine("press any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine();
            try
            {
                reader = InputHandler.ChooseReadingFormat();
                writer = OutputHandler.ChooseWritingFormat(reader);
            }
            catch (IOException ioe)
            {
                ExceptionsHandler.PrintExceptions(ioe);
            }
            Parser p = new Parser();
            Timer timer = new Timer();
            Solver s = new Solver();
            Grid g = new Grid();
            while (running)
            {
                try
                {
                    writer!.WriteEnterGridMessage();
                    input = reader!.Read();
                    if(input == "exit")
                    {
                        ApplicationGeneralMessagesPrinter.PrintGoodByeMessage();
                        return;
                    }
                    g.UpdateGrid(p.ParseString(input, (int)Math.Sqrt(input.Length)));
                    timer.start();
                    s.Solve(g);
                }
                catch (DimensionsOfBoardNotValidException dobnve)
                {
                    ExceptionsHandler.PrintExceptions(dobnve);
                    continue;
                }
                catch (CharNotValidException cnve)
                {
                    ExceptionsHandler.PrintExceptions(cnve);
                    continue;
                }
                catch (GridUnsolveableException gue)
                {
                    ExceptionsHandler.PrintExceptions(gue);
                    continue;
                }
                catch (GridNotValidException gne)
                {
                    ExceptionsHandler.PrintExceptions(gne);
                    continue;
                }
                catch (IOException ioe)
                {
                    ExceptionsHandler.PrintExceptions(ioe);
                    continue;
                }
                timer.stop();
                try
                {
                    writer!.Write(g.ConvertGridToString());
                }
                catch (IOException ioe)
                {
                    ExceptionsHandler.PrintExceptions(ioe);
                    continue;
                }
                writer.ShowGridInFormat(g);
                timer.showTimePassed();
            }
        }
        protected static void CancleTermination(object sender, ConsoleCancelEventArgs args)
        {
            /// <summary>
            /// This function cancel the break effects of ctrl+c and ctrl+break
            /// </summary>
            /// <param>
            /// sender - object that invokes the break action
            /// args - all the cancled console events
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            args.Cancel = true;
        }
    }
}