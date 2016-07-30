namespace Furnace.Core.Play.Query
{
    public abstract class Query
    {
        public override string ToString()
        {
            return GetType().FullName;
        }
    }
}
