using Furnace.Core.Play;
using Furnace.Core.Play.Kernal.Middleware;
using Furnace.Core.Play.Kernal.Module;
using Furnace.Core.Requet.Play;
using SimpleInjector;

namespace Furnace.Core.Requet.Debug.Play
{
    public class RequetDebugModule : IFurnaceModule
    {
        public void ConfigureContainer(Container container)
        {
            container.RegisterDecorator(
                typeof(IFurnaceMiddleware), 
                typeof(WebRequestMiddlewareDecorator),
                c=>c.ImplementationType == typeof(WebRequestMiddleware));
        }
    }
}