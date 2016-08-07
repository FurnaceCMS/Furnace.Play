namespace Furnace.Core.Data.Play.Patterns.Core
{
    public interface IImagePattern
    {
        string Src { get; }
        string Alt { get; }
        int Height { get; }
        int Width { get; }
    }
}