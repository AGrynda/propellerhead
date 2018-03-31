using System;
using System.Collections.Generic;
using propellerhead.Interfaces;
using propellerhead.Queries;
using propellerhead.QueryHandlers;

namespace propellerhead.Implementations
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _resolver;

        public QueryDispatcher(IServiceProvider resolver)
        {
            _resolver = resolver;
        }

        public TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            var handler = (IQueryHandler<TQuery, TResult>) _resolver.GetService(typeof(IQueryHandler<TQuery, TResult>));

            if (handler == null)
            {
                //TODO
                throw new KeyNotFoundException();
            }

            return handler.Execute(query);
        }
    }
}
