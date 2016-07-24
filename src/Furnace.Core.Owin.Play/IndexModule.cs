using Nancy;

namespace Furnace.Core.Owin.Play
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get("/", args => View["index"]);
        }
    }
}