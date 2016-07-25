using Furnace.Core.Play.Query;

namespace Furnace.Core.Requet.Play
{
    public class WebRequestQuery : Query
    {
        public readonly string Path;

        public WebRequestQuery(string path)
        {
            Path = path;
        }
    }
}
