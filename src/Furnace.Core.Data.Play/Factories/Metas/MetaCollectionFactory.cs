using System;
using System.Collections.Generic;
using Furnace.Core.Data.Play.Factories.Metas.Typed;
using Furnace.Core.Data.Play.Metas;

namespace Furnace.Core.Data.Play.Factories.Metas
{
    public class MetaCollectionFactory
    {
        public IDictionary<Type, IMetaFactory> MetaFactories { get; set; }

        public MetaCollectionFactory()
        {
            PopulateMetaFactories();
        }

        private void PopulateMetaFactories()
        {
            //TODO:: change this to use reflection to build collection from interface
            MetaFactories = new Dictionary<Type, IMetaFactory>
            {
                {typeof(string), new StringMetaFactory()},
                {typeof(int), new IntMetaFactory()},
                {typeof(DateTime), new DateTimeMetaFactory()}
            };
        }

        public IMetaCollection GetMetaCollection(Guid id)
        {
            return new MetaCollection();
        }

        public IMetaCollection CreateMetaCollection(string name, IDictionary<string, dynamic> data)
        {
            var metaCollection = new MetaCollection
            {
                DateCreated = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                Id = Guid.NewGuid(),
                Name = name
            };


            //TODO:: Get rid of this horrible loop, Polymorphism FTW!
            foreach (var dataItem in data)
            {
                if (!MetaFactories.ContainsKey(dataItem.Value.GetType()))
                    continue;

                if (dataItem.Value is string)
                {
                    var stringMetaFactory = MetaFactories[dataItem.Value.GetType()] as StringMetaFactory;
                    if (stringMetaFactory == null)
                        continue;

                    metaCollection.Metas.Add(stringMetaFactory.CreateMeta(dataItem.Key, dataItem.Value));
                    continue;
                }

                if (dataItem.Value is int)
                {
                    var intMetaFactory = MetaFactories[dataItem.Value.GetType()] as IntMetaFactory;
                    if (intMetaFactory == null)
                        continue;

                    metaCollection.Metas.Add(intMetaFactory.CreateMeta(dataItem.Key, dataItem.Value));
                    continue;
                }

                if (dataItem.Value is DateTime)
                {
                    var dateTimeMetaFactory = MetaFactories[dataItem.Value.GetType()] as DateTimeMetaFactory;
                    if (dateTimeMetaFactory == null)
                        continue;

                    metaCollection.Metas.Add(dateTimeMetaFactory.CreateMeta(dataItem.Key, dataItem.Value));
                    continue;
                }
            }

            return metaCollection;
        }
    }
}
