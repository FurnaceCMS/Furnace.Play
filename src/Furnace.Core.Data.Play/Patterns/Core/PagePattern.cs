using Furnace.Core.Data.Play.Metas;

namespace Furnace.Core.Data.Play.Patterns.Core
{
    public class PagePattern : Pattern, IPagePattern
    {
        public override string Type => typeof(PagePattern).ToString();
        public string MetaTitle => MetaUtil.TryGetMetaStringValue("metaTitle", RawData);
        public string MetaDescription => MetaUtil.TryGetMetaStringValue("metaDescription", RawData);
        public string MetaKeywords => MetaUtil.TryGetMetaStringValue("metaKeywords", RawData);
        public string MetaAuthor => MetaUtil.TryGetMetaStringValue("metaAuthor", RawData);
        public string Title => MetaUtil.TryGetMetaStringValue("title", RawData);
        public string Body => MetaUtil.TryGetMetaStringValue("body", RawData);

        public PagePattern(string name, IMetaCollection metaCollection) : base(name, metaCollection)
        {
        }
    }
}
