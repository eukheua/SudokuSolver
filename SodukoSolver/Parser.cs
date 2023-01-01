using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver
{
    internal class Parser
    {
        public Parser() { } 
        public char[,] parseString(string stringGrid,int size)
        {
            char[,] grid = new char[size, size];
            for(int i=0;i<size;i++)
            {
                for (int j = 0;j < size; j++)
                {
                    grid[i, j] = stringGrid[i * size + j];
                }
            }
            return grid;
        }
    }
}
