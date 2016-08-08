using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Data.Play.Patterns;

namespace Furnace.Core.Data.Play.Factories.Patterns
{
    public interface IPatternFactory
    {
        TPatternType GetPattern<TPatternType>(IMetaCollection metaCollection) where TPatternType : Pattern;
        TPatternType GetPattern<TPatternType>(string name, IMetaCollection metaCollection) where TPatternType : Pattern;
    }
}