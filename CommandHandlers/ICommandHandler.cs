using propellerhead.Commands;

namespace propellerhead.CommandHandlers
{
    public interface ICommandHandler<in TCommand> where TCommand: ICommand
    {
        void Execute(TCommand command);
    }
}
