using Furnace.Core.Play.Middleware;
using Furnace.Core.Play.Module;
using Furnace.Core.Requet.Play;
using SimpleInjector;

namespace Furnace.Core.Requet.Debug.Play
{
    public class RequetDebugModule : FurnaceModule
    {
        public override void ConfigureContainer(Container container)
        {
            container.RegisterDecorator(
                typeof(FurnaceMiddleware), 
                typeof(WebRequestMiddlewareDecorator),
                c=>c.ImplementationType == typeof(WebRequestMiddleware));
        }
    }
}