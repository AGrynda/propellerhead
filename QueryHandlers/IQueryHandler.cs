using propellerhead.Queries;

namespace propellerhead.QueryHandlers
{
    public interface IQueryHandler<in TQuery, out TResult> where TQuery: IQuery
    {
        TResult Execute(TQuery query);
    }
}
