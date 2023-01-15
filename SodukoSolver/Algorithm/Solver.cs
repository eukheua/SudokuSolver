using SodukoSolver.DataStructures;
using SodukoSolver.Exceptions;
using SodukoSolver.Parsers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver
{
    /// <summary>
    /// Class Solver is in charge of solving the sudoku grid.
    /// </summary>
    internal class Solver
    {
        public Solver()
        {

        }
        public void Solve(Grid grid)
        {
            /// <summary>
            /// This function is in charge of solving the sudoku grid
            /// </summary>
            /// <param>
            /// grid - an object that represents the sudoku grid \
            /// </param>
            /// <returns>
            /// nothing
            /// </returns>
            int[,] intRepresentedGrid = grid.GetIntGrid();
            CoverMatrix cm = new CoverMatrix(intRepresentedGrid.GetLength(0), intRepresentedGrid);
            int[,] cover = cm.ConvertInCoverMatrix(intRepresentedGrid);
            DLXList dlx = new DLXList(cover);
            if(!dlx.AlgorithmX(0))
            {
                string message = string.Format("Grid is not solveable");
                throw new GridUnsolveableException(message);
            }
            Parser p = new Parser();
            int[,]gridSolved = p.ConvertDLXListToGrid(dlx.result, intRepresentedGrid.GetLength(0));
            grid.ConvertIntToChar(gridSolved);
        }
    }
}
