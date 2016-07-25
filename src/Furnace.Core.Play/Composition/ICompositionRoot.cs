using System.Collections.Generic;
using Furnace.Core.Play.Middleware;

namespace Furnace.Core.Play.Composition
{
    public interface ICompositionRoot
    {
        IEnumerable<IFurnaceMiddleware> FurnaceMiddleware { get; }
    }
}
