using System;
using System.Security.Cryptography.X509Certificates;

namespace SodukoSolver 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] grid =
            {
                {3,7,0,5,9,0,0,0,1 },
                {0,0,5,8,0,0,0,0,0 },
                {0,1,0,3,0,6,4,0,0},
                { 2,0,8,0,4,0,0,6,5},
                {0,0,9,0,0,0,7,0,0 },
                {5,4,0,0,6,0,8,0,2 },
                {0,0,4,6,0,8,0,1,0 },
                {0,0,0,0,0,7,9,0,0 },
                {7,0,0,0,5,2,0,3,4 }
            };
            Grid g = new Grid(9);
            g.updateGrid(grid);
            Solver s = new Solver();
            s.solve(g, 0, 0);
            g.show();
        }
    }
}