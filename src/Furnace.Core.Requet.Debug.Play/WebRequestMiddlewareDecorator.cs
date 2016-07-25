using System.Collections.Generic;
using System.Threading.Tasks;
using Furnace.Core.Play.Middleware;

namespace Furnace.Core.Requet.Debug.Play
{
    public class WebRequestMiddlewareDecorator: FurnaceMiddlewareDecorator
    {
        public WebRequestMiddlewareDecorator(FurnaceMiddleware decoratee) : base(decoratee)
        {
        }

        public override Task Next(IDictionary<string, object> environment)
        {
            var renderArray = new List<string> { "Hello from WebRequestMiddlewareDecorator " };
            environment.Add("RenderArray", renderArray);
            return Decoratee.Next(environment);
        }
    }
}
