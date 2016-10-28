using System.Linq;
using System.Linq.Expressions;
using Remotion.Linq;
using Remotion.Linq.Parsing.Structure;


namespace Furnace.Core.Data.Play.LinqToMetas
{
    public class MetasQueryable<T> : QueryableBase<T>
    {
        //private static IQueryExecutor CreateExecutor()
        //{
        //    return new MetasQueryable();
        //}

        //public MetasQueryable() : base(CreateExecutor())
        //{
        //}

        public MetasQueryable(IQueryParser queryParser, IQueryExecutor executor)
            : base(new DefaultQueryProvider(typeof(MetasQueryable<>), queryParser, executor))
        {
        }

        public MetasQueryable(IQueryProvider provider, Expression expression)
            : base(provider, expression)
        {
        }

        public override string ToString()
        {
            return "MetasQueryable<" + typeof(T).Name + ">()";
        }
    }
}
