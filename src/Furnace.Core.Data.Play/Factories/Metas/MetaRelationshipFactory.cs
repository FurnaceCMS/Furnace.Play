using Furnace.Core.Data.Play.Metas;

namespace Furnace.Core.Data.Play.Factories.Metas
{
    public class MetaRelationshipFactory
    {
        public IMetaRelationship GetMetaRelationship()
        {
            return new MetaRelationship();
        }
    }
}
