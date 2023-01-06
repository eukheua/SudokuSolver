using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver
{
    internal class Grid
    {

        private char[,] grid;
        public Grid(int size)
        {
            grid = new char[size, size];
        }
        public void updateGrid(char[,] grid) //change after back to char[,]
        {
            for(int i=0;i< getSize(); i++)
            {
                for (int j = 0; j < getSize(); j++)
                {
                    this.grid[i, j] = grid[i,j];
                }
            }
        }
        public int[,] getIntGrid()
        {
            int[,] grid = new int[getSize(),getSize()];
            for(int i = 0; i < getSize(); i++)
            {
                for (int j = 0; j < getSize(); j++)
                {
                    grid[i, j] = this.grid[i, j] - '0';
                }
            }
            return grid;
        }
        public void convertIntToChar(int[,] grid)
        {
            for (int i = 0; i < getSize(); i++)
            {
                for (int j = 0; j < getSize(); j++)
                {
                    this.grid[i, j] = (char)(grid[i, j] + '0');
                }
            }
        }
        public int getSize()
        {
            return grid.GetLength(0);
        }
        public char[,] getGrid()
        {
            return grid;
        }
        public char getCell(int i, int j)
        {
            return grid[i, j];  
        }
        public void setCell(char value,int i,int j)
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
        public void showInt()
        {
            int[,] grid = getIntGrid();
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j] + ",");
                }
                Console.WriteLine();
            }
        }
    }
}
