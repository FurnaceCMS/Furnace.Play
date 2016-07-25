using System;
using System.Collections.Generic;
using System.Reflection;
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

            foreach (var dataItem in data)
            {
                if (!MetaFactories.ContainsKey(dataItem.Value.GetType()))
                    continue;

                metaCollection.Metas.Add(MetaFactories[dataItem.Value.GetType()].CreateMeta(dataItem.Key, dataItem.Value));
            }

            return metaCollection;
        }
    }
}
