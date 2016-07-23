using SimpleInjector;

namespace Furnace.Core.Play.Kernal.Composition
{
    public interface IFurnaceCompositionRootBuilder: ICompositionRootBuilder
    {
        Container Container { get; }
    }
}
