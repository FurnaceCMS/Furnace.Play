namespace Furnace.Core.Play.Query
{
    public interface IQueryHandler<in TQuery, out TResult>
        where TQuery : Query
        where TResult : QueryResult
    {
        TResult Handle(TQuery query);
    }
}
