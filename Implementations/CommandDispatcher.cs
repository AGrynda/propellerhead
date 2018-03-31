using System;
using System.Collections.Generic;
using propellerhead.CommandHandlers;
using propellerhead.Commands;
using propellerhead.Interfaces;

namespace propellerhead.Implementations
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _resolver;

        public CommandDispatcher(IServiceProvider resolver)
        {
            _resolver = resolver;
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            var handler = (ICommandHandler<TCommand>)_resolver.GetService(typeof(ICommandHandler<TCommand>));

            if (handler == null)
            {
                //TODO
                throw new KeyNotFoundException();
            }

            handler.Execute(command);
        }
    }
}
