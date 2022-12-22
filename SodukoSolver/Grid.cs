using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver
{
    internal class Grid
    {

        private int[,] grid;
        public Grid(int size)
        {
            grid = new int[size, size];
        }
        public void updateGrid(int[,] stringGrid) //change after back to char[,]
        {
            for(int i=0;i< grid.GetLength(0);i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = (int)stringGrid[i,j];
                }
            }
        }
        public int getSize()
        {
            return grid.GetLength(0);
        }
        public int[,] getGrid()
        {
            return grid;
        }
        public int getCell(int i, int j)
        {
            return grid[i, j];  
        }
        public void setCell(int value,int i,int j)
        {
            grid[i, j] = value;
        }
        public void show()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j]+",");
                }
                Console.WriteLine();
            }
        }
    }
}
