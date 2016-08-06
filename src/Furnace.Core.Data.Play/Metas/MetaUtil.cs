using System.Linq;
using Furnace.Core.Data.Play.Metas.Typed;

namespace Furnace.Core.Data.Play.Metas
{
    public static class MetaUtil
    {
        public static string TryGetMetaStringValue(string name, IMetaCollection metaCollection)
        {
            var metaValue = TryGetMeta<StringMeta>(name, metaCollection);
            return metaValue == default(StringMeta) ?
                                default(string) :
                                metaValue.Value;
        }

        public static int TryGetMetaIntValue(string name, IMetaCollection metaCollection)
        {
            var metaValue = TryGetMeta<IntMeta>(name, metaCollection);
            return metaValue == default(IntMeta) ?
                                default(int) :
                                metaValue.Value;
        }

        private static TMetaType TryGetMeta<TMetaType>(string name, IMetaCollection metaCollection) where TMetaType : IMeta
        {
            if (metaCollection == null || metaCollection.Metas.All(x => x.Name != name))
                return default(TMetaType);

            return metaCollection.GetMeta<TMetaType>(name);
        }
    }
}
