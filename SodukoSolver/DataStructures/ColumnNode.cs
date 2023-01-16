using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.DataStructures
{
    /// <summary>
    /// Class ColumnNode models a column node in the dlx matrix.
    /// </summary>
    public class ColumnNode:DancingNode
    {
        /// <attributes>
        /// size - amount of dancing nodes under this column node.
        /// name - the column index of this column node in the dlx matrix.
        /// </attributes>
        private int size;
        private string name;
        public ColumnNode(string name):base()
        {
            /// <summary>
            /// This constructor is in charge of creating a ColumnNode object.
            /// </summary>
            /// <param>
            /// name - the name of the column which is its index.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            this.size = 0;
            this.name = name;
            this.SetColumn(this);
        }
        public int GetSize()
        {
            /// <summary>
            /// This function returns the amount of nodes under this column in the dlx matrix.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// amount of nodes under this column is the dlx matrix.
            /// </returns>
            return size; 
        }   
        public string GetName()
        {
            /// <summary>
            /// This function returns the name of the column node (its index)
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// the name of the column node (its index).
            /// </returns>
            return name; 
        } 
        public void SetSize(int size)
        {
            /// <summary>
            /// This function sets the amount of nodes under this column in the dlx matrix.
            /// </summary>
            /// <param>
            /// size - the new amount of nodes under this column node.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            this.size = size;
        }
        public void SetName(string name) 
        {
            /// <summary>
            /// This function sets the name of the column node (its index).
            /// </summary>
            /// <param>
            /// name - the new index of the column node.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            this.name = name; 
        }
        public void Cover()
        {
            /// <summary>
            /// This function covers/deletes a column node from the dlx matrix as a stage in finding solution to the exact cover problem.
            /// </summary>
            /// <param>
            /// None
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            RemoveLeftRight();

            for (DancingNode i = this.GetBottom(); i != this; i = i.GetBottom())
            {
                for (DancingNode j = i.GetRight(); j != i; j = j.GetRight())
                {
                    j.RemoveTopBottom();
                    j.GetColumn().size--;
                }
            }
            this.size--;
        }

        public void Uncover()
        {
            /// <summary>
            /// This function uncovers/restores a column node from the dlx matrix as a stage in finding solution to the exact cover problem.
            /// </summary>
            /// <param>
            /// None
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            for (DancingNode i = this.GetTop(); i != this; i = i.GetTop())
            {
                for (DancingNode j = i.GetLeft(); j != i; j = j.GetLeft())
                {
                    j.GetColumn().size++;
                    j.ReinsertTopBottom();
                }
            }

            ReinsertLeftRight();
            this.size++;
        }
    }
}
