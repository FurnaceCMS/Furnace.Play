namespace Furnace.Core.Play.GraphTheory.Graphs
{
    public interface IEdge<TVertex>
    {
        TVertex Source { get; }
        TVertex Target { get; }
    }
}
