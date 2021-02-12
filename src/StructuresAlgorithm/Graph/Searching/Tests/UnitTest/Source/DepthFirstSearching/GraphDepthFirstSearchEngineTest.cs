namespace AlgorithmCenter.StructuresAlgorithm.Graph.Searching.UnitTest.DepthFirstSearching
{
    using AlgorithmCenter.StructuresAlgorithm.Graph.Core.Abstractions;
    using AlgorithmCenter.StructuresAlgorithm.Graph.Searching.DepthFirstSearch;
    using Xunit;
    public class GraphDepthFirstSearchEngineTest
    {
        #region DFSEngine*Must*RecognizePathBetweenNodesWhen*ThereIs*PathBetweenThem
        [Fact]
        public void DFSEngineMustRecognizePathBetweenNodesWhenThereIsPathBetweenThem() 
            => Assert.True(GetSearchEngine().HasPath(1, 1111));
        #endregion
        #region DFSEngine*MustNot*RecognizePathBetweenNodesWhen*ThereIsNot*PathBetweenThem
        [Fact]
        public void DFSEngineMustNotRecognizePathBetweenNodesWhenThereIsNotPathBetweenThem() 
            => Assert.False(GetSearchEngine().HasPath(1, 23));
        #endregion

        private static GraphDepthFirstSearchEngine<int> GetSearchEngine() 
            => new GraphDepthFirstSearchEngine<int>(MakingGraph());
        #region TestCase
        private static ListGraph<int> MakingGraph()
        {
            var graph = new ListGraph<int>();

            graph.AddVertex(1);
            graph.AddVertex(11);
            graph.AddVertex(111);
            graph.AddVertex(1111);
            graph.AddVertex(11111);
            graph.AddVertex(111111);
            graph.AddVertex(111111);
            graph.AddEdge(1, 11);
            graph.AddEdge(11, 111);
            graph.AddEdge(111, 1111);
            graph.AddEdge(1111, 11111);
            graph.AddEdge(11111, 111111);

            graph.AddVertex(2);
            graph.AddVertex(22);
            graph.AddVertex(222);
            graph.AddVertex(2222);
            graph.AddVertex(22222);
            graph.AddVertex(222222);
            graph.AddVertex(2222222);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 22);
            graph.AddEdge(22, 222);
            graph.AddEdge(222, 2222);
            graph.AddEdge(2222, 22222);
            graph.AddEdge(22222, 222222);
            graph.AddEdge(22222, 2222222);
            return graph;
        }
        #endregion
    }
}
