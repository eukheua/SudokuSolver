using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.DataStructures
{
    internal class ColumnNode:DancingNode
    {
        private int size;
        private string name;
        public ColumnNode(string n):base()
        {
            size = 0;
            name = n;
            this.setColumn(this);
        }
        public int getSize() { return size; }   
        public string getName() { return name; } 
        public void setSize(int size) { this.size = size;}
        public void setName(string name) { this.name = name; }
        public void cover()
        {
            removeLeftRight();

            for (DancingNode i = this.getBottom(); i != this; i = i.getBottom())
            {
                for (DancingNode j = i.getRight(); j != i; j = j.getRight())
                {
                    j.removeTopBottom();
                    j.getColumn().size--;
                }
            }
        }

        public void uncover()
        {
            for (DancingNode i = this.getTop(); i != this; i = i.getTop())
            {
                for (DancingNode j = i.getLeft(); j != i; j = j.getLeft())
                {
                    j.getColumn().size--;
                    j.reinsertTopBottom();
                }
            }

            reinsertLeftRight();
        }
    }
}
