using Furnace.Core.Play.Module;

namespace WebApplication1
{
    public sealed class DefaultModule:FurnaceModule
    {
        public DefaultModule()
        {
            Get("/", args => View["index"]);
        }
    }
}
