using Nancy;

namespace Furnace.Play.Nancy
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get("/", args => View["index"]);
        }
    }
}