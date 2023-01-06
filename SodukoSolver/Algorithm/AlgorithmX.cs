using SodukoSolver.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.Algorithm
{
    internal class AlgorithmX
    {
        private List<DancingNode> answer;
        private List<DancingNode> result;
        DLXList DancingLinksList;
        public AlgorithmX(DLXList DancingList)
        {
            DancingLinksList = DancingList;
            answer = new List<DancingNode>();
        }
        public List<DancingNode> getResult() { return result; }
        private void process(int k)
        {
            if (DancingLinksList.getHeader().getRight() == DancingLinksList.getHeader())
            {
                // End of Algorithm X
                // Result is copied in a result list
                result = new List<DancingNode>(answer);
            }
            else
            {
                // we choose column c
                ColumnNode c = (ColumnNode)DancingLinksList.getHeader().getRight();
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
                    process(k + 1);

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

        }
    }
}
