using Microsoft.Extensions.Configuration;

namespace Furnace.Core.Play.Query.ConfigurationRoot
{
    public class ConfigurationRootQueryHandler : IQueryHandler<ConfigurationRootQuery, ConfigurationRootQueryResult>
    {
        private readonly IConfigurationRoot _configurationRoot;

        public ConfigurationRootQueryHandler(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public ConfigurationRootQueryResult Handle(ConfigurationRootQuery rootQuery)
        {
            var section = _configurationRoot.GetSection(rootQuery.SectionName);

            var result = new ConfigurationRootQueryResult {ConfigurationSections = section.GetChildren()};

            return result;
        }
    }
}
