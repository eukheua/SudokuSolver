using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.Validations
{
    /// <summary>
    /// Class Validator is in charge of validations related to the application.
    /// </summary>
    internal static class Validator
    {
        public static bool AreDimensionsValid(string board)
        {
            /// <summary>
            /// This function returns whether the dimensions of boards are valid.
            /// </summary>
            /// <param>
            /// board - sudoku grid as string
            /// </param>
            /// <returns>
            /// whether the dimensions of boards are valid.
            /// </returns>
            for (int i = 0; i < Config.SupportedDimensions.Length; i++)
            {
                if (Config.SupportedDimensions[i] == Math.Sqrt(board.Length))
                {
                    return true;
                }
            }
            return false;
        }
        public static char AreAllCharsValid(string board)
        {
            /// <summary>
            /// This function returns whether all chars are valid in grid.
            /// </summary>
            /// <param>
            /// board - sudoku grid as string
            /// </param>
            /// <returns>
            /// whether all chars are valid in grid.
            /// </returns>
            bool isValidChar = false;
            for (int i = 0; i < board.Length; i++)
            {
                for(int j =0;j<= Math.Sqrt(board.Length)&&!isValidChar; j++)
                {
                    if (board[i] == (char)(j+'0'))
                    {
                        isValidChar = true;
                    }
                }
                if(!isValidChar)
                {
                    return board[i];
                }
                isValidChar= false;
            }
            return ' ';
        }
        public static string IsGridValid(string board)
        {
            /// <summary>
            /// This function returns whether the sudoku grid is valid (fulfilling all sudoku grid conditions).
            /// </summary>
            /// <param>
            /// board - sudoku grid as string
            /// </param>
            /// <returns>
            /// whether the sudoku grid is valid.
            /// </returns>
            string potentialMessage = "";
            Parser parser = new Parser();
            int[,] grid = parser.ParseIntString(board, (int)Math.Sqrt(board.Length));
            for(int i=0; i<grid.GetLength(0);i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if(grid[i, j] != 0)
                    {
                        if (!validateCell(grid, i, j, grid[i, j]))
                        {
                            potentialMessage = String.Format("char '{0}' in row {1} column {2} causes the sudoku grid to be invalid", (char)(grid[i, j] + '0'),i,j);
                            return potentialMessage;
                        }
                    }
                }
            }
            return "";
        }
        public static bool validateCell(int[,] grid, int row, int column, int number)
        {
            /// <summary>
            /// This function returns whether the a cell value in the grid is in a valid position.
            /// </summary>
            /// <param>
            /// grid - sudoku grid as int matrix
            /// row - cell row
            /// column - cell column
            /// number - cell value
            /// </param>
            /// <returns>
            /// whether the a cell value in the grid is in a valid position.
            /// </returns>
            return (validateNotInRow(grid, row, column, number) && validateNotInColumn(grid, column, row, number) && validateNotInSubGrid(grid, row, column, number));
        }
        public static bool validateNotInRow(int[,] grid, int row,int j, int number)
        {
            /// <summary>
            /// This function returns whether the a value appears only once in row.
            /// </summary>
            /// <param>
            /// grid - sudoku grid as int matrix
            /// row - cell row
            /// j - cell column
            /// number - cell value
            /// </param>
            /// <returns>
            /// whether the a value appears only once in row.
            /// </returns>
            for (int column = 0; column < grid.GetLength(0); column++)
            {
                if (grid[row, column] == number && j!= column)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool validateNotInColumn(int[,] grid,int column,int i ,int number)
        {
            /// <summary>
            /// This function returns whether the a value appears only once in column.
            /// </summary>
            /// <param>
            /// grid - sudoku grid as int matrix
            /// column - cell column
            /// i - cell row
            /// number - cell value
            /// </param>
            /// <returns>
            /// whether the a value appears only once in column.
            /// </returns>
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                if (grid[row, column] == number && i!= row)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool validateNotInSubGrid(int[,] grid, int row, int column, int number)
        {
            /// <summary>
            /// This function returns whether the a value appears only once in a box.
            /// </summary>
            /// <param>
            /// grid - sudoku grid as int matrix
            /// row - cell row
            /// column - cell rocolumnw
            /// number - cell value
            /// </param>
            /// <returns>
            /// whether the a value appears only once in a box.
            /// </returns>
            int lenOfSubGrid = (int)Math.Sqrt(grid.GetLength(0));
            for (int r = row / lenOfSubGrid * lenOfSubGrid; r < row / lenOfSubGrid * lenOfSubGrid + lenOfSubGrid; r++)
            {
                for (int c = column / lenOfSubGrid * lenOfSubGrid; c < column / lenOfSubGrid * lenOfSubGrid + lenOfSubGrid; c++)
                {
                    if (grid[r, c] == number && r !=row && c != column)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
