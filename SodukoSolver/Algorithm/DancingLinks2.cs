using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoSolver.Algorithm
{
    internal class DancingLinks2
    {
        private class Node
        {
            public int row;
            public Column column;
            public Node left;
            public Node right;
            public Node up;
            public Node down;
        }

        private class Column : Node
        {
            public int size;
            public Column(Node node)
            {
                this.up = node;
                this.down = node;
                this.left = node;
                this.right = node;
            }
        }

        private Node root;
        private List<Node> nodes;
        private List<Column> columns;

        public DancingLinks2(int[,] matrix)
        {
            // Initialize the dancing links data structure from the given matrix
            this.nodes = new List<Node>();
            this.columns = new List<Column>();
            this.root = new Node();
            Node prev = this.root;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Node node = new Node();
                node.column = new Column(node);
                this.columns.Add(node.column);
                node.left = prev;
                node.right = this.root;
                prev.right = node;
                prev = node;
            }
            this.root.left = prev;
            for (int i = 0; i < matrix.Length; i++)
            {
                Node prevNode = null;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 1)
                    {
                        Node node = new Node();
                        node.row = i;
                        node.column = this.columns[j];
                        if (prevNode == null)
                        {
                            node.left = node;
                            node.right = node;
                        }
                        else
                        {
                            node.left = prevNode;
                            node.right = prevNode.right;
                            prevNode.right.left = node;
                            prevNode.right = node;
                        }
                        node.up = this.columns[j].up;
                        node.down = this.columns[j];
                        node.up.down = node;
                        node.down.up = node;
                        prevNode = node;
                        this.nodes.Add(node);
                    }
                }
            }
        }
        public IEnumerable<int[]> Search(int k, int[] solution)
        {
            if (this.root.right == this.root)
            {
                yield return solution;
                yield break;
            }

            Column c = this.root.right as Column;
            this.Cover(c);
            foreach (Node r in this.ChooseRow(c))
            {
                int[] newSolution = new int[solution.Length + 1];
                Array.Copy(solution, newSolution, solution.Length);
                newSolution[k] = r.row;
                foreach (int[] s in this.Search(k + 1, newSolution))
                {
                    yield return s;
                }
            }
            this.Uncover(c);
        }
        private void Cover(Column c)
        {
            c.right.left = c.left;
            c.left.right = c.right;
            foreach (Node i in this.IterDown(c))
            {
                foreach (Node j in this.IterRight(i))
                {
                    j.down.up = j.up;
                    j.up.down = j.down;
                    j.column.size--;
                }
            }
        }

        private void Uncover(Column c)
        {
            foreach (Node i in this.IterUp(c))
            {
                foreach (Node j in this.IterLeft(i))
                {
                    j.column.size++;
                    j.down.up = j;
                    j.up.down = j;
                }
            }
            c.right.left = c;
            c.left.right = c;
        }

        private IEnumerable<Node> ChooseRow(Column c)
        {
            // Choose a row using the minimum remaining value (MRV) heuristic
            int minSize = int.MaxValue;
            List<Node> minRows = new List<Node>();
            foreach (Node r in this.IterDown(c))
            {
                if (r.column.size < minSize)
                {
                    minSize = r.column.size;
                    minRows = new List<Node> { r };
                }
                else if (r.column.size == minSize)
                {
                    minRows.Add(r);
                }
            }
            return minRows;
        }

        private IEnumerable<Node> IterRight(Node node)
        {
            Node current = node;
            do
            {
                current = current.right;
                yield return current;
            } while (current != node);
        }

        private IEnumerable<Node> IterLeft(Node node)
        {
            Node current = node;
            do
            {
                current = current.left;
                yield return current;
            } while (current != node);
        }

        private IEnumerable<Node> IterUp(Node node)
        {
            Node current = node;
            do
            {
                current = current.up;
                yield return current;
            } while (current != node);
        }

        private IEnumerable<Node> IterDown(Node node)
        {
            Node current = node;
            do
            {
                current = current.down;
                yield return current;
            } while (current != node);
        }

    }
}
