using Furnace.Core.Data.Play.Factories.Metas;
using Furnace.Core.Data.Play.Factories.Patterns;
using Furnace.Core.Data.Play.Patterns.Core;
using Furnace.Core.Play.Query;

namespace Furnace.Core.Node.Play.Queries.Patterns
{
    public class PagePatternQueryHandler : IQueryHandler<PatternQuery, PatternQueryResult>
    {
        private readonly IPatternFactory _patternFactory;
        private readonly IMetaCollectionFactory _metaCollectionFactory;

        public PagePatternQueryHandler(IPatternFactory patternFactory, IMetaCollectionFactory metaCollectionFactory)
        {
            _patternFactory = patternFactory;
            _metaCollectionFactory = metaCollectionFactory;
        }

        public PatternQueryResult Handle(PatternQuery query)
        {
            var metaCollection = _metaCollectionFactory.GetMetaCollection(query.CollectionId);
            var pattern = _patternFactory.GetPattern<PagePattern>(metaCollection);
            return new PatternQueryResult(pattern);
        }
    }
}
