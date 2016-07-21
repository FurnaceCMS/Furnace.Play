using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furnace.Core.Play.Kernal.Middleware
{
    public abstract class FurnaceMiddlewareDecorator : IFurnaceMiddleware
    {
        public int Weight => Decoratee.Weight;

        protected readonly IFurnaceMiddleware Decoratee;

        protected FurnaceMiddlewareDecorator(IFurnaceMiddleware decoratee)
        {
            Decoratee = decoratee;
        }

        public abstract Task Invoke(IDictionary<string, object> environment);
    }
}
