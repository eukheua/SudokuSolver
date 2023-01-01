using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver
{
    internal class Solver
    {
        public Solver()
        {

        }
        public bool solve(Grid grid,int row,int column)
        {
            if (row == grid.getGrid().GetLength(0))
                return true;
            else if (column == grid.getGrid().GetLength(0))
            {
                return solve(grid, row + 1, 0);
            }
            else if (grid.getCell(row, column) != '0')
            {
                return solve(grid, row, column + 1);
            }
            else
            {
                for (int i=1; i <=grid.getSize(); i++)
                {
                    char value = (char)((char)i + '0');
                    if(Validator.validate(grid.getGrid(),row,column, value))
                    {
                        grid.setCell(value, row, column);
                        if (solve(grid,row,column+1))
                        {
                            return true;
                        }
                        grid.setCell('0', row, column);
                    }
                }
                return false;
            }

        }
    }
}
