using Nancy;

namespace Furnace.Core.Play.Module
{
    internal interface IFurnaceModule
    {
    }

    public abstract class FurnaceModule: NancyModule, IFurnaceModule
    {
    }
}
