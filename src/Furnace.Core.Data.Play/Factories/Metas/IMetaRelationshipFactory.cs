using System;
using Furnace.Core.Data.Play.Metas;

namespace Furnace.Core.Data.Play.Factories.Metas
{
    public interface IMetaRelationshipFactory
    {
        IMetaRelationship GetMetaRelationship(Guid masterMetaId);
        IMetaRelationship CreateMetaRelationsip(Guid masterMetaId, Guid relatedMetaId);
        IMetaRelationship DeleteMetaRelationsip(Guid masterMetaId, Guid relatedMetaId);
    }
}