using Nancy;
using SimpleInjector;

namespace Furnace.Core.Play.Module
{
    public abstract class FurnaceModule: NancyModule, IFurnaceModule
    {
        public abstract void ConfigureContainer(Container container);
    }
}
