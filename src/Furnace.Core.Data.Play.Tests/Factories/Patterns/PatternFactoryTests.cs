using System;
using System.Collections.Generic;
using Furnace.Core.Data.Play.Factories.Patterns;
using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Data.Play.Metas.Typed;
using Furnace.Core.Data.Play.Patterns.Core;
using NUnit.Framework;

namespace Furnace.Core.Data.Play.Tests.Factories.Patterns
{
    [TestFixture]
    public class PatternFactoryTests
    {
        [Test]
        public void CanGetPagePattern()
        {
            //arrange
            var metaCollection = new MetaCollection
            {
                DateCreated = DateTime.Now,
                Id = Guid.NewGuid(),
                LastUpdated = DateTime.Now,
                Name = "Test Page Meta Collection",
                Metas = new List<IMeta>
                {
                    GenerateStringMeta("metaTitle", "Meta Title"),
                    GenerateStringMeta("metaDescription", "Meta Description"),
                    GenerateStringMeta("metaKeywords", "Meta Keywords"),
                    GenerateStringMeta("metaAuthor", "Meta Author"),
                    GenerateStringMeta("title", "Title"),
                    GenerateStringMeta("body", "Body")
                }
            };
            var patternFactory = new PatternFactory();
            
            //act
            var pagePattern = patternFactory.GetPattern<PagePattern>("Page Pattern", metaCollection);

            //assert
            Assert.IsNotNull(pagePattern);
            Assert.AreEqual(pagePattern.Body, "Body");
            Assert.AreEqual(pagePattern.MetaAuthor, "Meta Author");
            Assert.AreEqual(pagePattern.MetaDescription, "Meta Description");
            Assert.AreEqual(pagePattern.MetaKeywords, "Meta Keywords");
            Assert.AreEqual(pagePattern.MetaTitle, "Meta Title");
            Assert.AreEqual(pagePattern.Title, "Title");
        }

        private static StringMeta GenerateStringMeta(string stringMetaTitle, string stringMetaValue)
        {
            return new StringMeta
            {
                DateCreated = DateTime.Now,
                Id = Guid.NewGuid(),
                LastUpdated = DateTime.Now,
                Name = stringMetaTitle,
                Value = stringMetaValue
            };
        }
    }
}
