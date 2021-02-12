namespace AlgorithmCenter.StructuresAlgorithm.Graph.Searching.Core.Abstractions
{

    using AlgorithmCenter.StructuresAlgorithm.Graph.Core.Abstractions;
    public abstract class GraphSearchEngine<TNode>
    {
        public GraphSearchEngine(ListGraph<TNode> graph) => _graph = graph;
        public ListGraph<TNode> Graph => _graph; 
        private readonly ListGraph<TNode> _graph;
        public abstract bool HasPath(TNode sourceValue,TNode destinationValue);
    }
}
