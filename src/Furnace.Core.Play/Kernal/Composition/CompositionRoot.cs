using System.Collections.Generic;
using Furnace.Core.Play.Kernal.Middleware;

namespace Furnace.Core.Play.Kernal.Composition
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
