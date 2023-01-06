using SodukoSolver.DataStructures;
using System;
using System.Security.Cryptography.X509Certificates;

namespace SodukoSolver 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InputReciever ir = new InputReciever();
            Parser p = new Parser();
            Timer timer = new Timer();
            timer.start();
            string input = ir.GetInput();
            Console.WriteLine(input.Length);
            char[,] grid = p.parseString(input,(int)Math.Sqrt(input.Length));
            Grid g = new Grid(grid.GetLength(0));
            g.updateGrid(grid);
            Solver s = new Solver();
            int [,] sol = s.solveDancingList(g.getIntGrid());
            g.convertIntToChar(sol);
            //g.show();
            g.showInt();
            timer.stop();
            Console.WriteLine(timer.getTimePassed());
        }
    }
}