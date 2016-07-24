using System.Collections.Generic;

namespace Furnace.Core.Data.Play.Metas
{
    public interface IMetaCollection
    {
        IList<IMeta> Metas { get; set; }
    }
}