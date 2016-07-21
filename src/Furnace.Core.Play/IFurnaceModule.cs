using SimpleInjector;

namespace Furnace.Core.Play
{
    public interface IFurnaceModule
    {
        void ConfigureContainer(Container container);
    }
}
