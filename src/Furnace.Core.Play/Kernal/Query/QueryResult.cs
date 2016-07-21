namespace Furnace.Core.Play.Kernal.Query
{
    public abstract class QueryResult
    {
        public override string ToString()
        {
            return GetType().FullName;
        }
    }
}
