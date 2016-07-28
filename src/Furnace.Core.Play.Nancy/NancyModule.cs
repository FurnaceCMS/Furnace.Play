using Furnace.Core.Play.Module;
using Nancy.Owin;
using SimpleInjector;

namespace Furnace.Core.Play.Nancy
{
    public sealed class NancyModule: FurnaceModule
    {
        public NancyModule()
        {
        }

        public override void ConfigureContainer(Container container)
        {
            var options = new NancyOptions { Bootstrapper = new Bootstrapper(container) };
            options.Bootstrapper.Initialise();
            container.Register(()=> options, Lifestyle.Singleton);
            
        }
    }
}
