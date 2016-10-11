using Furnace.Core.Data.Play.Factories.Metas;
using Furnace.Core.Data.Play.Factories.Patterns;
using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Data.Play.Persistence;
using Furnace.Core.Data.Play.Persistence.JSON;
using Furnace.Core.Data.Play.Query.Configuration.MetaTypeMaping;
using Furnace.Core.Play.Module;
using Furnace.Core.Play.Query;
using SimpleInjector;

namespace Furnace.Core.Nancy.Play.Module
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

            container.Register<IQueryHandler<MetaTypeMapingQuery, MetaTypeMapingQueryResult>, MetaTypeMapingQueryHandler>();
        }
    }
}
