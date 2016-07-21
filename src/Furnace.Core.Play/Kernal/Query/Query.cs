namespace Furnace.Core.Play.Kernal.Query
{
    public abstract class Query
    {
        public override string ToString()
        {
            return GetType().FullName;
        }
    }
}
