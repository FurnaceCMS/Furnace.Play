using Furnace.Core.Play.Query;
using Furnace.Core.Play.Query.ConfigurationRoot;

namespace Furnace.Core.Data.Play.Query.Configuration.MetaTypeMaping
{
    public class MetaTypeMapingQueryHandler : IQueryHandler<MetaTypeMapingQuery, MetaTypeMapingQueryResult>
    {
        private readonly IQueryHandler<ConfigurationRootQuery, ConfigurationRootQueryResult> _configurationRootHandler;

        public MetaTypeMapingQueryHandler(IQueryHandler<ConfigurationRootQuery, ConfigurationRootQueryResult> configurationRootHandler)
        {
            _configurationRootHandler = configurationRootHandler;
        }


        public MetaTypeMapingQueryResult Handle(MetaTypeMapingQuery query)
        {
            var metaTypeMaping = _configurationRootHandler.Handle(new ConfigurationRootQuery
            {
                SectionName = "metaTypeMaping"
            });

            var result = new MetaTypeMapingQueryResult();

            result.AddRange(metaTypeMaping.ConfigurationSections);

            return result;
        }
    }
}
