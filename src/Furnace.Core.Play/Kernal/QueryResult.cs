namespace Furnace.Core.Play.Kernal
{
    public abstract class QueryResult
    {
        public override string ToString()
        {
            return GetType().FullName;
        }
    }
}
