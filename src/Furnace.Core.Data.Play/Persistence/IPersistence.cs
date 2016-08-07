using System;

namespace Furnace.Core.Data.Play.Persistence
{
    public interface IPersistence<TPersistenceType>
    {
        void Save(TPersistenceType data);
        TPersistenceType Load(Guid id);
        void Delete(Guid id);
    }
}
