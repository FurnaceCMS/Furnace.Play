using SimpleInjector;

namespace Furnace.Core.Play.Module
{
    public interface IFurnaceModule
    {
        void ConfigureContainer(Container container);
    }
}
