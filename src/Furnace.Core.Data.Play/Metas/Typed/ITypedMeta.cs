namespace Furnace.Core.Data.Play.Metas.Typed
{
    public interface ITypedMeta<TMetaType> : IMeta
    {
        TMetaType Value { get; set; }
    }
}