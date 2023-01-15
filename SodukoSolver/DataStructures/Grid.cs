namespace SodukoSolver
{
    /// <summary>
    /// Class Grid models a sudoku grid.
    /// </summary>
    internal class Grid
    {
        /// /// <attributes>
        /// grid - the sudoku grid.
        /// </attributes>
        private char[,]? grid;
        public Grid(char[,] grid)
        {
            /// <summary>
            /// This Constructor creates a Grid object.
            /// </summary>
            /// <param>
            /// grid - a sudoku grid.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            UpdateGrid(grid);
        }

        public Grid()
        {
            /// <summary>
            /// This Constructor creates a Grid object.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
        }

        public void UpdateGrid(char[,] grid) 
        {
            /// <summary>
            /// This function updates the grid attribute.
            /// </summary>
            /// <param>
            /// grid - a sudoku grid.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            this.grid = (char[,])grid.Clone();
        }
        public int[,] GetIntGrid()
        {
            /// <summary>
            /// This function converts the char based sudoku grid to numbers based grid.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            ///  numbers based grid.
            /// </returns>
            int[,] grid = new int[GetSize(),GetSize()];
            for(int i = 0; i < GetSize(); i++)
            {
                for (int j = 0; j < GetSize(); j++)
                {
                    grid[i, j] = this.grid![i, j] - '0';
                }
            }
            return grid;
        }
        public void ConvertIntToChar(int[,] grid)
        {
            /// <summary>
            /// This function converts the numbers based sudoku grid to char based grid and updates the grid attribute.
            /// </summary>
            /// <param>
            /// grid - numbers based grid.
            /// </param>
            /// <returns>
            /// </returns>
            for (int i = 0; i < GetSize(); i++)
            {
                for (int j = 0; j < GetSize(); j++)
                {
                    this.grid![i, j] = (char)(grid[i, j] + '0');
                }
            }
        }
        public string ConvertGridToString()
        {
            /// <summary>
            /// This function converts the chars based sudoku grid to a string representing the grid.
            /// </summary>
            /// <param>
            /// grid - numbers based grid.
            /// </param>
            /// <returns>
            /// string representing the grid.
            /// </returns>
            string stringGrid = "";
            for (int i = 0; i < GetSize(); i++)
            {
                for (int j = 0; j < GetSize(); j++)
                {
                    stringGrid += grid![i, j];
                }
            }
            return stringGrid;
        }
        public int GetSize()
        {
            /// <summary>
            /// This function returns the size of one dimension of the grid.
            /// </summary>
            /// <param>
            /// 
            /// </param>
            /// <returns>
            /// size of one dimension of the grid.
            /// </returns>
            return grid!.GetLength(0);
        }
        public char[,] GetGrid()
        {
            /// <summary>
            /// This function returns the grid attribute.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// the grid attribute.
            /// </returns>
            return grid!;
        }
        public char GetCell(int i, int j)
        {
            /// <summary>
            /// This function returns a cell value in row i and column j in the grid.
            /// </summary>
            /// <param>
            /// i - row
            /// j - column
            /// </param>
            /// <returns>
            /// cell value in row i and column j in the grid.
            /// </returns>
            return grid![i, j];  
        }
        public void SetCell(char value,int i,int j)
        {
            /// <summary>
            /// This function sets a cell value in row i and column j in the grid.
            /// </summary>
            /// <param>
            /// value - the value to be assigned
            /// i - row
            /// j - column
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            grid![i, j] = value;
        }
        public void Show()
        {
            /// <summary>
            /// This function prints the gird in a basic representation.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            for (int i = 0; i < grid!.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j]+",");
                }
                Console.WriteLine();
            }
        }
        public void ShowInt()
        {
            /// <summary>
            /// This function prints the gird with numbers values in a basic representation.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            int[,] grid = GetIntGrid();
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j] + ",");
                }
                Console.WriteLine();
            }
        }
        public string PrintInFormat()
        {
            /// <summary>
            /// This function prints the gird in a graphically appealing way.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            int sqrtSize = (int)Math.Sqrt(GetSize());
            string stringTop = Config.StringTop1On1;
            string stringMiddleOne = Config.StringMiddleOne1On1;
            string stringMiddleTwo = Config.StringMiddleTwo1On1;
            string stringBottom= Config.StringBottom1On1;
            if (GetSize() == 4)
            {
                stringTop = Config.StringTop4On4;
                stringMiddleOne = Config.StringMiddleOne4On4;
                stringMiddleTwo = Config.StringMiddleTwo4On4;
                stringBottom = Config.StringBottom4On4;
            }
            if (GetSize() == 9)
            {
                stringTop = Config.StringTop9On9;
                stringMiddleOne = Config.StringMiddleOne9On9;
                stringMiddleTwo = Config.StringMiddleTwo9On9;
                stringBottom = Config.StringBottom9On9;
            }
            if (GetSize() == 16 )
            {
                stringTop = Config.StringTop16On16;
                stringMiddleOne = Config.StringMiddle16On16;
                stringMiddleTwo = Config.StringMiddleTwo16On16;
                stringBottom = Config.StringBottom16O16;
            }
            if (GetSize() == 25)
            {
                stringTop = Config.StringTop25On25;
                stringMiddleOne = Config.StringMiddle25On25;
                stringMiddleTwo = Config.StringMiddleTwo25On25;
                stringBottom = Config.StringBottom25On25;
            }
            var a = stringTop;
            for (int i = 0, j = 0, k, l, m; j < sqrtSize; j++)
            {
                for (k = 0; k < sqrtSize; k++)
                {
                    for (l = 0; l < sqrtSize; l++)
                    {
                        for (m = 0; m < sqrtSize;)
                        {
                            a += " " + grid![i / GetSize(), i % GetSize()] + (m++ < sqrtSize - 1 ? " │" : " ║");
                            i++;
                        }
                    }
                    a += i < Math.Pow(GetSize(),2) ? (k < sqrtSize-1 ? stringMiddleOne : stringMiddleTwo)
                                : stringBottom;
                }
            }
            return a.Replace("+", Config.ReplaceEqualSign).Replace("-", Config.ReplaceHyphenSign).Replace("0", " ");
        }

    }
}
