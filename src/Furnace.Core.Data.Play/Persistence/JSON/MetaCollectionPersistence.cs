using System;
using System.IO;
using Furnace.Core.Data.Play.Metas;
using Newtonsoft.Json;

namespace Furnace.Core.Data.Play.Persistence.JSON
{
    public class MetaCollectionPersistence: IPersistence<IMetaCollection>
    {
        public void Save(IMetaCollection data)
        {
            var json = JsonConvert.SerializeObject(data);

            File.WriteAllText($"metaCollections\\{data.Id}.json", json);
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

        public void Delete(Guid id)
        {
            File.Delete($"metaCollections\\{id}.json");
        }
    }
}
