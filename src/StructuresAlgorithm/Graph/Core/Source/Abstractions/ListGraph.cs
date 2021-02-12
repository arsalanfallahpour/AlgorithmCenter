namespace AlgorithmCenter.StructuresAlgorithm.Graph.Core.Abstractions
{

    using System.Collections.Generic;
    using System.Text;

    public sealed class ListGraph<TNode>
    {
        public ListGraph()
        { }
        private readonly List<ListGraphNode<TNode>> nodes = new List<ListGraphNode<TNode>>();
        public IList<ListGraphNode<TNode>> Nodes => nodes.AsReadOnly();
        public int Count => nodes.Count;
        public bool AddVertex(TNode node)
        {
            var isDuplicateValue = Find(node) != null;
            if (isDuplicateValue)
                return false;
            nodes.Add(new ListGraphNode<TNode>(node));
            return true;
        }
        public bool AddEdge(TNode  value1, TNode value2)
        {
            var node1 = Find(value1);
            var node2 = Find(value2);
            var nodesNotFind = node1 is null || node2 is null;
            if (nodesNotFind)
                return false;
            var edgeAlreadyExist = node1.Neighbors.Contains(node2);
            if (edgeAlreadyExist)
                return false;
            else
               return AddNeighborsToEachOther(node1, node2);
        }
        private bool AddNeighborsToEachOther(ListGraphNode<TNode> node1, ListGraphNode<TNode> node2)
        {
            var node2AddedToNode1Successfully = node1.AddNeighbor(node2);
            var node1AddedToNode2Successfully = node2.AddNeighbor(node1);
            return node2AddedToNode1Successfully && node1AddedToNode2Successfully;
        }
        public bool RemoveNode(TNode value)
        {
            var removeNode = Find(value);
            var removeNodeFind = removeNode != null;
            if (!removeNodeFind)
                return false;
            else
            {
                nodes.Remove(removeNode);
                foreach (var node in nodes)
                    node.RemoveNeighbor(node);
                return true;
            }
        }
        public bool RemoveEdge(TNode value1, TNode value2)
        {
            var node1 = Find(value1);
            var node2 = Find(value2);
            var nodesNotFind = node1 is null || node2 is null;
            if (nodesNotFind)
                return false;
            var edgeAlreadyExist = node1.Neighbors.Contains(node2);
            if (!edgeAlreadyExist)
                return false;
            else
                return RemoveNeighborsFromEachOther(node1, node2);
        }
        public ListGraphNode<TNode> Find(TNode value)
        {
            foreach (var node in nodes)
                if (node.Value.Equals(value))
                    return node;
                 return null;
        }
        public override string ToString()
        {
            var builder = new StringBuilder();
            for (var i = 0; i < Count; i++)
            {
                builder.Append(nodes[i].ToString());
                if (i < Count - 1)
                    builder.Append(", \n");
            }
            return builder.ToString();
        }
        private bool RemoveNeighborsFromEachOther(ListGraphNode<TNode> node1, ListGraphNode<TNode> node2)
        {
            var node2RemovedFromNode1Successfully = node1.RemoveNeighbor(node2);
            var node1RemovedFromNode2Successfully = node2.RemoveNeighbor(node1);
            return node2RemovedFromNode1Successfully && node1RemovedFromNode2Successfully;
        }

        public bool Clear()
        {
            RemoveAllNodesNeighbor();
            RemoveAllNodes();
            return true;
        }

        private void RemoveAllNodes()
        {
            for (var i = nodes.Count; i  >= 0; i--)
                nodes.RemoveAt(i);
        }

        private void RemoveAllNodesNeighbor()
        {
            foreach (var node in nodes)
                node.RemoveAllNeighbors();
        }
    }
}
