using System.Collections.Generic;
using Furnace.Core.Play.Middleware;

namespace Furnace.Core.Play.Composition
{
    public class CompositionRoot: ICompositionRoot
    {
        public CompositionRoot(IEnumerable<IFurnaceMiddleware> furnaceMiddleware)
        {
            FurnaceMiddleware = furnaceMiddleware;
        }

        public IEnumerable<IFurnaceMiddleware> FurnaceMiddleware { get; }
    }
}
