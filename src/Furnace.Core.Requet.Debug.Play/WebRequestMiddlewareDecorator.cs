using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Furnace.Core.Play;

namespace Furnace.Core.Requet.Debug.Play
{
    public class WebRequestMiddlewareDecorator: FurnaceMiddlewareDecorator
    {
        public WebRequestMiddlewareDecorator(IFurnaceMiddleware decoratee) : base(decoratee)
        {
        }

        public override Task Invoke(IDictionary<string, object> environment)
        {
            Console.WriteLine("WebRequestMiddlewareDecorator");

            return Decoratee.Invoke(environment);
        }
    }
}
