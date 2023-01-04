using System.Collections;
using System.Collections.Generic;

namespace SodukoSolver.DataStructures
{
    internal class DLXList
    {
        private ColumnNode header;
        private List<DancingNode> answer;
        private List<DancingNode> result;
        static int nbColumns;
        public DLXList(int[,] cover)
        {
            header = createDLXList(cover);
        }
        private ColumnNode createDLXList(int[,] grid)
        {
            nbColumns = grid.GetLength(1);
            ColumnNode headerNode = new ColumnNode("header");
            List<ColumnNode> columnNodes = new List<ColumnNode>();

            for (int i = 0; i < nbColumns; i++)
            {
                ColumnNode n = new ColumnNode(i + "");
                columnNodes.Add(n);
                headerNode = (ColumnNode)headerNode.linkRight(n);
            }

            headerNode = headerNode.getRight().getColumn();

            for(int i = 0; i < grid.GetLength(0); i++)
            {
                DancingNode prev = null;

                for (int j = 0; j < nbColumns; j++)
                {
                    if (grid[i,j] == 1)
                    {
                        ColumnNode col = columnNodes[j];
                        DancingNode newNode = new DancingNode(col);

                        if (prev == null)
                        {
                            prev = newNode;
                        }
                        col.getTop().linkDown(newNode);
                        prev = prev.linkRight(newNode);
                        col.setSize(col.getSize()+1);
                    }
                }
            }

            headerNode.setSize(nbColumns);

            return headerNode;
        }
    }
}
