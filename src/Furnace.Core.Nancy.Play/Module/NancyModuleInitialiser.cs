using System;
using System.Collections.Generic;
using System.Reflection;
using Furnace.Core.Play.Module;
using Nancy.Owin;
using SimpleInjector;
using System.Linq;

namespace Furnace.Core.Nancy.Play.Module
{
    public class NancyModuleInitialiser: IModuleInitialiser
    {
        public void ConfigureContainer(Container container)
        {

            var bootstrappers = from ti in GetBootstrappers()
                          select ti.UnderlyingSystemType;

            var b = bootstrappers.SingleOrDefault();

            var bootstrapper = new Bootstrapper(container);

            if (b != null)
            {
                bootstrapper = Activator.CreateInstance(b, container) as Bootstrapper;
            }

            var options = new NancyOptions { Bootstrapper = bootstrapper };
            options.Bootstrapper.Initialise();
            container.Register(() => options, Lifestyle.Singleton);
        }

        private static IEnumerable<TypeInfo> GetBootstrappers()
        {
            return from d in Assembly.GetEntryAssembly().DefinedTypes
                   where typeof(Bootstrapper).IsAssignableFrom(d.AsType())
                   select d;
        }
    }
}
