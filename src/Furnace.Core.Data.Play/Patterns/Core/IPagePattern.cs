using Furnace.Core.Data.Play.Metas;

namespace Furnace.Core.Data.Play.Patterns.Core
{
    public interface IPagePattern : IMeta
    {
        string MetaTitle { get; }
        string MetaDescription { get; }
        string MetaKeywords { get; }
        string MetaAuthor { get; }
        string Title { get; }
        string Body { get; }
    }
}