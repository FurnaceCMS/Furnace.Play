namespace Furnace.Core.Data.Play.LinqToMetas
{
    public class MetasQueryFactory
    {
        public static MetasQueryable<T> Queryable<T>()
        {
            return new MetasQueryable<T>();
        }
    }
}
