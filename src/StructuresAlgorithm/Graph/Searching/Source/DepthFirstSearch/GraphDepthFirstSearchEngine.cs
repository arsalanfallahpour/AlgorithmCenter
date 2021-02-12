namespace AlgorithmCenter.StructuresAlgorithm.Graph.Searching.DepthFirstSearch
{
    using AlgorithmCenter.StructuresAlgorithm.Graph.Core.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AlgorithmCenter.StructuresAlgorithm.Graph.Searching.Core.Abstractions;

    public sealed class GraphDepthFirstSearchEngine<TNode> : GraphSearchEngine<TNode>
    {
        public GraphDepthFirstSearchEngine(ListGraph<TNode> graph) : base(graph)
        { }
        public override bool HasPath(TNode sourceValue, TNode destinationValue)
        {
            var sourceNode = Graph.Find(sourceValue);
            var destinationNode = Graph.Find(destinationValue);
            var visited = new HashSet<TNode>();
            return HasPath(sourceNode, destinationNode, visited);
        }
        private bool HasPath(
              ListGraphNode<TNode> source
            , ListGraphNode<TNode> destination
            , HashSet<TNode> visited)
        {
            ValidateSourceNode(source);

            var alreadyVisited = visited.Contains(source.Value);
            if (alreadyVisited)
                return false;

            MarkSourceVisited(source, visited);

            var destinationFinded = source == destination;
            if (destinationFinded)
                return true;

            return LookingUpAtNeighbors(source, destination, visited);
        }

        private static void ValidateSourceNode(ListGraphNode<TNode> source)
        {
            if (source is null)
                throw new NullReferenceException("The source is not exist in the graph!");
        }

        private bool LookingUpAtNeighbors(
            ListGraphNode<TNode> source,
            ListGraphNode<TNode> destination,
            HashSet<TNode> visited)
        {
            foreach (var child in source.Neighbors)
            {
                if (HasPath(child, destination, visited))
                    return true;
            }
            return false;
        }
        private void MarkSourceVisited(ListGraphNode<TNode> source, HashSet<TNode> visited) 
            => _ = visited.Add(source.Value);
    }
}
