using SimpleInjector;

namespace Furnace.Core.Play.Composition
{
    public interface IFurnaceCompositionRootBuilder: ICompositionRootBuilder
    {
        Container Container { get; }
    }
}
