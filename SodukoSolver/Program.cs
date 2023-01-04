using SodukoSolver.DataStructures;
using System;
using System.Security.Cryptography.X509Certificates;

namespace SodukoSolver 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grid g = new Grid(9);
            InputReciever ir = new InputReciever();
            Parser p = new Parser();
            string input = ir.GetInput();
            /*char[,] grid = p.parseString(input, g.getSize());
            g.updateGrid(grid);
            g.show();
            Console.ReadKey();
            Solver s = new Solver();
            s.solve(g, 0, 0);
            g.show();*/
            int[,] grid = p.parseIntString(input, g.getSize());
            CoverMatrix cm = new CoverMatrix(9, grid);
            int[,] arr = cm.convertInCoverMatrix(grid);
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + ",");
                }
                Console.WriteLine();
            }
        }
    }
}