using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver
{
    internal class InputReciever
    {
        public InputReciever() { }  
        public string GetInput()
        {
            Console.WriteLine("Pls enter the soduku puzzle");
            string input = Console.ReadLine();
            return input;
        }
    }
}
