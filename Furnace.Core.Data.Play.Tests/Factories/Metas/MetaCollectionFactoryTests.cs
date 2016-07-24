using System.Collections.Generic;
using Furnace.Core.Data.Play.Factories.Metas;
using NUnit.Framework;

namespace Furnace.Core.Data.Play.Tests.Factories.Metas
{
    [TestFixture]
    public class MetaCollectionFactoryTests
    {
        [Test]
        public void CanCreateStringMetaCollections()
        {
            //arrange
            var name = "stringMetaCollection";
            const string name1 = "metaString1name";
            const string name2 = "metaString2name";
            const string name3 = "metaString3name";
            var data = new Dictionary<string, dynamic>
            {
                {name1, "metaString1Value"},
                {name2, "metaString2Value"},
                {name3, "metaString3Value"},
            };
            var stringMetaFactory = new MetaCollectionFactory();

            //act
            var metaCollection = stringMetaFactory.CreateMetaCollection(name, data);

            //assert
            Assert.IsNotNull(metaCollection);
            Assert.AreEqual(metaCollection.Name, name);
            Assert.AreEqual(metaCollection.Metas.Count, data.Count);
            Assert.AreEqual(data[name1], metaCollection[name1].GetValue<string>());
            Assert.AreEqual(data[name2], metaCollection[name2].GetValue<string>());
            Assert.AreEqual(data[name3], metaCollection[name3].GetValue<string>());
        }
    }
}
