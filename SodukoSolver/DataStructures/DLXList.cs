using SodukoSolver.Algorithm;
using System.Collections;
using System.Collections.Generic;

namespace SodukoSolver.DataStructures
{
    internal class DLXList
    {
        private ColumnNode header;
        private List<DancingNode> answer;
        public List<DancingNode> result;
        static int nbColumns;
        public DLXList(int[,] cover)
        {
            header = createDLXList(cover);
            answer = new List<DancingNode>();
        }
        public ColumnNode getHeader() { return header; }
        public void setHeader(ColumnNode header) { this.header = header; }
        private ColumnNode createDLXList(int[,] grid)
        {
            nbColumns = grid.GetLength(1);
            int numOfRows = grid.GetLength(0);
            int numOfColumns = grid.GetLength(1);
            ColumnNode headerNode = new ColumnNode("header");
            List<ColumnNode> columnNodes = new List<ColumnNode>();

            for (int i = 0; i < nbColumns; i++)
            {
                ColumnNode n = new ColumnNode(i + "");
                columnNodes.Add(n);
                headerNode = (ColumnNode)headerNode.linkRight(n);
            }

            headerNode = headerNode.getRight().getColumn();

            for(int i = 0; i < numOfRows; i++)
            {
                DancingNode prev = null;

                for (int j = 0; j < numOfColumns; j++)
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

            headerNode.setSize(numOfColumns);

            return headerNode;
        }
        private class State
        {
            public int k;
            public ColumnNode c;

            public State(int k, ColumnNode c)
            {
                this.k = k;
                this.c = c;
            }
        }
        public bool process(int k)
        {
            if (header.getRight() == header)
            {
                // End of Algorithm X
                // Result is copied in a result list
                result = new List<DancingNode>(answer);
                return true;
            }
            else
            {
                // we choose column c
                ColumnNode c = selectColumnNodeHeuristic();
                c.cover();
                for (DancingNode r = c.getBottom(); r != c; r = r.getBottom())
                {
                    // We add r line to partial solution
                    answer.Add(r);

                    // We cover columns
                    for (DancingNode j = r.getRight(); j != r; j = j.getRight())
                    {
                        j.getColumn().cover();
                    }

                    // recursive call to leverl k + 1
                    if(process(k + 1))
                    {
                        return true;
                    }

                    // We go back
                    r = answer.ElementAt(answer.Count - 1);
                    answer.RemoveAt(answer.Count - 1);
                    c = r.getColumn();

                    // We uncover columns
                    for (DancingNode j = r.getLeft(); j != r; j = j.getLeft())
                    {
                        j.getColumn().uncover();
                    }
                }

                c.uncover();
            }
            return false;

        }
        ColumnNode selectColumnNodeHeuristic()
        {
            int min = int.MaxValue;
            ColumnNode minColumn = null;
            for (ColumnNode c = (ColumnNode)header.getRight(); c != header; c = (ColumnNode)c.getRight())
            {
                if(c.getSize()<min)
                {
                    min = c.getSize();
                    minColumn = c;
                }
                
            }
            return minColumn;
        }

    }
}
