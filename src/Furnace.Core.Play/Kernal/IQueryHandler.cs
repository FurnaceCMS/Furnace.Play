namespace Furnace.Core.Play.Kernal
{
    public interface IQueryHandler<in TQuery, out TResult>
        where TQuery : Query
        where TResult : QueryResult
    {
        TResult Handle(TQuery query);
    }
}
