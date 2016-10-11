using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Furnace.Core.Play.Query.ConfigurationRoot
{
    public class ConfigurationRootQueryResult
    {
        public IEnumerable<IConfigurationSection> ConfigurationSections { get; set; }
    }
}
