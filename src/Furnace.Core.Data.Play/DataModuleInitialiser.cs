using Furnace.Core.Data.Play.Factories.Metas;
using Furnace.Core.Data.Play.Factories.Patterns;
using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Data.Play.Persistence;
using Furnace.Core.Data.Play.Persistence.JSON;
using Furnace.Core.Play.Module;
using SimpleInjector;

namespace Furnace.Core.Data.Play
{
    public class DataModuleInitialiser: IModuleInitialiser
    {
        public void ConfigureContainer(Container container)
        {
            container.Register<IMetaCollectionFactory, MetaCollectionFactory>();
            container.Register<IMetaRelationshipFactory, MetaRelationshipFactory>();
            container.Register<IPersistence<IMetaCollection>, MetaCollectionPersistence>();
            container.Register<IPersistence<IMetaCollectionRelationship>, MetaRelationshipPersistence>();
            container.Register<IPatternFactory, PatternFactory>();
        }
    }
}
