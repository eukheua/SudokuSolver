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
            string input = ir.GetInput();
            timer.start();
            Console.WriteLine(input.Length);
            char[,] grid = p.parseString(input,(int)Math.Sqrt(input.Length));
            Grid g = new Grid(grid.GetLength(0));
            g.updateGrid(grid);
            Solver s = new Solver();
            int [,] sol = s.solveDancingList(g.getIntGrid());
            timer.stop();
            g.convertIntToChar(sol);
            string str = g.s();
            Console.WriteLine(str);
            //g.show();
            g.showInt();
            Console.WriteLine(timer.getTimePassed());
        }
    }
}