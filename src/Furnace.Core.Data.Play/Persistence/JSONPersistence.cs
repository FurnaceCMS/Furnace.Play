using System;
using System.IO;
using Furnace.Core.Data.Play.Metas;
using Newtonsoft.Json;

namespace Furnace.Core.Data.Play.Persistence
{
    public class JSONPersistence: IPersistence
    {
        public void Save(IMetaCollection metaCollection)
        {
            var json = JsonConvert.SerializeObject(metaCollection);

            File.WriteAllText("data.json", json);
        }

        public IMetaCollection Load(Guid id)
        {
            var json = File.ReadAllText("data.json");

            var metaCollection = JsonConvert.DeserializeObject<MetaCollection>(json, new MetaConverter());
            return metaCollection;
        }
    }
}
