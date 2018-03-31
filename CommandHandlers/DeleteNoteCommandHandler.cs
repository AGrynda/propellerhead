using propellerhead.Commands;
using propellerhead.Interfaces;

namespace propellerhead.CommandHandlers
{
    public class DeleteNoteCommandHandler : ICommandHandler<DeleteNoteCommand>
    {
        private readonly INotesRepository _notesRepository;

        public DeleteNoteCommandHandler(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public void Execute(DeleteNoteCommand command)
        {
            _notesRepository.DeleteNote(command.Id);
        }
    }
}
