using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.DataStructures
{
    internal class CoverMatrix
    {
        private int size;
        private int box_size;
        private int min_value;
        private int max_value;
        // Starting index for cover matrix
        private int cover_matrix_start_index;
        private static int empty_cell = 0;
        // 4 constraints : cell, line, column, boxes
        private static int constraints = 4;
        private int[,] grid;
        private int[,] solvedGrid;
        public CoverMatrix(int size, int[,] grid)
        {
            this.size = size;
            this.box_size = (int)Math.Sqrt(size);
            this.min_value = 1;
            this.max_value = size;
            this.cover_matrix_start_index = 1;
            this.grid = new int[size, size];
            init_grid(grid);
        }
        private void init_grid(int[,] grid)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    this.grid[i, j] = grid[i, j];
                }
            }
        }
        // cover matrix is a matrix of 1 and 0 representing the exact cover algorithm its size is:
        // (size*size*max_value)X(size*size*constraints)
        private int indexInCoverMatrix(int row, int column, int num)
        {
            return (row - 1) * size * size + (column - 1) * size + (num - 1);
        }
        // Building of an empty cover matrix
        private int[,] createCoverMatrix()
        {
            int[,] coverMatrix = new int[size * size * max_value, size * size * constraints];

            int header = 0;
            header = createCellConstraints(coverMatrix, header);
            header = createRowConstraints(coverMatrix, header);
            header = createColumnConstraints(coverMatrix, header);
            createBoxConstraints(coverMatrix, header);

            return coverMatrix;
        }
        private int createBoxConstraints(int[,] matrix, int header)
        {
            for (int row = cover_matrix_start_index; row <= size; row += box_size)
            {
                for (int column = cover_matrix_start_index; column <= size; column += box_size)
                {
                    for (int n = cover_matrix_start_index; n <= size; n++, header++)
                    {
                        for (int rowDelta = 0; rowDelta < box_size; rowDelta++)
                        {
                            for (int columnDelta = 0; columnDelta < box_size; columnDelta++)
                            {
                                int index = indexInCoverMatrix(row + rowDelta, column + columnDelta, n);
                                matrix[index,header] = 1;
                            }
                        }
                    }
                }
            }

            return header;
        }
        private int createColumnConstraints(int[,] matrix, int header)
        {
            for (int column = cover_matrix_start_index; column <= size; column++)
            {
                for (int n = cover_matrix_start_index; n <= size; n++, header++)
                {
                    for (int row = cover_matrix_start_index; row <= size; row++)
                    {
                        int index = indexInCoverMatrix(row, column, n);
                        matrix[index,header] = 1;
                    }
                }
            }

            return header;
        }
        private int createRowConstraints(int[,] matrix, int header)
        {
            for (int row = cover_matrix_start_index; row <= size; row++)
            {
                for (int n = cover_matrix_start_index; n <= size; n++, header++)
                {
                    for (int column = cover_matrix_start_index; column <= size; column++)
                    {
                        int index = indexInCoverMatrix(row, column, n);
                        matrix[index,header] = 1;
                    }
                }
            }

            return header;
        }
        private int createCellConstraints(int[,] matrix, int header)
        {
            for (int row = cover_matrix_start_index; row <= size; row++)
            {
                for (int column = cover_matrix_start_index; column <= size; column++, header++)
                {
                    for (int n = cover_matrix_start_index; n <= size; n++)
                    {
                        int index = indexInCoverMatrix(row, column, n);
                        matrix[index,header] = 1;
                    }
                }
            }

            return header;
        }
        public int[,] convertInCoverMatrix(int[,] grid)
        {
            int[,] coverMatrix = createCoverMatrix();
            // Taking into account the values already entered in Sudoku's grid instance
            for (int row = cover_matrix_start_index; row <= size; row++)
            {
                for (int column = cover_matrix_start_index; column <= size; column++)
                {
                    int n = grid[row - 1,column - 1];

                    if (n != empty_cell)
                    {
                        for (int num = min_value; num <= max_value; num++)
                        {
                            if (num != n)
                            {
                                int rowIndex = indexInCoverMatrix(row, column, num);
                                int numColumns = coverMatrix.GetLength(1);
                                int[] oneDCoverMatrix = new int[numColumns];
                                for (int i = 0; i < numColumns; i++)
                                {
                                    oneDCoverMatrix[i] = coverMatrix[rowIndex, i];
                                }
                                Array.Fill(oneDCoverMatrix, 0);
                                for (int i = 0; i < numColumns; i++)
                                {
                                    coverMatrix[rowIndex, i] = oneDCoverMatrix[i];
                                }
                            }
                        }
                    }
                }
            }

            return coverMatrix;
        }
    }
}
