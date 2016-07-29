using Nancy;
using SimpleInjector;

namespace Furnace.Core.Play.Module
{
    public abstract class FurnaceModule: NancyModule, IFurnaceModule
    {
        public virtual void ConfigureContainer(Container container)
        {
            
        }
    }
}
