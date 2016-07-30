using System;
using Furnace.Core.Play.Module;
using Nancy.Owin;
using SimpleInjector;

namespace Furnace.Core.Play.Nancy
{
    public class NancyModuleInitialiser: IModuleInitialiser
    {
        public void ConfigureContainer(Container container)
        {
            var options = new NancyOptions { Bootstrapper = new Bootstrapper(container) };
            options.Bootstrapper.Initialise();
            container.Register(() => options, Lifestyle.Singleton);
        }
    }
}
