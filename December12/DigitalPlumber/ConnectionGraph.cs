using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitalPlumber
{
    class ConnectionGraph
    {
        // internal structure to keep track of which nodes connect to which other nodes directly
        private readonly IDictionary<int, ConnectionDefinition> _graph = new Dictionary<int, ConnectionDefinition>();

        public void AddConnection(ConnectionDefinition connDef)
        {
            _graph[connDef.From] = connDef;
        }

        private SortedSet<int> _reachableNodes;
        private SortedSet<int> _visitedNodes;

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
            // add start node  to list as described in puzzle explanation
            _reachableNodes.Add(startNode);
            FindReachableNodes(startNode);
            return _reachableNodes.ToList();
        }

        private void FindReachableNodes(int fromNode)
        {
            // return immediately if we already visited the node
            if (_visitedNodes.Contains(fromNode))
            {
                return;
            }
            // register current node as visited
            _visitedNodes.Add(fromNode);
            // obtain node connection data
            var nodes = _graph[fromNode];
            foreach (var node in nodes.To)
            {
                _reachableNodes.Add(node);
                // visit crrent node
                FindReachableNodes(node);
            }
        }

        private IList<int> AllNodes => _graph.Keys.ToList();

        /// <summary>
        /// process all nodes
        /// per node determine all nodes reachable via that node => add group
        /// remove those nodes from list of nodes to process
        /// take next node
        /// per node determine all nodes reachable via that node => add group
        /// remove those nodes from list of nodes to process
        /// until no nodes left
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfGroups()
        {
            var groups = new Dictionary<int, List<int>>();
            var initialNodeList = AllNodes;
            FindGroups(AllNodes, groups);
            return groups.Keys.Count;
        }

        private void FindGroups(IList<int> remainingNodesList, Dictionary<int, List<int>> groups)
        {
            // finished if list of remaining nodes is empty
            if (!remainingNodesList.Any())
            {
                return;
            }
            var currentNode = remainingNodesList.First();
            var reachableNodes = GetReachableNodesFor(currentNode);
            groups[currentNode] = reachableNodes.ToList();
            // remove all reachable nodes from the nodes still to process
            foreach (var node in reachableNodes)
            {
                // remve so we do not process this node later
                remainingNodesList.Remove(node);
            }
            // recursive call to find other groups in remaining node list
            FindGroups(remainingNodesList, groups);
        }
    }
}
