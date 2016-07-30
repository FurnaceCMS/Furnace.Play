using SimpleInjector;

namespace Furnace.Core.Play.Module
{
    public interface IModuleInitialiser
    {
        void ConfigureContainer(Container container);
    }
}
