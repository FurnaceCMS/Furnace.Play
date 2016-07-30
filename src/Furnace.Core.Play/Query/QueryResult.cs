namespace Furnace.Core.Play.Query
{
    public abstract class QueryResult
    {
        public override string ToString()
        {
            return GetType().FullName;
        }
    }
}
