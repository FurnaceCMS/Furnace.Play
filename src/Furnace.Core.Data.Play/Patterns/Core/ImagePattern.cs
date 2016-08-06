using Furnace.Core.Data.Play.Metas;

namespace Furnace.Core.Data.Play.Patterns.Core
{
    public class ImagePattern : Pattern, IImagePattern
    {
        public override string Type => typeof(ImagePattern).ToString();
        public string Src => MetaUtil.TryGetMetaStringValue("src", RawData);
        public string Alt => MetaUtil.TryGetMetaStringValue("alt", RawData);
        public int Height => MetaUtil.TryGetMetaIntValue("height", RawData);
        public int Width => MetaUtil.TryGetMetaIntValue("width", RawData);

        public ImagePattern(string name, IMetaCollection metaCollection) : base(name, metaCollection)
        {
        }
    }
}
