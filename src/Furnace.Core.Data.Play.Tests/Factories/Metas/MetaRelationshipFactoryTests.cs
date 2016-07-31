using System;
using System.Linq;
using Furnace.Core.Data.Play.Factories.Metas;
using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Data.Play.Persistence;
using Moq;
using NUnit.Framework;

namespace Furnace.Core.Data.Play.Tests.Factories.Metas
{
    [TestFixture]
    public class MetaRelationshipFactoryTests
    {
        private Mock<IPersistence<IMetaRelationship>> _mockPersistence;
        private Mock<IMetaCollectionFactory> _mockMetaCollectionFactory;
        private MetaRelationshipFactory _metaRelationshipFactory;

        [SetUp]
        public void FixtureSetup()
        {
            _mockPersistence = new Mock<IPersistence<IMetaRelationship>>();
            _mockMetaCollectionFactory = new Mock<IMetaCollectionFactory>();
            _metaRelationshipFactory = new MetaRelationshipFactory(_mockPersistence.Object, _mockMetaCollectionFactory.Object);
        }

        [Test]
        public void CanGetExistingMetaRelationship()
        {
            //arrange
            var guid = Guid.NewGuid();
            _mockPersistence.Setup(x => x.Load(guid)).Returns(new MetaRelationship());

            //act
            var result = _metaRelationshipFactory.GetMetaRelationship(guid);

            //assert
            Assert.IsNotNull(result);
            _mockPersistence.Verify(x => x.Load(guid), Times.Exactly(1));
        }

        [Test]
        public void NonExistingRelationshipReturnsNull()
        {
            //arrange
            var guid = Guid.NewGuid();
            _mockPersistence.Setup(x => x.Load(guid)).Returns(default(IMetaRelationship));

            //act
            var result = _metaRelationshipFactory.GetMetaRelationship(guid);

            //assert
            Assert.IsNull(result);
            _mockPersistence.Verify(x => x.Load(guid), Times.Once);
        }

        [Test]
        public void CreateNewMasterRelationship()
        {
            //arange
            var masterMetaGuid = Guid.NewGuid();
            var relatedMetaGuid = Guid.NewGuid();
            var masterMeta = GenerateMetaCollection(masterMetaGuid, "masterMeta");
            var relatedMeta = GenerateMetaCollection(relatedMetaGuid, "relatedMeta");
            _mockPersistence.Setup(x => x.Load(masterMetaGuid)).Returns(default(IMetaRelationship));
            _mockMetaCollectionFactory.Setup(x => x.GetMetaCollection(relatedMetaGuid)).Returns(relatedMeta);
            _mockMetaCollectionFactory.Setup(x => x.GetMetaCollection(masterMetaGuid)).Returns(masterMeta);

            //act
            var result = _metaRelationshipFactory.CreateMetaRelationsip(masterMetaGuid, relatedMetaGuid);
            
            //assert
            Assert.IsNotNull(result);
            _mockPersistence.Verify(x => x.Load(masterMetaGuid), Times.Exactly(1));
            _mockMetaCollectionFactory.Verify(x => x.GetMetaCollection(masterMetaGuid), Times.Once);
            _mockMetaCollectionFactory.Verify(x => x.GetMetaCollection(relatedMetaGuid), Times.Once);
            _mockPersistence.Verify(x => x.Save(It.IsAny<IMetaRelationship>()), Times.Once);
            Assert.AreEqual(result.MasterMetaCollection.Id, masterMetaGuid);
            Assert.IsTrue(result.RelatedMetaCollections.Any(x => x.Id == relatedMetaGuid));
        }

        [Test]
        public void AddRelationshipToExistingMaster()
        {
            //arange
            var masterMetaGuid = Guid.NewGuid();
            var relatedMetaGuid = Guid.NewGuid();
            var masterMeta = GenerateMetaCollection(masterMetaGuid, "masterMeta");
            var relatedMeta = GenerateMetaCollection(relatedMetaGuid, "relatedMeta");
            var metaRelationship = GenerateMetaRelationship(masterMeta);
            _mockPersistence.Setup(x => x.Load(masterMetaGuid)).Returns(metaRelationship);
            _mockMetaCollectionFactory.Setup(x => x.GetMetaCollection(relatedMetaGuid)).Returns(relatedMeta);
            _mockMetaCollectionFactory.Setup(x => x.GetMetaCollection(masterMetaGuid)).Returns(masterMeta);

            //act
            var result = _metaRelationshipFactory.CreateMetaRelationsip(masterMetaGuid, relatedMetaGuid);

            //assert
            Assert.IsNotNull(result);
            _mockPersistence.Verify(x => x.Load(masterMetaGuid), Times.Exactly(1));
            _mockMetaCollectionFactory.Verify(x => x.GetMetaCollection(masterMetaGuid), Times.Never);
            _mockMetaCollectionFactory.Verify(x => x.GetMetaCollection(relatedMetaGuid), Times.Once);
            _mockPersistence.Verify(x => x.Save(It.IsAny<IMetaRelationship>()), Times.Once);
            Assert.AreEqual(result.MasterMetaCollection.Id, masterMetaGuid);
            Assert.IsTrue(result.RelatedMetaCollections.Any(x => x.Id == relatedMetaGuid));
        }

        private IMetaRelationship GenerateMetaRelationship(IMetaCollection masterMetaCollection)
        {
            return new MetaRelationship(masterMetaCollection);
        }

        private IMetaCollection GenerateMetaCollection(Guid id, string name)
        {
            return new MetaCollection
            {
                DateCreated = DateTime.Now,
                LastUpdated = DateTime.Now,
                Id = id,
                Name = name
            };
        }
    }
}
