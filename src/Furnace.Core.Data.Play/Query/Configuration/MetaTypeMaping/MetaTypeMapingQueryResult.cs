using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Furnace.Core.Data.Play.Query.Configuration.MetaTypeMaping
{
    public class MetaTypeMapingQueryResult: List<IConfigurationSection>
    {
        public string this[string key]
        {
            get { return this.SingleOrDefault(n => n.Key== key).Value; }
        }
    }
}
