namespace Furnace.Core.Play.GraphTheory.Graphs
{
    public class Edge<TVertex> : IEdge<TVertex>
    {
        public TVertex Source { get; set; }

        public TVertex Target { get; set; }
    }
}
