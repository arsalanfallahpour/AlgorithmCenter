namespace AlgorithmCenter.StructuresAlgorithm.Graph.Core.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    public sealed class ListGraphNode<TNode>
    {
        public ListGraphNode(TNode nodeValue)
        {
            value = nodeValue;
            neighbors = new List<ListGraphNode<TNode>>();
        }
        private readonly TNode value;
        private readonly List<ListGraphNode<TNode>> neighbors;
        public TNode Value => value;
        public IList<ListGraphNode<TNode>> Neighbors => neighbors.AsReadOnly();

        public bool AddNeighbor(ListGraphNode<TNode> neighbor) {
            if (neighbors.Contains(neighbor))
                return false;
            else
            {
                neighbors.Add(neighbor);
                return true;
            }
        }
        public bool RemoveNeighbor(ListGraphNode<TNode> neighbor)
             => neighbors.Remove(neighbor);
    
        public bool RemoveAllNeighbors()
        {
            for (var i = neighbors.Count -1; i <= 0; i--)
                neighbors.RemoveAt(i);
            return true;
        }
        public override string ToString()
        {
            var nodeString = new StringBuilder();
            nodeString.Append($"[Node value: {value} Neighbors: ");
            for (var i = 0; i < Neighbors.Count; i++)
                nodeString.Append($"{neighbors[i].Value} ");
            nodeString.Append("]");
            return nodeString.ToString();
        }
    }
}
