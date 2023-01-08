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
        public string s()
        {
            int sqrtSize = (int)Math.Sqrt(getSize());
            string stringTop = Config.stringTop1On1;
            string stringMiddleOne = Config.stringMiddleOne1On1;
            string stringMiddleTwo = Config.stringMiddleTwo1On1;
            string stringBottom= Config.stringBottom1On1;
            if (getSize() == 4)
            {
                stringTop = Config.stringTop4On4;
                stringMiddleOne = Config.stringMiddleOne4On4;
                stringMiddleTwo = Config.stringMiddleTwo4On4;
                stringBottom = Config.stringBottom4On4;
            }
            if (getSize() == 9)
            {
                stringTop = Config.stringTop9On9;
                stringMiddleOne = Config.stringMiddleOne9On9;
                stringMiddleTwo = Config.stringMiddleTwo9On9;
                stringBottom = Config.stringBottom9On9;
            }
            if (getSize() == 16 )
            {
                stringTop = Config.stringTop16On16;
                stringMiddleOne = Config.stringMiddle16On16;
                stringMiddleTwo = Config.stringMiddleTwo16On16;
                stringBottom = Config.stringBottom16O16;
            }
            if (getSize() == 25)
            {
                stringTop = Config.stringTop25On25;
                stringMiddleOne = Config.stringMiddle25On25;
                stringMiddleTwo = Config.stringMiddleTwo25On25;
                stringBottom = Config.stringBottom25On25;
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
                            a += " " + grid[i / getSize(), i % getSize()] + (m++ < sqrtSize - 1 ? " │" : " ║");
                            i++;
                        }
                    }
                    a += i < Math.Pow(getSize(),2) ? (k < sqrtSize-1 ? stringMiddleOne : stringMiddleTwo)
                                : stringBottom;
                }
            }
            return a.Replace("+", Config.replaceEqualSign).Replace("-", Config.replaceHyphenSign).Replace("0", " ");
        }

    }
}
