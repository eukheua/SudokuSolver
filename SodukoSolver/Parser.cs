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
        public int[,] parseString(string stringGrid,int size)
        {
            int[,] grid = new int[size, size];
            for(int i=0;i<size;i++)
            {
                for (int j = 0;j < size; j++)
                {
                    grid[i, j] = Convert.ToInt32(stringGrid[i * size + j]-'0');
                }
            }
            return grid;
        }
    }
}
