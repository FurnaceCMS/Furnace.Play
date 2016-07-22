using Furnace.Core.Play.Kernal.Query;

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
