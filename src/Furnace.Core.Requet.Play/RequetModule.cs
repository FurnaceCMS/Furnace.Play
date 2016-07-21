using Furnace.Core.Play;
using Furnace.Core.Play.Kernal;
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
