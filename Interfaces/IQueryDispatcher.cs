using propellerhead.Queries;

namespace propellerhead.Interfaces
{
    public interface IQueryDispatcher
    {
        TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}