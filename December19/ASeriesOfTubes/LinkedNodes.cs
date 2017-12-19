using System;
using System.Collections.Generic;
using System.Text;

namespace ASeriesOfTubes
{
    public class LinkedNodes
    {
        private IDictionary<string, Node> Grid { get; }
        private Node StartNode { get; set; }

        public LinkedNodes()
        {
            Grid = new Dictionary<string, Node>();
        }

        public void AddNode(Node node)
        {
            if (StartNode == null)
            {
                StartNode = node;
            }
            Grid[GetKey(node.X, node.Y)] = node;
        }

        private string GetKey(int x, int y)
        {
            return $"{x},{y}";
        }

        public Node GetNodeAt(int x, int y)
        {
            if (Grid.ContainsKey(GetKey(x, y)))
            {
                return Grid[GetKey(x, y)];
            }
            return null;
        }

        public string Visit(Direction direction)
        {
            var result = new StringBuilder();
            var currentNode = StartNode;
            while (currentNode != null)
            {
                result.Append(currentNode);
                var data = currentNode.GetNextNode(this, direction);
                currentNode = data.Item1;
                direction = data.Item2;
            }
            result.AppendLine();
            return result.ToString();
        }
    }
}
