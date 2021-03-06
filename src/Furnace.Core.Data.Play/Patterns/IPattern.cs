﻿using Furnace.Core.Data.Play.Metas;

namespace Furnace.Core.Data.Play.Patterns
{
    public interface IPattern : IMeta
    {
        IMetaCollection RawData { get; }
    }
}