﻿using Furnace.Core.Data.Play.Factories.Metas;
using Furnace.Core.Play.Module;
using SimpleInjector;

namespace Furnace.Core.Data.Play
{
    public class DataModuleInitialiser: IModuleInitialiser
    {
        public void ConfigureContainer(Container container)
        {
            container.Register<IMetaCollectionFactory, MetaCollectionFactory>();
        }
    }
}