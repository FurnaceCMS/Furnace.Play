using System;
using System.Collections.Generic;
using Furnace.Core.Data.Play.Factories.Metas;
using Furnace.Core.Data.Play.Metas.Typed;
using NUnit.Framework;

namespace Furnace.Core.Data.Play.Tests.Factories.Metas
{
    [TestFixture]
    public class MetaCollectionFactoryTests
    {
        private const string CollectionName = "metaCollection";
        private const string MetaName1 = "meta1name";
        private const string MetaName2 = "meta2name";
        private const string MetaName3 = "meta3name";

        [Test]
        public void CanCreateStringMetaCollections()
        {
            //arrange
            var data = new Dictionary<string, dynamic>
            {
                {MetaName1, "metaString1Value"},
                {MetaName2, "metaString2Value"},
                {MetaName3, "metaString3Value"},
            };
            var stringMetaFactory = new MetaCollectionFactory();

            //act
            var metaCollection = stringMetaFactory.CreateMetaCollection(CollectionName, data);

            //assert
            Assert.IsNotNull(metaCollection);
            Assert.AreEqual(metaCollection.Name, CollectionName);
            Assert.AreEqual(metaCollection.Metas.Count, data.Count);
            Assert.AreEqual(data[MetaName1], metaCollection.GetMeta<StringMeta>(MetaName1).Value);
            Assert.AreEqual(data[MetaName2], metaCollection.GetMeta<StringMeta>(MetaName2).Value);
            Assert.AreEqual(data[MetaName3], metaCollection.GetMeta<StringMeta>(MetaName3).Value);
        }

        [Test]
        public void CanCreateIntMetaCollections()
        {
            //arrange
            var data = new Dictionary<string, dynamic>
            {
                {MetaName1, 1},
                {MetaName2, 2},
                {MetaName3, 3},
            };
            var stringMetaFactory = new MetaCollectionFactory();

            //act
            var metaCollection = stringMetaFactory.CreateMetaCollection(CollectionName, data);

            //assert
            Assert.IsNotNull(metaCollection);
            Assert.AreEqual(metaCollection.Name, CollectionName);
            Assert.AreEqual(metaCollection.Metas.Count, data.Count);
            Assert.AreEqual(data[MetaName1], metaCollection.GetMeta<IntMeta>(MetaName1).Value);
            Assert.AreEqual(data[MetaName2], metaCollection.GetMeta<IntMeta>(MetaName2).Value);
            Assert.AreEqual(data[MetaName3], metaCollection.GetMeta<IntMeta>(MetaName3).Value);
        }

        [Test]
        public void CanCreateDateTimeMetaCollections()
        {
            //arrange
            var data = new Dictionary<string, dynamic>
            {
                {MetaName1, DateTime.Now},
                {MetaName2, DateTime.Now.AddMinutes(1)},
                {MetaName3, DateTime.Now.AddMinutes(2)},
            };
            var stringMetaFactory = new MetaCollectionFactory();

            //act
            var metaCollection = stringMetaFactory.CreateMetaCollection(CollectionName, data);

            //assert
            Assert.IsNotNull(metaCollection);
            Assert.AreEqual(metaCollection.Name, CollectionName);
            Assert.AreEqual(metaCollection.Metas.Count, data.Count);
            Assert.AreEqual(data[MetaName1], metaCollection.GetMeta<DateTimeMeta>(MetaName1).Value);
            Assert.AreEqual(data[MetaName2], metaCollection.GetMeta<DateTimeMeta>(MetaName2).Value);
            Assert.AreEqual(data[MetaName3], metaCollection.GetMeta<DateTimeMeta>(MetaName3).Value);
        }


        [Test]
        public void CanCreateMixedMetaCollections()
        {
            //arrange
            var data = new Dictionary<string, dynamic>
            {
                {MetaName1, 1},
                {MetaName2, "2"},
                {MetaName3, 3},
            };
            var stringMetaFactory = new MetaCollectionFactory();

            //act
            var metaCollection = stringMetaFactory.CreateMetaCollection(CollectionName, data);

            //assert
            Assert.IsNotNull(metaCollection);
            Assert.AreEqual(metaCollection.Name, CollectionName);
            Assert.AreEqual(metaCollection.Metas.Count, data.Count);
            Assert.AreEqual(data[MetaName1], metaCollection.GetMeta<IntMeta>(MetaName1).Value);
            Assert.AreEqual(data[MetaName2], metaCollection.GetMeta<StringMeta>(MetaName2).Value);
            Assert.AreEqual(data[MetaName3], metaCollection.GetMeta<IntMeta>(MetaName3).Value);
        }
    }
}
