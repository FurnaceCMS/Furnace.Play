using Furnace.Core.Play.Module;
using Nancy.Owin;
using SimpleInjector;

namespace Furnace.Core.Play.Nancy
{
    public class NancyModule: FurnaceModule
    {
        public NancyModule()
        {
        }

        public override void ConfigureContainer(Container container)
        {
            var options = new NancyOptions { Bootstrapper = new Bootstrapper(container) };
            container.Register(()=> options, Lifestyle.Singleton);
        }
    }
}
