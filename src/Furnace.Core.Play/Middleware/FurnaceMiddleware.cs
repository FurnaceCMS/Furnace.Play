using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furnace.Core.Play.Middleware
{
    public abstract class FurnaceMiddleware : IFurnaceMiddleware
    {
        public abstract int Weight { get; }

        public abstract Task Invoke(IDictionary<string, object> environment);
    }
}
