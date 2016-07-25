using Furnace.Core.Data.Play.Metas.Typed;

namespace Furnace.Core.Data.Play.Factories.Metas.Typed
{
    public interface ITypedMetaFactory<TMetaType> : IMetaFactory
    {
        ITypedMeta<TMetaType> CreateTypedMeta(string name, TMetaType value);
    }
}