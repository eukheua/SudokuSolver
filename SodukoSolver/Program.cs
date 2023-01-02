using System;
using System.Security.Cryptography.X509Certificates;

namespace SodukoSolver 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grid g = new Grid(16);
            InputReciever ir = new InputReciever();
            Parser p = new Parser();
            string input = ir.GetInput();
            char[,] grid = p.parseString(input, g.getSize());
            g.updateGrid(grid);
            g.show();
            Console.ReadKey();
            Solver s = new Solver();
            s.solve(g, 0, 0);
            g.show();
        }
    }
}