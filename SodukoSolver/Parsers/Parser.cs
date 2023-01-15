using SodukoSolver.DataStructures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.Parsers
{
    /// <summary>
    /// Class Parser is in charge of parsing the various representations of the grid to other representations.
    /// </summary>
    internal class Parser
    {
        public Parser()
        {
            /// <summary>
            /// This constructor creates a Parser object.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
        }
        public char[,] ParseString(string stringGrid, int size)
        {
            /// <summary>
            /// This function parses grid represented as string to char matrix.
            /// </summary>
            /// <param>
            /// stringGrid - grid as string.
            /// size - one dimension of the string.
            /// </param>
            /// <returns>
            /// grid as char matrix
            /// </returns>
            char[,] grid = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = stringGrid[i * size + j];
                }
            }
            return grid;
        }
        public int[,] ParseIntString(string stringGrid, int size)
        {
            /// <summary>
            /// This function parses grid represented as string to int matrix.
            /// </summary>
            /// <param>
            /// stringGrid - grid as string.
            /// size - one dimension of the string.
            /// </param>
            /// <returns>
            /// grid as int matrix
            /// </returns>
            int[,] grid = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = stringGrid[i * size + j] - '0';
                }
            }
            return grid;
        }
        public int[,] ConvertDLXListToGrid(List<DancingNode> answer, int size)
        {
            /// <summary>
            /// This function parses grid represented as a solution to the exact cover problem to int matrix.
            /// </summary>
            /// <param>
            /// answer - solution to the exact cover problem.
            /// size - one dimension of the string.
            /// </param>
            /// <returns>
            /// grid as int matrix
            /// </returns>
            /// there is brief explanation inside func
            int[,] result = new int[size, size];

            foreach (DancingNode n in answer)
            {
                DancingNode rcNode = n;
                int min = int.Parse(rcNode.GetColumn().GetName());

                for (DancingNode tmp = n.GetRight(); tmp != n; tmp = tmp.GetRight())
                {
                    int val = int.Parse(tmp.GetColumn().GetName());

                    if (val < min)
                    {
                        min = val;
                        rcNode = tmp;
                    }
                }

                // we get one line of the lines combination for solution and its column
                int ans1 = int.Parse(rcNode.GetColumn().GetName());
                int ans2 = int.Parse(rcNode.GetRight().GetColumn().GetName());
                // we get row and col
                int r = ans1 / size;
                int c = ans1 % size;
                // we get num
                int num = (ans2 % size) + 1;
                result[r, c] = num;
            }

            return result;
        }
    }
}
