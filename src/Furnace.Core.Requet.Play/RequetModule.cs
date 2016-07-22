using Furnace.Core.Play.Kernal.Module;
using Furnace.Core.Play.Kernal.Query;
using SimpleInjector;

namespace Furnace.Core.Requet.Play
{
    public class RequetModule : IFurnaceModule
    {
        public void ConfigureContainer(Container container)
        {
            container.Register<IQueryHandler<WebRequestQuery, WebRequestQueryResult>, WebRequestQueryHandler>(Lifestyle.Scoped);
        }
    }
}
