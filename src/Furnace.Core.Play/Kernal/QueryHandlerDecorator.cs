namespace Furnace.Core.Play.Kernal
{
    public abstract class QueryHandlerDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult>
       where TQuery : Query
       where TResult : QueryResult
    {
        protected readonly IQueryHandler<TQuery, TResult> Decorated;

        protected QueryHandlerDecorator(IQueryHandler<TQuery, TResult> decorated)
        {
            Decorated = decorated;
        }

        public  abstract TResult Handle(TQuery query);
    }
}
