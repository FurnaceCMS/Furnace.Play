using System.Collections.Generic;
using Furnace.Core.Play.Kernal.Middleware;

namespace Furnace.Core.Play.Kernal.Composition
{
    public interface ICompositionRoot
    {
        IEnumerable<IFurnaceMiddleware> FurnaceMiddleware { get; }
    }
}
