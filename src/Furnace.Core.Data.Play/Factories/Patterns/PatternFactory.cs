using System.Reflection;
using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Data.Play.Patterns;

namespace Furnace.Core.Data.Play.Factories.Patterns
{
    public class PatternFactory : IPatternFactory
    {
        public TPatternType GetPattern<TPatternType>(IMetaCollection metaCollection) where TPatternType : Pattern
        {
            return GetPattern<TPatternType>(metaCollection.Name, metaCollection);
        }

        public TPatternType GetPattern<TPatternType>(string name, IMetaCollection metaCollection) where TPatternType : Pattern
        {
            var ctor = typeof(TPatternType).GetConstructor(new[] { typeof(string), typeof(IMetaCollection) });
            return ctor.Invoke(new object[] { name, metaCollection }) as TPatternType;
        }
    }
}