using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.DataStructures
{
    /// <summary>
    /// Class DancingNode models a node in the dlx matrix.
    /// </summary>
    internal class DancingNode
    {
        /// <attributes>
        /// left - node left to this dancing node.
        /// right - node right to this dancing node.
        /// top - node above this dancing node.
        /// bottom - node bellow this dancing node.
        /// column - column node of this dancing node.
        /// </attributes>
        private DancingNode left, right, top, bottom;
        private ColumnNode? column;
        public DancingNode()
        {
            /// <summary>
            /// This Constructor creates a DancingNode object.
            /// </summary>
            /// <param>
            /// None
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            left = right = top = bottom = this;
            column = null;
        }
        public DancingNode(ColumnNode c): this ()
        {
            /// <summary>
            /// This Constructor creates a DancingNode object and initiates its ColumnNode.
            /// </summary>
            /// <param>
            /// None
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            column = c;
        }
        public DancingNode GetLeft()
        {
            /// <summary>
            /// This function returns the dancing node left to the current dancing node in the dlx matrix.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// the dancing node left to the current dancing node in the dlx matrix.
            /// </returns>
            return left; 
        }
        public DancingNode GetRight()
        {
            /// <summary>
            /// This function returns the dancing node right to the current dancing node in the dlx matrix.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// the dancing node right to the current dancing node in the dlx matrix.
            /// </returns>
            return right; 
        }
        public DancingNode GetTop()
        {
            /// <summary>
            /// This function returns the dancing node up to the current dancing node in the dlx matrix.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// the dancing node up to the current dancing node in the dlx matrix.
            /// </returns>
            return top; 
        }
        public DancingNode GetBottom()
        {
            /// <summary>
            /// This function returns the dancing node below the current dancing node in the dlx matrix.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// the dancing node below the current dancing node in the dlx matrix.
            /// </returns>
            return bottom; 
        }
        public ColumnNode GetColumn()
        {
            /// <summary>
            /// This function returns the column node of this dancing node in the dlx matrix.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// column node of this dancing node in the dlx matrix.
            /// </returns>
            return column!; 
        }
        public void SetLeft(DancingNode dancingNode)
        {
            /// <summary>
            /// This function sets the dancing node left to the current dancing node in the dlx matrix.
            /// </summary>
            /// <param>
            /// dancingNode - the new dancing node that will be assigned to the left of this one.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            this.left = dancingNode;
        }
        public void SetRight(DancingNode dancingNode)
        {
            /// <summary>
            /// This function sets the dancing node right to the current dancing node in the dlx matrix.
            /// </summary>
            /// <param>
            /// dancingNode - the new dancing node that will be assigned to the right of this one.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            this.right = dancingNode; 
        }
        public void SetTop(DancingNode dancingNode)
        {
            /// <summary>
            /// This function sets the dancing node above the current dancing node in the dlx matrix.
            /// </summary>
            /// <param>
            /// dancingNode - the new dancing node that will be assigned above this one.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            this.top = dancingNode; 
        }
        public void SetBottom(DancingNode dancingNode)
        {
            /// <summary>
            /// This function sets the dancing node bellow the current dancing node in the dlx matrix.
            /// </summary>
            /// <param>
            /// dancingNode - the new dancing node that will be assigned bellow this one.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            this.bottom = dancingNode;
        }
        public void SetColumn(ColumnNode columnNode) 
        {
            /// <summary>
            /// This function sets the column node of this dancing node in the dlx matrix.
            /// </summary>
            /// <param>
            /// columnNode -  the new column node that will be assigned to the bellow this one.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            this.column = columnNode; 
        }
        public DancingNode LinkDown(DancingNode node)
        {
            /// <summary>
            /// This function links another dancing node below this dancing node.
            /// </summary>
            /// <param>
            /// node -  the new danncing node that will be linked bellow this one.
            /// </param>
            /// <returns>
            /// the linked node
            /// </returns>
            node.bottom = bottom;
            node.bottom.top = node;
            node.top = this;
            bottom = node;
            return node;
        }

        public DancingNode LinkRight(DancingNode node)
        {
            /// <summary>
            /// This function links another dancing node to the right of this dancing node.
            /// </summary>
            /// <param>
            /// node -  the new danncing node that will be to the right of this dancing node.
            /// </param>
            /// <returns>
            /// the linked node
            /// </returns>
            node.right = right;
            node.right.left = node;
            node.left = this;
            right = node;
            return node;
        }

        public void RemoveLeftRight()
        {
            /// <summary>
            /// This function disconnects the dancing node from its left and right attached dancing nodes.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            left.right = right;
            right.left = left;
        }

        public void ReinsertLeftRight()
        {
            /// <summary>
            /// This function reconnects the dancing node with its left and right attached dancing nodes.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            left.right = this;
            right.left = this;
        }

        public void RemoveTopBottom()
        {
            /// <summary>
            /// This function disconnects the dancing node from its above and bellow attached dancing nodes.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            top.bottom = bottom;
            bottom.top = top;
        }

        public void ReinsertTopBottom()
        {
            /// <summary>
            /// This function reconnects the dancing node from its above and bellow attached dancing nodes.
            /// </summary>
            /// <param>
            /// None.
            /// </param>
            /// <returns>
            /// Nothing.
            /// </returns>
            top.bottom = this;
            bottom.top = this;
        }
    }
}
