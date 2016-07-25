using Furnace.Core.Play.Module;
using Furnace.Core.Play.Query;
using SimpleInjector;

namespace Furnace.Core.Requet.Play
{
    public sealed class RequetModule : FurnaceModule
    {
        public RequetModule()
        {
            Get("/", args => View["index"]);
        }

        public override void ConfigureContainer(Container container)
        {
            container.Register<IQueryHandler<WebRequestQuery, WebRequestQueryResult>, WebRequestQueryHandler>(Lifestyle.Scoped);
        }
    }
}
