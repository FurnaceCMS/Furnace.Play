using SimpleInjector;

namespace Furnace.Core.Play.Kernal.Module
{
    public interface IFurnaceModule
    {
        void ConfigureContainer(Container container);
    }
}
