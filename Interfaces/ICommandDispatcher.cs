using propellerhead.Commands;

namespace propellerhead.Interfaces
{
    public interface ICommandDispatcher
    {
        void Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
