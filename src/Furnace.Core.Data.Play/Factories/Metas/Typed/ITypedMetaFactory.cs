using Furnace.Core.Data.Play.Metas.Typed;

namespace Furnace.Core.Data.Play.Factories.Metas.Typed
{
    public interface ITypedMetaFactory<TMetaType>
    {
        ITypedMeta<TMetaType> CreateMeta(string name, TMetaType value);
    }
}