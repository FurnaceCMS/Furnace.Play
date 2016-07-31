using System;
using System.IO;
using Furnace.Core.Data.Play.Metas;
using Newtonsoft.Json;

namespace Furnace.Core.Data.Play.Persistence.JSON
{
    public class MetaRelationshipPersistence : IPersistence<IMetaRelationship>
    {
        public void Save(IMetaRelationship data)
        {
            var json = JsonConvert.SerializeObject(data, new MetaConverter());

            File.WriteAllText($"metaRelationships\\{data.Id}.json", json);
        }

        public IMetaRelationship Load(Guid id)
        {
            try
            {
                var json = File.ReadAllText($"metaRelationships\\{id}.json");

                var metaRelationship = JsonConvert.DeserializeObject<MetaRelationship>(json, new MetaConverter());
                return metaRelationship;
            }
            catch (FileNotFoundException)
            {
                throw new MetaCollectionNotFoundException();
            }
        }
    }
}
