using System.Collections;
using System.Collections.Generic;

namespace SodukoSolver.DataStructures
{
    /// <summary>
    /// Class DLXList models a dlx cover matrix.
    /// </summary>
    internal class DLXList
    {
        /// <attributes>
        /// header - the header node from which all the dlx matrix can be accessed.
        /// answer - A stack that represents the ever changing dlx matrix until all column nodes fill the exact cover circumstances
        /// result - the dlx cover matrix solution represented in a list that after it will be parsed back to regular sudoku grid will have the solution to it.
        /// nbColumns - number of column nodes.
        /// </attributes>
        private ColumnNode header;
        private Stack<DancingNode> answer;
        public List<DancingNode>? result;
        static int nbColumns;
        public DLXList(int[,] cover)
        {
            /// <summary>
            /// This Constructor creates a DLXList object.
            /// </summary>
            /// <param>
            /// None
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            header = createDLXList(cover);
            answer = new Stack<DancingNode>();
        }
        public ColumnNode getHeader()
        {
            /// <summary>
            /// This function returns the header node of the dlx cover matrix.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// the header node of the dlx cover matrix.
            /// </returns>
            return header;
        }
        public void setHeader(ColumnNode header)
        {
            /// <summary>
            /// This function sets the header node of the dlx cover matrix.
            /// </summary>
            /// <param>
            /// header - the new header to be assigned.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            this.header = header; 
        }
        private ColumnNode createDLXList(int[,] grid)
        {
            /// <summary>
            /// This function creates the dlx cover matrix
            /// </summary>
            /// <param>
            /// grid - the cover matrix with represented as int matrix
            /// </param>
            /// <returns>
            /// The dlx cover matrix.
            /// </returns>
            nbColumns = grid.GetLength(1);
            int numOfRows = grid.GetLength(0);
            int numOfColumns = grid.GetLength(1);
            ColumnNode headerNode = new ColumnNode("header");
            List<ColumnNode> columnNodes = new List<ColumnNode>();

            for (int i = 0; i < nbColumns; i++)
            {
                ColumnNode n = new ColumnNode(i + "");
                columnNodes.Add(n);
                headerNode = (ColumnNode)headerNode.LinkRight(n);
            }

            headerNode = headerNode.GetRight().GetColumn();

            for(int i = 0; i < numOfRows; i++)
            {
                DancingNode? prev = null;

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
                        col.GetTop().LinkDown(newNode);
                        prev = prev.LinkRight(newNode);
                        col.SetSize(col.GetSize()+1);
                    }
                }
            }

            headerNode.SetSize(numOfColumns);

            return headerNode;
        }
        public bool AlgorithmX(int k)
        {
            /// <summary>
            /// This function applies the algorithm x using the dlx matrix to solve the exact cover problem.
            /// </summary>
            /// <param>
            /// k - number of columns upholding to the exact cover problem so far.
            /// </param>
            /// <returns>
            /// If a solution was founded
            /// </returns>
            /// Due to the importance of the algorithm in my project i inserted some comments to explain its mechanism. 
            if (header.GetRight() == header)
            {
                // End of Algorithm X
                // Result is copied in a result list
                result = new List<DancingNode>(answer);
                return true;
            }
            else
            {
                // we choose column c
                ColumnNode c = SelectColumnNodeHeuristic();
                c.Cover();
                for (DancingNode r = c.GetBottom(); r != c; r = r.GetBottom())
                {
                    // We add r line to partial solution
                    answer.Push(r);

                    // We cover columns
                    for (DancingNode j = r.GetRight(); j != r; j = j.GetRight())
                    {
                        j.GetColumn().Cover();
                    }

                    // recursive call to leverl k + 1
                    if(AlgorithmX(k + 1))
                    {
                        return true;
                    }

                    // We go back
                    r =answer.Pop();
                    c = r.GetColumn();

                    // We uncover columns
                    for (DancingNode j = r.GetLeft(); j != r; j = j.GetLeft())
                    {
                        j.GetColumn().Uncover();
                    }
                }

                c.Uncover();
            }
            return false;

        }
        ColumnNode SelectColumnNodeHeuristic()
        {
            /// <summary>
            /// This function selects the best next column to check.
            /// The best next column is the column with the least amount of nodes under it.
            /// By choosing good heuristics we avoid high runtime. 
            /// </summary>
            /// <param>
            /// 
            /// </param>
            /// <returns>
            /// the best next column node.
            /// </returns>
            int min = int.MaxValue;
            ColumnNode? minColumn = null;
            for (ColumnNode c = (ColumnNode)header.GetRight(); c != header; c = (ColumnNode)c.GetRight())
            {
                if(c.GetSize()<min)
                {
                    min = c.GetSize();
                    minColumn = c;
                }
                
            }
            return minColumn!;
        }

    }
}
