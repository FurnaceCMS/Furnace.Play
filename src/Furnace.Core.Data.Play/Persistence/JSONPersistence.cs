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

            File.WriteAllText($"metaCollections\\{metaCollection.Id}.json", json);
        }

        public IMetaCollection Load(Guid id)
        {
            try
            {
                var json = File.ReadAllText($"metaCollections\\{id}.json");

                var metaCollection = JsonConvert.DeserializeObject<MetaCollection>(json, new MetaConverter());
                return metaCollection;
            }
            catch (FileNotFoundException)
            {
                throw new MetaCollectionNotFoundException();
            }
        }
    }
}
