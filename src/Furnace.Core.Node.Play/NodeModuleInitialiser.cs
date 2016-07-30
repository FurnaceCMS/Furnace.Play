using Furnace.Core.Node.Play.Query;
using Furnace.Core.Play.Module;
using Furnace.Core.Play.Query;
using SimpleInjector;

namespace Furnace.Core.Node.Play
{
    public class NodeModuleInitialiser: IModuleInitialiser
    {
        public void ConfigureContainer(Container container)
        {
            container.Register<IQueryHandler<NodeQuery, NodeQueryResult>, NodeQueryHandler>();
        }
    }
}
