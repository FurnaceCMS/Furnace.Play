using Furnace.Core.Play.Module;
using SimpleInjector;

namespace Furnace.Core.Requet.Play
{
    public sealed class RequetModule : FurnaceModule
    {
        public RequetModule()
        {
            Get("/", args => "Hello from Nancy running on CoreCLR");
            //Get("/", args => View["index"]);
        }

        public override void ConfigureContainer(Container container)
        {
        }
    }
}
