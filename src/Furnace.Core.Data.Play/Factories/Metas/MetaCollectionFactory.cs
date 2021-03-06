﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Furnace.Core.Data.Play.Metas;
using System.Linq;
using Furnace.Core.Data.Play.Persistence;

namespace Furnace.Core.Data.Play.Factories.Metas
{
    public class MetaCollectionFactory : IMetaCollectionFactory
    {
        private readonly IPersistence<IMetaCollection> _persistence;
        public IDictionary<Type, IMetaFactory> TypedMetaFactories { get; set; }

        public MetaCollectionFactory(IPersistence<IMetaCollection> persistence)
        {
            _persistence = persistence;
            BuildTypedMetaFactoriesDictionary();
        }

        private void BuildTypedMetaFactoriesDictionary()
        {
            TypedMetaFactories = new Dictionary<Type, IMetaFactory>();

            foreach (var metaFactoryType in GetMetaFactoryTypes())
            {
                var metaFactory = Activator.CreateInstance(metaFactoryType) as IMetaFactory;
                if (metaFactory == null)
                    continue;

                TypedMetaFactories.Add(metaFactory.FactoryType, metaFactory);
            }
        }

        private IEnumerable<Type> GetMetaFactoryTypes()
        {
            var metaFactoryTypes = typeof(MetaCollectionFactory).GetTypeInfo()
                                                                .Assembly
                                                                .GetTypes()
                                                                .Where(type => typeof(IMetaFactory).IsAssignableFrom(type)
                                                                            && !DoesTypeHaveAttribute(type, TypeAttributes.Abstract)
                                                                            && !DoesTypeHaveAttribute(type, TypeAttributes.Interface));
            return metaFactoryTypes;
        }

        private bool DoesTypeHaveAttribute(Type type, TypeAttributes attribute)
        {
            return (type.GetTypeInfo().Attributes & attribute) != 0;
        }

        public IMetaCollection GetMetaCollection(Guid id)
        {
            return _persistence.Load(id);
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
                if (!TypedMetaFactories.ContainsKey(dataItem.Value.GetType()))
                    continue;

                metaCollection.Metas.Add(TypedMetaFactories[dataItem.Value.GetType()].CreateMeta(dataItem.Key, dataItem.Value));
            }

            _persistence.Save(metaCollection);

            return metaCollection;
        }
    }
}
