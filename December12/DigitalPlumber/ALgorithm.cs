using System.Collections.Generic;
using System.Linq;

namespace DigitalPlumber
{
    class Algorithm
    {
        private readonly ConnectionGraph _graph;

        private SortedSet<int> _reachableNodes;
        private SortedSet<int> _visitedNodes;

        public Algorithm(ConnectionGraph graph)
        {
            _graph = graph;
        }

        /// <summary>
        /// Get connection data for fromNode
        /// add all  to-nodes to the list of unique reachable nodes
        /// for each to-node repeat the same process
        /// make sure we do not enter a loop by checking if the node to visit has already been visited
        /// </summary>
        /// <param name="fromNode"></param>
        /// <returns></returns>
        public IList<int> GetReachableNodesFor(int startNode)
        {
            _reachableNodes = new SortedSet<int>();
            _visitedNodes = new SortedSet<int>();
            _reachableNodes.Add(startNode);
            ProcessNode(startNode);
            return _reachableNodes.ToList();
        }

        private void ProcessNode(int fromNode)
        {
            // return immediately if we already visited the node
            if (_visitedNodes.Contains(fromNode))
            {
                return;
            }
            // register current node as visited
            _visitedNodes.Add(fromNode);
            // obtain node connection data
            var nodes = _graph.GetDataForNode(fromNode);
            foreach (var node in nodes.To)
            {
                _reachableNodes.Add(node);
                // visit crrent node
                ProcessNode(node);
            }
        }
    }
}
