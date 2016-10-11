using Furnace.Core.Nancy.Play.Module;

namespace WebApplication1
{
    public sealed class DefaultModule:NancyFurnaceModule
    {
        public DefaultModule()
        {
            Get("/", args => View["index"]);
        }
    }
}
