using System.Collections.Generic;
using Furnace.Core.Play.GraphTheory.Graphs;

namespace Furnace.Core.Play.GraphTheory.Algorithms
{
    public static class AlgorithmExtensions
    {
        public static IList<TVertex> TopologicalSort<TVertex>(this DirectedAcyclicGraph<TVertex> graph)
        {
            return new TopologicalSortAlgorithm<TVertex>(graph).SortedVertices;
        }
    }
}
