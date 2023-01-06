using SodukoSolver.DataStructures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver
{
    internal class Parser
    {
        public Parser() { } 
        public char[,] parseString(string stringGrid,int size)
        {
            char[,] grid = new char[size, size];
            for(int i=0;i<size;i++)
            {
                for (int j = 0;j < size; j++)
                {
                    grid[i, j] = stringGrid[i * size + j];
                }
            }
            return grid;
        }
        public int[,] parseIntString(string stringGrid, int size)
        {
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
        public int[,] convertDLXListToGrid(List<DancingNode> answer,int size)
        {
            int[,] result = new int[size,size];

            foreach (DancingNode n in answer)
            {
                DancingNode rcNode = n;
                int min = int.Parse(rcNode.getColumn().getName());

                for (DancingNode tmp = n.getRight(); tmp != n; tmp = tmp.getRight())
                {
                    int val = int.Parse(tmp.getColumn().getName());

                    if (val < min)
                    {
                        min = val;
                        rcNode = tmp;
                    }
                }

                // we get line and column
                    int ans1 = int.Parse(rcNode.getColumn().getName());
                    int ans2 = int.Parse(rcNode.getRight().getColumn().getName());
                    int r = ans1 / size;
                    int c = ans1 % size;
                    // and the affected value
                    int num = (ans2 % size) + 1;
                    // we affect that on the result grid
                    result[r,c] = num;
            }

            return result;
        }
    }
}
