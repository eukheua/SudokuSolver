using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.DataStructures
{
    /// <summary>
    /// Class CoverMatrix models a cover matrix which will afterwards be transformed to a dlx matrix.
    /// </summary>
    internal class CoverMatrix
    {
        /// <attributes>
        /// size - dimension size of soduku grid.
        /// boxSize - dimension size of a box in the sudoku grid.
        /// minValue - the minimal value on the soduko grid.
        /// maxValue - the maximal value on the soduko grid.
        /// CoverMatrixstartIndex - Starting index for cover matrix.
        /// emptyCell - value for empty cell.
        /// constraints - number of constraints for this cover matrix in this case four:
        /// 1. one value per cell
        /// 2. unique value per row
        /// 3. unique value per column
        /// 4. unique value per box
        /// grid - the sudoku grid
        /// </attributes>
        private int size;
        private int boxSize;
        private int minValue;
        private int maxValue;
        private int CoverMatrixstartIndex;
        private static int emptyCell = 0;
        private static int constraints = 4;
        private int[,] grid;
        public CoverMatrix(int size, int[,] grid)
        {
            /// <summary>
            /// This constructor is in charge of creating a CoverMatrix object.
            /// </summary>
            /// <param>
            /// size - one dimension of the sudoku grid.
            /// grid - the sudoku grid.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            this.size = size;
            this.boxSize = (int)Math.Sqrt(size);
            this.minValue = 1;
            this.maxValue = size;
            this.CoverMatrixstartIndex = 1;
            this.grid = new int[size, size];
            InitGrid(grid);
        }
        private void InitGrid(int[,] grid)
        {
            /// <summary>
            /// This function is in charge initializing the sudoku grid.
            /// </summary>
            /// <param>
            /// grid - the sudoku grid.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    this.grid[i, j] = grid[i, j];
                }
            }
        }
        private int IndexInCoverMatrix(int row, int column, int num)
        {
            /// <summary>
            /// This function is in charge of geting the index in the cover matrix based on the row,column and possible value of a cell in the sudoku grid.
            /// </summary>
            /// <param>
            /// row - the row in the sudoku grid.
            /// column - the column in the sudoku grid.
            /// num - the num in grid which need to be represented.
            /// </param>
            /// <returns>
            /// the index int the cover matrix that was requested.
            /// </returns>
            return (row - 1) * size * size + (column - 1) * size + (num - 1);
        }
        private int[,] CreateCoverMatrix()
        {
            /// <summary>
            /// This function is in charge of creating the cover matrix using the diffrent constraints.
            /// this cover matrix is the initial and basic cover matrix before the values already inserted in the sudoku grid are checked.
            /// the cover matrix will be specified more in the function ConvertInCoverMatrix.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// the cover matrix.
            /// </returns>
            // cover matrix is a matrix of 1 and 0 representing the exact cover algorithm its size is:
            // (size*size*max_value)X(size*size*constraints)
            int[,] coverMatrix = new int[size * size * maxValue, size * size * constraints];

            int header = 0;
            header = CreateCellConstraints(coverMatrix, header);
            header = CreateRowConstraints(coverMatrix, header);
            header = CreateColumnConstraints(coverMatrix, header);
            CreateBoxConstraints(coverMatrix, header);

            return coverMatrix;
        }
        private int CreateBoxConstraints(int[,] matrix, int header)
        {
            /// <summary>
            /// This function is in charge of assining the box constraints representations in the cover matrix.
            /// </summary>
            /// <param>
            /// matrix - the cover matrix
            /// header - the column for a constraint in the cover matrix every constriant has columns that represents him:
            /// sizeXsize of the sudoku grid per constraint.
            /// </param>
            /// <returns>
            /// the column from which the other constraints will continue.
            /// </returns>
            for (int row = CoverMatrixstartIndex; row <= size; row += boxSize)
            {
                for (int column = CoverMatrixstartIndex; column <= size; column += boxSize)
                {
                    for (int n = CoverMatrixstartIndex; n <= size; n++, header++)
                    {
                        for (int rowDelta = 0; rowDelta < boxSize; rowDelta++)
                        {
                            for (int columnDelta = 0; columnDelta < boxSize; columnDelta++)
                            {
                                int index = IndexInCoverMatrix(row + rowDelta, column + columnDelta, n);
                                matrix[index,header] = 1;
                            }
                        }
                    }
                }
            }

            return header;
        }
        private int CreateColumnConstraints(int[,] matrix, int header)
        {
            /// <summary>
            /// This function is in charge of assining the column constraints representations in the cover matrix.
            /// </summary>
            /// <param>
            /// matrix - the cover matrix
            /// header - the column for a constraint in the cover matrix every constriant has columns that represents him:
            /// sizeXsize of the sudoku grid per constraint.
            /// </param>
            /// <returns>
            /// the column from which the other constraints will continue.
            /// </returns>
            for (int column = CoverMatrixstartIndex; column <= size; column++)
            {
                for (int n = CoverMatrixstartIndex; n <= size; n++, header++)
                {
                    for (int row = CoverMatrixstartIndex; row <= size; row++)
                    {
                        int index = IndexInCoverMatrix(row, column, n);
                        matrix[index,header] = 1;
                    }
                }
            }

            return header;
        }
        private int CreateRowConstraints(int[,] matrix, int header)
        {
            /// <summary>
            /// This function is in charge of assining the row constraints representations in the cover matrix.
            /// </summary>
            /// <param>
            /// matrix - the cover matrix
            /// header - the column for a constraint in the cover matrix every constriant has columns that represents him:
            /// sizeXsize of the sudoku grid per constraint.
            /// </param>
            /// <returns>
            /// the column from which the other constraints will continue.
            /// </returns>
            for (int row = CoverMatrixstartIndex; row <= size; row++)
            {
                for (int n = CoverMatrixstartIndex; n <= size; n++, header++)
                {
                    for (int column = CoverMatrixstartIndex; column <= size; column++)
                    {
                        int index = IndexInCoverMatrix(row, column, n);
                        matrix[index,header] = 1;
                    }
                }
            }

            return header;
        }
        private int CreateCellConstraints(int[,] matrix, int header)
        {
            /// <summary>
            /// This function is in charge of assining the cell constraints representations in the cover matrix.
            /// </summary>
            /// <param>
            /// matrix - the cover matrix
            /// header - the column for a constraint in the cover matrix every constriant has columns that represents him:
            /// sizeXsize of the sudoku grid per constraint.
            /// </param>
            /// <returns>
            /// the column from which the other constraints will continue.
            /// </returns>
            for (int row = CoverMatrixstartIndex; row <= size; row++)
            {
                for (int column = CoverMatrixstartIndex; column <= size; column++, header++)
                {
                    for (int n = CoverMatrixstartIndex; n <= size; n++)
                    {
                        int index = IndexInCoverMatrix(row, column, n);
                        matrix[index,header] = 1;
                    }
                }
            }

            return header;
        }
        public int[,] ConvertInCoverMatrix(int[,] grid)
        {
            /// <summary>
            /// This function is in charge of improving the cover matrix by altering some constraints according to the cells already with values in the sudoku grid.
            /// </summary>
            /// <param>
            /// grid - the sudoku grid.
            /// </param>
            /// <returns>
            /// the most accurate cover matrix according to existing circumstances.
            /// </returns>
            int[,] coverMatrix = CreateCoverMatrix();
            // Taking into account the values already entered in Sudoku's grid instance
            for (int row = CoverMatrixstartIndex; row <= size; row++)
            {
                for (int column = CoverMatrixstartIndex; column <= size; column++)
                {
                    int n = grid[row - 1,column - 1];

                    if (n != emptyCell)
                    {
                        for (int num = minValue; num <= maxValue; num++)
                        {
                            if (num != n)
                            {
                                int rowIndex = IndexInCoverMatrix(row, column, num);
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
