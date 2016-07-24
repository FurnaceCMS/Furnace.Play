using System;
using System.Collections.Generic;
using System.Reflection;
using Furnace.Core.Data.Play.Factories.Metas.Typed;
using Furnace.Core.Data.Play.Metas;
using System.Linq;

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
            BuildMetaFactoriesDictionary();
        }

        private void BuildMetaFactoriesDictionary()
        {
            MetaFactories = new Dictionary<Type, IMetaFactory>();

            var interfaceType = typeof(IMetaFactory);
            var metaFactoryTypes = GetMetaFactoryTypes(interfaceType);

            foreach (var metaFactoryType in metaFactoryTypes)
            {
                var metaFactory = Activator.CreateInstance(metaFactoryType) as IMetaFactory;
                if (metaFactory == null)
                    continue;

                MetaFactories.Add(metaFactory.FactoryType, metaFactory);
            }
        }

        private IEnumerable<Type> GetMetaFactoryTypes(Type interfaceType)
        {
            var metaFactoryTypes = typeof(MetaCollectionFactory).GetTypeInfo()
                .Assembly
                .GetTypes()
                .Where(p => interfaceType.IsAssignableFrom(p)
                            && !DoesTypeHaveAttribute(p, TypeAttributes.Abstract)
                            && !DoesTypeHaveAttribute(p, TypeAttributes.Interface));
            return metaFactoryTypes;
        }

        private bool DoesTypeHaveAttribute(Type type, TypeAttributes attribute)
        {
            return (type.GetTypeInfo().Attributes & attribute) != 0;
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
