using System.Collections.Generic;
using System.Threading.Tasks;
using Furnace.Core.Play.Kernal.Middleware;

namespace Furnace.Core.Requet.Debug.Play
{
    public class WebRequestMiddlewareDecorator: FurnaceMiddlewareDecorator
    {
        public WebRequestMiddlewareDecorator(IFurnaceMiddleware decoratee) : base(decoratee)
        {
        }

        public override Task Invoke(IDictionary<string, object> environment)
        {
            var renderArray = new List<string> {"Hello from WebRequestMiddlewareDecorator "};
            environment.Add("RenderArray", renderArray);
            return Decoratee.Invoke(environment);
        }
    }
}
