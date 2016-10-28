using Furnace.Core.Nancy.Play.Module;

namespace WebApplication1
{
    public sealed class DefaultModule:NancyFurnaceModule
    {
        public DefaultModule()
        {
            Get("/bob", args => View["index"]);

            Get("/", args => View["index", this.Request.Url]);
        }
    }
}
