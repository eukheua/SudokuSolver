using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.DataStructures
{
    internal class DancingNode
    {
        private DancingNode left, right, top, bottom;
        private ColumnNode? column;
        public DancingNode()
        {
            left = right = top = bottom = this;
            column = null;
        }
        public DancingNode(ColumnNode c)
        {
            left = right = top = bottom = this;
            column = c;
        }
        public DancingNode getLeft() { return left; }
        public DancingNode getRight() { return right; }
        public DancingNode getTop() { return top; }
        public DancingNode getBottom() { return bottom; }
        public ColumnNode getColumn() { return column; }
        public void setLeft(DancingNode dancingNode) { this.left = dancingNode; }
        public void setRight(DancingNode dancingNode) { this.right = dancingNode; }
        public void setTop(DancingNode dancingNode) { this.top = dancingNode; }
        public void setBottom(DancingNode dancingNode) {this.bottom = dancingNode;}
        public void setColumn(ColumnNode columnNode) { this.column = columnNode; }
        public DancingNode linkDown(DancingNode node)
        {
            node.bottom = bottom;
            node.bottom.top = node;
            node.top = this;
            bottom = node;
            return node;
        }

        public DancingNode linkRight(DancingNode node)
        {
            node.right = right;
            node.right.left = node;
            node.left = this;
            right = node;
            return node;
        }

        public void removeLeftRight()
        {
            left.right = right;
            right.left = left;
        }

        public void reinsertLeftRight()
        {
            left.right = this;
            right.left = this;
        }

        public void removeTopBottom()
        {
            top.bottom = bottom;
            bottom.top = top;
        }

        public void reinsertTopBottom()
        {
            top.bottom = this;
            bottom.top = this;
        }
    }
}
