using Furnace.Core.Node.Play.Queries.Collections;
using Furnace.Core.Node.Play.Queries.Patterns;
using Furnace.Core.Node.Play.Queries.Relationships;
using Furnace.Core.Play.Module;
using Furnace.Core.Play.Query;
using SimpleInjector;

namespace Furnace.Core.Node.Play
{
    public class NodeModuleInitialiser: IModuleInitialiser
    {
        public void ConfigureContainer(Container container)
        {
            container.Register<IQueryHandler<CollectionQuery, CollectionQueryResult>, CollectionQueryHandler>();
            container.Register<IQueryHandler<RelationshipQuery, RelationshipQueryResult>, RelationshipQueryHandler>();
            container.Register<IQueryHandler<PatternQuery, PatternQueryResult>, PagePatternQueryHandler>();
        }
    }
}
