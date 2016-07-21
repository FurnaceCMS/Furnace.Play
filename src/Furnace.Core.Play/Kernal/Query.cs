namespace Furnace.Core.Play.Kernal
{
    public abstract class Query
    {
        public override string ToString()
        {
            return GetType().FullName;
        }
    }
}
