using Furnace.Core.Data.Play.Metas;

namespace Furnace.Core.Data.Play.Patterns.Core
{
    public interface IImagePattern : IMeta
    {
        string Src { get; }
        string Alt { get; }
        int Height { get; }
        int Width { get; }
    }
}