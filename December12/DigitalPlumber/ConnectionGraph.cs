using System.Collections.Generic;

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

        public ConnectionDefinition GetDataForNode(int node)
        {
            return _graph[node];
        }
     }
}
