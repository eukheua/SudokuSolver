using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver
{
    internal class Validator
    {
        public static bool validate(char[,] grid,int row,int column, char number)
        {
            return (validateNotInRow(grid, row, number) && validateNotInColumn(grid, column, number)&& validateNotInSubGrid(grid,row,column,number));
        }
        public static bool validateNotInRow(char[,] grid, int row, char number)
        {
            for(int column=0; column < grid.GetLength(0); column++)
            {
                if (grid[row, column] == number)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool validateNotInColumn(char[,] grid, int column, char number)
        {
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                if (grid[row, column] == number)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool validateNotInSubGrid(char[,] grid, int row,int column, char number)
        {
            int lenOfSubGrid = (int)Math.Sqrt(grid.GetLength(0));
            for (int r = row/ lenOfSubGrid * lenOfSubGrid; r < row / lenOfSubGrid * lenOfSubGrid + lenOfSubGrid; r++)
            {
                for (int c = column / lenOfSubGrid * lenOfSubGrid; c < column / lenOfSubGrid * lenOfSubGrid + lenOfSubGrid; c++)
                {
                    if (grid[r, c] == number)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
