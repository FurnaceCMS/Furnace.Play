using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nancy;
using SimpleInjector;

namespace Furnace.Core.Nancy.Play
{
    public class SimpleInjectorModuleCatalog: INancyModuleCatalog
    {
        private readonly Container _container;
        public SimpleInjectorModuleCatalog(Container container) { this._container = container; }
        public IEnumerable<INancyModule> GetAllModules(NancyContext context)
        {
            return from r in _container.GetCurrentRegistrations()
                   where typeof(INancyModule).IsAssignableFrom(r.ServiceType)
                   select (INancyModule)r.GetInstance();
        }

        public INancyModule GetModule(Type moduleType, NancyContext context)
        {
            return (INancyModule)_container.GetInstance(moduleType);
        }
    }
}
