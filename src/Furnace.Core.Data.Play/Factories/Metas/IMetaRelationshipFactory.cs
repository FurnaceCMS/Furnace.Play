using System;
using Furnace.Core.Data.Play.Metas;

namespace Furnace.Core.Data.Play.Factories.Metas
{
    public interface IMetaRelationshipFactory
    {
        IMetaCollectionRelationship GetMetaRelationship(Guid masterMetaId);
        IMetaCollectionRelationship CreateMetaRelationsip(Guid masterMetaId, Guid relatedMetaId);
        IMetaCollectionRelationship DeleteMetaRelationsip(Guid masterMetaId, Guid relatedMetaId);
    }
}